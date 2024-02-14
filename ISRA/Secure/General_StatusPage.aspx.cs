using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using ISRA.Classes;
using ClassLibrary;
using System.IO;

namespace ISRA
{
    public partial class General_StatusPage : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            // redirect to landing if nobody logged in
            if (Request.Cookies["user_cookie"] == null)
            {
                Response.Redirect("General_LandingPage.aspx");
            }
            else
            {
                // redirect 404 if not correct user
                if (Request.Cookies["user_cookie"]["user_type"].CompareTo("advisor") == 0 || int.Parse(Session["pageSwitchID"].ToString()) == -1)
                {
                    Response.Redirect("General_404.aspx");
                }
            }

            this.manageNavLinks();

            ISRARequest ireq = ISRAUtils.GetISRAByID(int.Parse(Session["pageSwitchID"].ToString()));

            if (!this.hasAccessToThisRequest(ireq))
            {
                Response.Redirect("General_404.aspx");
            }

            this.displayData(ireq);
        }

        protected void btn_Click(object sender, EventArgs e)
        {
            Response.Redirect("General_LandingPage.aspx");
        }

        public void manageNavLinks()
        {
            if (Request.Cookies["user_cookie"]["user_type"].CompareTo("student") == 0)
            {
                this.viewRequestsLinkFaculty.Visible = false;
             
                this.linkReturn.HRef = "Student_Search.aspx";
                this.aLogo.HRef = "Student_Search.aspx";
            }
            if (Request.Cookies["user_cookie"]["user_type"].CompareTo("faculty") == 0)
            {
                this.viewRequestsLinkFaculty.Visible = true;
                this.viewRequestsLinkStudent.Visible = false;
                this.newRequestLinkStudent.Visible = false;

                this.linkReturn.HRef = "FacultyMember_Search.aspx";
                this.aLogo.HRef = "FacultyMember_Search.aspx";
            }
        }
        protected void btnLogout_Click(object sender, EventArgs e)
        {
            Response.Redirect("Logout.aspx");
        }

        private void displayData(ISRARequest ireq)
        {
            DateTime parsedDate = DateTime.Parse(ireq.Date_Submitted);
            string formattedDate = parsedDate.ToString("dddd, MMMM dd yyyy");
            lblDateSubmitted.InnerHtml = $"Submitted on: {formattedDate}";

            this.spanIsraID.InnerHtml = ireq.Isra_Id.ToString();
            TUID.InnerHtml = ireq.TUID.ToString();
            Full_Name.InnerHtml = $"{ireq.Student_First} {ireq.Student_Last}";
            Email.InnerHtml = ireq.Student_Email;
            Major.InnerHtml = ireq.Student_Major;

            Registered_By.InnerHtml = ireq.Registrar;
            Grade_Instructor.InnerHtml = ireq.Grade_Instructor;

            Course_Number.InnerHtml = ireq.Course_Number;
            Credits.InnerHtml = ireq.Credit_Hours.ToString();
            CRN.InnerHtml = ireq.CRN == 0 ? "N/A" : ireq.CRN.ToString();
            Section.InnerHtml = ireq.Section_Number == 0 ? "N/A" : ireq.Section_Number.ToString();
            Semester.InnerHtml = ireq.Semester;

            string filepath = "~/coursePlanAttachment/" + ireq.Course_Plan;
            if (Path.GetExtension(filepath).CompareTo(".pdf") == 0)
            {
                string coursePlanServer = Server.MapPath(filepath);
                bool coursePlanExist = File.Exists(coursePlanServer);

                linkCoursePlan.NavigateUrl = coursePlanExist ? filepath : string.Empty;
            }
            else
            {
                this.linkCoursePlan.Visible = false;
                this.lbCoursePlanDownload.Visible = true;
            }
            taExtraNote.InnerHtml = ireq.Extra_Note;

            Status.InnerHtml = ireq.Status.ToUpper();
            Status_Reason.InnerHtml = ireq.Decision_Text;

            // status bar ui logic
            if (ireq.Status.ToLower().CompareTo("pending") != 0) // safety check
            {
                if (ireq.Status.ToLower().CompareTo("denied") == 0)
                {
                    this.divSubmittedCircle.Style.Add("background", "#e8a9af !important;");
                    this.divSubmittedLine.Style.Add("background", "#e8a9af !important;");
                    this.divPendingCircle.Style.Add("background", "#e8a9af !important;");
                    this.divPendingCircle.Style.Add("width", "40px !important;");
                    this.divPendingCircle.Style.Add("height", "40px !important;");
                    this.iHourglassIcon.Style.Remove("font-size");
                    this.smallSubmittedTxt.Attributes["class"] += " text-secondary";

                    this.Status.Attributes["class"] = "fw-bold text-danger";
                }
                if (ireq.Status.ToLower().CompareTo("approved") == 0)
                {
                    this.divPendingCircle.Style.Add("width", "40px !important;");
                    this.divPendingCircle.Style.Add("height", "40px !important;");
                    this.iHourglassIcon.Style.Remove("font-size");
                    this.divApprovedLine.Style.Remove("background");
                    this.divApprovedCircle.Style.Remove("background");
                    this.divApprovedLine.Attributes["class"] += " bg-danger";
                    this.divApprovedCircle.Attributes["class"] += " bg-danger";
                    this.divApprovedCircle.Style.Add("width", "90px !important;");
                    this.divApprovedCircle.Style.Add("height", "90px !important;");
                    this.smallApprovedTxt.Attributes["class"] += " text-dark";
                    this.iCheckIcon.Style.Add("font-size", "32px;");
                    this.iCheckIcon.Attributes["class"] += " mb-1";

                    this.Status.Attributes["class"] = "fw-bold text-success";
                }
            }
        }
        private bool hasAccessToThisRequest(ISRARequest request)
        {
            bool toReturn = false;
            string userType = Request.Cookies["user_cookie"]["user_type"];
            int tuid = int.Parse(Request.Cookies["tuid_cookie"].Value.ToString());

            // user is a student 
            if (userType.CompareTo("student") == 0)
            {
                if (request.TUID == tuid)
                {
                   toReturn = true;
                }
            }
            // user is a faculty
            else
            {
                WebService.LDAPuser InstructorInfo = WebService.Webservice.getLDAPEntryByTUID(tuid.ToString());
                string instructorEmail = InstructorInfo.mail;
                if (request.Grade_Instructor.CompareTo(instructorEmail) == 0)
                {
                    toReturn = true;
                }
            }
            return toReturn;
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
    }
}