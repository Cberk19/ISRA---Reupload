using System;
using System.IO;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using ClassLibrary;
using ISRA.Classes;
using System.Data;
using System.Data.SqlClient;
using System.Net.Mail;
using System.Text;

namespace ISRA
{
    public partial class Advisor_RequestDetails : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            if (!IsPostBack)
            {
                Connection objDB = new Connection();

                // redirect to landing if nobody logged in
                if (Request.Cookies["user_cookie"] == null)
                {
                    Response.Redirect("../General_LandingPage.aspx");
                }
                else
                {
                    // redirect 404 if not correct user
                    if (Request.Cookies["user_cookie"]["user_type"].CompareTo("advisor") != 0 || int.Parse(Session["pageSwitchID"].ToString()) == -1)
                    {
                        Response.Redirect("General_404.aspx");
                    }
                }

                ISRARequest ir = ISRAUtils.GetISRAByID(int.Parse(Session["pageSwitchID"].ToString()));

                this.renderUI(ir);
            }
            
        }

        protected void btnUpdateStatus_Click(object sender, EventArgs e)
        {
            Connection objDB = new Connection();

            int idFromUrl = int.Parse(Session["pageSwitchID"].ToString());

            ISRARequest israObj = new ISRARequest();
            israObj.Status = ddlStatus.SelectedItem.Value;
            israObj.Isra_Id = idFromUrl;
            israObj.Decision_Text = taStatusReason.Value;
            israObj.Last_User = "jason jung";
            israObj.Student_Email = Email.InnerText;
            israObj.Student_First = Full_Name.InnerText;
            israObj.Student_Major = Major.InnerText;
            israObj.TUID = Convert.ToInt32(TUID.InnerText);
            israObj.Registrar = Registered_By.InnerText;
            israObj.Grade_Instructor = Grade_Instructor.InnerText;
            israObj.Credit_Hours = Convert.ToInt32(Credits.InnerText);
            israObj.Semester = Semester.InnerText;
            israObj.Course_Number = Course_Number.InnerText;

            int status = -1;
            if (israObj.Status.CompareTo("PENDING") == 0)
            {
                Email c = ISRAUtils.GetEmailByID(3);
                //sending email notification to student
                string toStudentEmail = Email.InnerText;
                string mailbody = this.createDecisionEmail(israObj);
                string subject = $"{c.Subject} {israObj.Status}";
                this.sendEmail(toStudentEmail, subject, mailbody);
                // send email to supervising instructor
                this.sendEmail(israObj.Grade_Instructor, subject, mailbody);

                status = objDB.DoUpdateUsingCmdObj(StoredProcedure.PendingRequest(israObj));
            }
            if (israObj.Status.CompareTo("DENIED") == 0)
            {
                Email c = ISRAUtils.GetEmailByID(3);
                //sending email notification to student
                string toStudentEmail = Email.InnerText;
                string mailbody = this.createDecisionEmail(israObj);
                string subject = $"{c.Subject} {israObj.Status}";
                this.sendEmail(toStudentEmail, subject, mailbody);
                // send email to supervising instructor
                this.sendEmail(israObj.Grade_Instructor, subject, mailbody);

                status = objDB.DoUpdateUsingCmdObj(StoredProcedure.DenyRequest(israObj));
                btnUpdateStatus.CssClass = "btn btn-danger disabled";
                this.ddlStatus.Enabled = false;
            }
            if (israObj.Status.CompareTo("APPROVED") == 0 && !hasEmptyFields())
            {
                israObj.CRN = int.Parse(this.txtCRN.Text);
                israObj.Section_Number = int.Parse(this.txtSection.Text);

                Email c = ISRAUtils.GetEmailByID(3);
                //sending email notification to student
                string toStudentEmail = Email.InnerText;
                string mailbody = this.createDecisionEmail(israObj);
                string subject = $"{c.Subject} {israObj.Status}";
                this.sendEmail(toStudentEmail, subject, mailbody);
                // send email to supervising instructor
                this.sendEmail(israObj.Grade_Instructor, subject, mailbody);

                status = objDB.DoUpdateUsingCmdObj(StoredProcedure.ApproveRequest(israObj));
                btnUpdateStatus.CssClass = "btn btn-danger disabled";
                this.ddlStatus.Enabled = false;
            }

            if (status < 1)
            {
                this.lblAlert.CssClass = "alert alert-danger d-inline-block";
                this.lblAlert.Text = "Error: could not update status";
            } else
            {
                this.lblAlert.CssClass = "alert alert-success d-inline-block";
                this.lblAlert.Text = "Status updated successfully.";
            }
        }
        private void renderUI(ISRARequest ireq)
        {
            DateTime parsedDate = DateTime.Parse(ireq.Date_Submitted);
            string formattedDate = parsedDate.ToString("dddd, MMMM dd yyyy");
            lblDateSubmitted.InnerHtml = $"Submitted on: {formattedDate}";

            this.spanIsraID.InnerHtml = ireq.Isra_Id.ToString();
            TUID.InnerHtml = ireq.TUID.ToString();
            Full_Name.InnerHtml = ireq.Student_First + "<span>&nbsp;</span>" + ireq.Student_Last;
            Email.InnerHtml = ireq.Student_Email;
            Major.InnerHtml = ireq.Student_Major;

            Registered_By.InnerHtml = ireq.Registrar;
            Grade_Instructor.InnerHtml = ireq.Grade_Instructor;

            Course_Number.InnerHtml = ireq.Course_Number;
            Credits.InnerHtml = ireq.Credit_Hours.ToString();
            txtCRN.Text = ireq.CRN == 0 ? string.Empty : ireq.CRN.ToString();
            txtSection.Text = ireq.Section_Number == 0 ? string.Empty : ireq.Section_Number.ToString();
            Semester.InnerHtml = ireq.Semester;

            string filepath = "~/images/" + ireq.Approve_Url;
            string serverPath = Server.MapPath(filepath);
            bool fileExist = File.Exists(serverPath);
            imgApproval.ImageUrl = fileExist ? filepath : string.Empty;

            string coursePlanPath = "~/coursePlanAttachment/" + ireq.Course_Plan;
            if (Path.GetExtension(coursePlanPath).CompareTo(".pdf") == 0)
            {
                string coursePlanServer = Server.MapPath(coursePlanPath);
                bool coursePlanExist = File.Exists(serverPath);

                linkCoursePlan.NavigateUrl = coursePlanExist ? coursePlanPath : string.Empty;
            } else
            {
                this.linkCoursePlan.Visible = false;
                this.lbCoursePlanDownload.Visible = true;
            }
            taExtraNote.InnerHtml = ireq.Extra_Note;

            ddlStatus.SelectedValue = ireq.Status.ToUpper();
            taStatusReason.InnerHtml = ireq.Decision_Text;

            if (ireq.Status.CompareTo("APPROVED") == 0 || ireq.Status.CompareTo("DENIED") == 0)
            {
                btnUpdateStatus.CssClass = "btn btn-danger disabled";
                this.ddlStatus.Enabled = false;
            }
        }

        protected void btnGoBack_Click(object sender, EventArgs e)
        {
            Response.Redirect("Advisor_Search.aspx");
        }
        protected void btnLogout_Click(object sender, EventArgs e)
        {
            Response.Redirect("Logout.aspx");
        }

      
       private string createDecisionEmail(ISRARequest isra)
        {
            int AdvisorUpdateEmailTemplateid = 3;
            Email c = ISRAUtils.GetEmailByID(AdvisorUpdateEmailTemplateid);

            DateTime currentDate = DateTime.Today;
            string dateStamp = currentDate.ToString("dddd, MMMM dd yyyy");

            string intro = $"Hi {isra.Student_First}, <br><br> {c.Intro} {isra.Status} (decision made on {dateStamp}).<br> <strong>Decision Reason:</strong> {isra.Decision_Text}.<br> {c.Additional_info}<br><br>";
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
                $"Semester: <span style='font-family: monospace;'>{isra.Semester}</span><br>" +
                $"CRN: <span style='font-family: monospace;'>{(isra.CRN == 0 ? "N/A" : isra.CRN.ToString())}</span><br>" +
                $"Section Number: <span style='font-family: monospace;'>{(isra.Section_Number == 0 ? "N/A" : isra.Section_Number.ToString())}</span><br><br>";
            string dashboardLink = $"<a href='https://{Request.Url.Host}/cis4396-f01/Secure/Student_Search.aspx'>View your requests</a><br>";
            string whoToContact = $"Please contact <span style='font-family: monospace;'>{c.Who_to_contact}</span> if you have any questions<br><br>";
            string outro = $"{c.Ending} <br>ISRA Team";
            return intro + studentInfo + facultyInfo + courseInfo + dashboardLink + whoToContact + outro;

        }

        private bool hasEmptyFields()
        {
            bool hasEmpty = false;
            List<TextBox> fields = new List<TextBox>();
            List<TextBox> emptyFields = new List<TextBox>();
            fields.Add(this.txtCRN);
            fields.Add(this.txtSection);

            foreach (TextBox field in fields)
            {
                if (String.IsNullOrEmpty(field.Text))
                {
                    hasEmpty = true;
                    emptyFields.Add(field);
                    field.CssClass += " border border-danger";
                }
                else
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

        protected void lbCoursePlanDownload_Click(object sender, EventArgs e)
        {
            ISRARequest ir = ISRAUtils.GetISRAByID(int.Parse(Session["pageSwitchID"].ToString()));
            string filePath = $"~/coursePlanAttachment/{ir.Course_Plan_Url}";
            Response.ContentType = "application/octet-stream";
            Response.AppendHeader("Content-Disposition", $"attachment; filename={ir.Course_Plan_Url}");
            Response.TransmitFile(filePath);
            Response.End();
        }

        private void sendEmail(string to, string subject, string body)
        {
            MailMessage message = new MailMessage("tuisrateam5@gmail.com", to);

            message.Subject = subject;
            message.Body = body;
            message.BodyEncoding = Encoding.UTF8;
            message.IsBodyHtml = true;

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
    }
}