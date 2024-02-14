using ClassLibrary;
using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using ClassLibrary;
using ISRA.Classes;
using System.Net.Mail;
using System.Text;
using System.Text.RegularExpressions;
using System.IO;

namespace ISRA
{
    public partial class Student_RequestForm : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            // redirect to landing if nobody logged in
            if (Request.Cookies["user_cookie"] == null)
            {
                Response.Redirect("../General_LandingPage.aspx");
            }
            else
            {
                // redirect 404 if not correct user
                if (Request.Cookies["user_cookie"]["user_type"].CompareTo("student") != 0)
                {
                    Response.Redirect("General_404.aspx");
                }
                else
                {
                    fillSemesterYears();
                    autofillStudentInfo();
                }
            }
        }

        protected void btnReturn_Click(object sender, EventArgs e)
        {
            Response.Redirect("Student_Search.aspx");
        }
        

        protected void btnComplete_Click(object sender, EventArgs e)
        {
            // first check if fields are valid
            if (!hasEmptyFields() && isSignatureValid() && isFacultyEmailValid() && hasApprovalScreenshot() && hasCoursePlan())
            {
                ISRARequest I = new ISRARequest();

                WebService.LDAPuser currentUser = WebService.Webservice.getLDAPEntryByTUID(Request.Cookies["tuid_cookie"].Value.ToString());
                string tuid = Request.Cookies["tuid_cookie"].Value;
                WebService.StudentObj Student_Information = WebService.Webservice.getStudentInfo(tuid);
                string user = currentUser.givenName + currentUser.sn;

                I.TUID = Convert.ToInt32(Student_Information.tuid);
                I.Student_First = Student_Information.firstName;
                I.Student_Last = Student_Information.lastName;
                I.Student_Email = Student_Information.email;
                I.Student_Major = string.IsNullOrEmpty(Student_Information.major2) ? Student_Information.major1 : Student_Information.major1 + " " + Student_Information.major2;
                I.Grade_Instructor = txtGradeInstructor.Text;

                string uniqueApprovalFileName = $"{Path.GetFileNameWithoutExtension(fuApproval.PostedFile.FileName)}" +
                    $"{ISRAUtils.AppendToFileName(Convert.ToInt32(tuid))}" +
                    $"{Path.GetExtension(fuApproval.PostedFile.FileName)}";

                I.Approve_Url = uniqueApprovalFileName;
                I.Course_Number = ddlCourseNumber.SelectedItem.Value.ToString();
                I.Credit_Hours = Convert.ToInt32(ddlCredits.SelectedItem.Value.ToString());
                I.Semester = $"{ddlSemester.SelectedItem.Value.ToString()} {ddlYear.SelectedItem.Value.ToString()}";

                string uniqueCoursePlanFileName = $"{Path.GetFileNameWithoutExtension(fuCoursePlan.PostedFile.FileName)}" +
                    $"{ISRAUtils.AppendToFileName(Convert.ToInt32(tuid))}" +
                    $"{Path.GetExtension(fuCoursePlan.PostedFile.FileName)}";

                I.Course_Plan_Url = uniqueCoursePlanFileName;
                I.Course_Plan = uniqueCoursePlanFileName;
                I.Student_Signature = txtSignature.Text;
                I.Last_User = user;
                I.Registrar = ISRAUtils.GetAdminsReceivingEmails().Count == 0 ? "dominic.letarte@temple.edu" : ISRAUtils.GetAdminsReceivingEmails()[0].Email;
                I.Status = "PENDING";
                I.Extra_Note = String.IsNullOrEmpty(this.taExtraNote.Value) ? "N/A" : this.taExtraNote.Value;
                DateTime currentDate = DateTime.Today;
                I.Date_Submitted = currentDate.ToString("dddd, MMMM dd yyyy");

                Connection conn = new Connection();
                //int applicationCount = (int)conn.ExecuteScalarFunction(StoredProcedure.PreventApplicationDuplication(I));
                int applicationCount = 0; //Placeholder until we can decide what to do with duplication prevention
                SqlCommand cmd = StoredProcedure.InsertISRA(I);
                if (applicationCount == 0)
                {
                    saveImage(uniqueApprovalFileName);
                    saveCoursePlan(uniqueCoursePlanFileName);
                    conn.DoUpdateUsingCmdObj(cmd);


                    //sending email notification to student
                    string toStudentEmail = I.Student_Email; // to address
                    Email a = ISRAUtils.GetEmailByID(2);
                    string studentEmailSubject = a.Subject;
                    this.sendEmail(toStudentEmail, studentEmailSubject, this.createStudentEmailBody(I), uniqueApprovalFileName, uniqueCoursePlanFileName);


                    //sending email notification to faculty
                    string facultyEmail = I.Grade_Instructor; // to address
                    Email facultyEmailTemp = ISRAUtils.GetEmailByID(1);
                    string facultyEmailSubject = $"{facultyEmailTemp.Subject} {I.Student_First} {I.Student_Last}";
                    this.sendEmail(facultyEmail, facultyEmailSubject, this.createAdvisorEmailBody(I), uniqueApprovalFileName, uniqueCoursePlanFileName);


                    //-----------------------------------------------------------------------------------------

                    //sending an email notification to the advisor(s)
                    List<Admin> adminsReceivingEmails = ISRAUtils.GetAdminsReceivingEmails();
                    if (adminsReceivingEmails.Count != 0)
                    {
                        foreach (Admin admin in adminsReceivingEmails)
                        {
                            string advisorEmail = admin.Email;
                            Email b = ISRAUtils.GetEmailByID(1);
                            string advisorEmailSubject = $"{b.Subject} {I.Student_First} {I.Student_Last}";
                            this.sendEmail(advisorEmail, advisorEmailSubject, this.createAdvisorEmailBody(I), uniqueApprovalFileName, uniqueCoursePlanFileName);
                        }
                    }

                    Response.Redirect("Student_Confirmation.aspx");
                }
                else
                {
                    //Have an alert pop up saying record already exist
                    this.lblAlert.CssClass = "alert alert-danger d-inline-block";
                    this.lblAlert.Text = "Record already exists";
                }

                //------------------------------------------------------------------------------------------


            }
        }
        

        private bool hasEmptyFields()
        {
            bool hasEmpty = false;
            List<TextBox> fields = new List<TextBox>();
            List<TextBox> emptyFields = new List<TextBox>();
            fields.Add(this.txtGradeInstructor);
            fields.Add(this.txtSignature);

            foreach (TextBox field in fields)
            {
                if (String.IsNullOrEmpty(field.Text))
                {
                    hasEmpty = true;
                    emptyFields.Add(field);
                    field.CssClass += " border border-danger";
                } else
                {
                    field.CssClass = "form-control";
                }
            }
            if (hasEmpty)
            {
                this.lblAlert.CssClass = "alert alert-danger d-inline-block";
                this.lblAlert.Text = "Please fill out required fields in red";
            }
            return hasEmpty;
        }

        private bool isSignatureValid()
        {
            int numCheck;
            bool isNumber = int.TryParse(this.txtSignature.Text, out numCheck);
            if (!isNumber)
            {
                this.txtSignature.CssClass = "form-control";
                return true;
            }
            this.txtSignature.CssClass += " border border-danger";
            this.lblAlert.CssClass = "alert alert-danger d-inline-block";
            this.lblAlert.Text = "Student signature cannot be a number";
            return false;
        }

        private bool isFacultyEmailValid()
        {
            bool isEmail = Regex.IsMatch(this.txtGradeInstructor.Text, @"\A(?:[a-z0-9!#$%&'*+/=?^_`{|}~-]+(?:\.[a-z0-9!#$%&'*+/=?^_`{|}~-]+)*@(?:[a-z0-9](?:[a-z0-9-]*[a-z0-9])?\.)+[a-z0-9](?:[a-z0-9-]*[a-z0-9])?)\Z", RegexOptions.IgnoreCase);
            if (isEmail)
            {
                this.txtGradeInstructor.CssClass = "form-control";
                return true;
            }
            this.txtGradeInstructor.CssClass += " border border-danger";
            this.lblAlert.CssClass = "alert alert-danger d-inline-block";
            this.lblAlert.Text = "Please enter a valid email for your instructor (example: test@temple.edu)";
            return false;
        }
        private bool hasApprovalScreenshot()
        {
            bool hasFile = this.fuApproval.HasFile;
            var postedFileExtension = Path.GetExtension(this.fuApproval.PostedFile.FileName);
            bool isImage = string.Equals(postedFileExtension, ".jpg", StringComparison.OrdinalIgnoreCase) || string.Equals(postedFileExtension, ".png", StringComparison.OrdinalIgnoreCase) || string.Equals(postedFileExtension, ".gif", StringComparison.OrdinalIgnoreCase) || string.Equals(postedFileExtension, ".jpeg", StringComparison.OrdinalIgnoreCase);

            if (!hasFile && !isImage)
            {
                this.fuApproval.CssClass = "border border-danger";
                this.lblAlert.CssClass = "alert alert-danger d-inline-block";
                this.lblAlert.Text = "Please upload an image or screenshot for instructor's approval (.jpg, .png, .gif, .jpeg)";
                return false;
            }
            this.fuApproval.CssClass = "";
            return true;
        }

        private bool hasCoursePlan()
        {
            bool hasFile = this.fuCoursePlan.HasFile;
            var postedFileExtension = Path.GetExtension(this.fuCoursePlan.PostedFile.FileName);
            bool isCoursePlan = string.Equals(postedFileExtension, ".pdf", StringComparison.OrdinalIgnoreCase);

            if (!hasFile && !isCoursePlan)
            {
                this.fuCoursePlan.CssClass = "border border-danger";
                this.lblAlert.CssClass = "alert alert-danger d-inline-block";
                this.lblAlert.Text = "Please upload a document with your course plan in it (.pdf)";
                return false;
            }
            this.fuCoursePlan.CssClass = "";
            return true;
        }

        private string createAdvisorEmailBody(ISRARequest isra)
        {
            int AdvisorEmailTemplateid = 1;
            Email b = ISRAUtils.GetEmailByID(AdvisorEmailTemplateid);

            string intro = $"Hi, <br><br> {b.Intro} on {isra.Date_Submitted}.<br> {b.Additional_info}<br><br>";
            string studentInfo = $"<strong>Student Info:</strong><br>" +
                $"TUID: <span style='font-family: monospace;'>{isra.TUID}</span><br>" +
                $"Full Name: <span style='font-family: monospace;'>{isra.Student_First} {isra.Student_Last}</span><br>" +
                $"Email: <span style='font-family: monospace;'>{isra.Student_Email}</span><br>" +
                $"Major: <span style='font-family: monospace;'>{isra.Student_Major}</span><br><br>";
            string facultyInfo = $"<strong>Faculty Info:</strong><br>" +
                $"Registrar: <span style='font-family: monospace;'>{isra.Registrar}</span><br>" +
                $"Grade Instructor: <span style='font-family: monospace;'>{isra.Grade_Instructor}</span><br><br>";
            string courseInfo = $"<strong>Course Info:</strong><br>" +
                $"Course Requested: <span style='font-family: monospace;'>{isra.Course_Number}</span><br>" +
                $"Credits: <span style='font-family: monospace;'>{isra.Credit_Hours}</span><br>" +
                $"Semester: <span style='font-family: monospace;'>{isra.Semester}</span><br><br>";
            string extraNote = $"<strong>Extra Note (from Student):</strong><br>" +
                $"<span style='font-family: monospace;'>{isra.Extra_Note}</span><br><br>";
            string dashboardLink = $"<a href='https://{Request.Url.Host}/cis4396-f01/Secure/Student_Search.aspx'>View your requests</a><br><br>";
            string outro = $"{b.Ending} <br>ISRA Team";
            return intro + studentInfo + facultyInfo + courseInfo + extraNote + dashboardLink + outro;

        }
        private string createStudentEmailBody(ISRARequest isra)
        {
            int StudentEmailTemplateid = 2;
            Email a = ISRAUtils.GetEmailByID(StudentEmailTemplateid);

            string intro = $"Hi {isra.Student_First}, <br><br>  {a.Intro} on {isra.Date_Submitted}.<br>  {a.Additional_info}<br><br>";
            string studentInfo = $"<strong>Student Info:</strong><br>" +
               $"TUID: <span style='font-family: monospace;'>{isra.TUID}</span><br>" +
                $"Full Name: <span style='font-family: monospace;'>{isra.Student_First} {isra.Student_Last}</span><br>" +
                $"Email: <span style='font-family: monospace;'>{isra.Student_Email}</span><br>" +
                $"Major: <span style='font-family: monospace;'>{isra.Student_Major}</span><br><br>";
            string facultyInfo = $"<strong>Faculty Info:</strong><br>" +
                $"Registrar: <span style='font-family: monospace;'>{isra.Registrar}</span><br>" +
                $"Grade Instructor: <span style='font-family: monospace;'>{isra.Grade_Instructor}</span><br><br>";
            string courseInfo = $"<strong>Course Info:</strong><br>" +
                $"Course Requested: <span style='font-family: monospace;'>{isra.Course_Number}</span><br>" +
                $"Credits: <span style='font-family: monospace;'>{isra.Credit_Hours}</span><br>" +
                $"Semester: <span style='font-family: monospace;'>{isra.Semester}</span><br><br>";
            string extraNote = $"<strong>Extra Note (from Student):</strong><br>" +
                $"<span style='font-family: monospace;'>{isra.Extra_Note}</span><br><br>";
            string dashboardLink = $"<a href='https://{Request.Url.Host}/cis4396-f01/Secure/Student_Search.aspx'>View your requests</a><br>";
            string whoToContact = $"Please contact <span style='font-family: monospace;'>{a.Who_to_contact}</span> if you have any questions<br><br>";
            string outro = $"{a.Ending} <br>ISRA Team";
            return intro + studentInfo + facultyInfo + courseInfo + extraNote + dashboardLink + whoToContact + outro;
        }

        protected void btnLogout_Click(object sender, EventArgs e)
        {
            Response.Redirect("Logout.aspx");
        }

        private void saveImage (string fileName)
        {
            fuApproval.SaveAs(Server.MapPath("~/images/" + fileName));
        }

        private void saveCoursePlan (string fileName)
        {
            fuCoursePlan.SaveAs(Server.MapPath("~/coursePlanAttachment/" + fileName));
        }
        private void sendEmail(string to, string subject, string body, string approvalFileName, string coursePlanFileName)
        {
            MailMessage message = new MailMessage("tuisrateam5@gmail.com", to);

            message.Subject = subject;
            message.Body = body;
            message.BodyEncoding = Encoding.UTF8;
            message.IsBodyHtml = true;

            System.Net.Mail.Attachment approval = new System.Net.Mail.Attachment(Server.MapPath(("~/images/" + approvalFileName)));
            System.Net.Mail.Attachment coursePlan = new System.Net.Mail.Attachment(Server.MapPath(("~/coursePlanAttachment/" + coursePlanFileName)));
            message.Attachments.Add(approval);
            message.Attachments.Add(coursePlan);

            SmtpClient client = new SmtpClient("smtp.gmail.com", 587); //gmail smtp email  
            System.Net.NetworkCredential basicCredential1 = new
            System.Net.NetworkCredential("tuisrateam5@gmail.com", "bxes kecl pzwq jvgs "); // this is the header of who sent the email. Needs to be real email address
            client.EnableSsl = true;
            client.UseDefaultCredentials = false;
            client.Credentials = basicCredential1;
            try
            {
                client.Send(message);
            }

            catch (Exception ex)
            {
                throw ex;
            }
        }

        private void autofillStudentInfo ()
        {
            string tuid = Request.Cookies["tuid_cookie"].Value;
            WebService.StudentObj Student_Information = WebService.Webservice.getStudentInfo(tuid);
            txtTUID.InnerHtml = Student_Information.tuid;
            txtName.InnerHtml = Student_Information.firstName + " " + Student_Information.lastName;
            txtEmail.InnerHtml = Student_Information.email;
            txtMajor.InnerHtml = string.IsNullOrEmpty(Student_Information.major2) ? Student_Information.major1 : Student_Information.major1 + " " + Student_Information.major2;
        }

        private void fillSemesterYears()
        {
            DateTime currentDate = DateTime.Now;
            string currentYear = currentDate.Year.ToString();
            string nextYear = currentDate.AddYears(1).Year.ToString();
            string yearAfterNext = currentDate.AddYears(2).Year.ToString();

            this.ddlYear.Items.Insert(0, new ListItem(currentYear, currentYear));
            this.ddlYear.Items.Insert(1, new ListItem(nextYear, nextYear));
            this.ddlYear.Items.Insert(2, new ListItem(yearAfterNext, yearAfterNext));
        }
    }
}