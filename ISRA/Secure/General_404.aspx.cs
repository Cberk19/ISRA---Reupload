using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace ISRA
{
    public partial class General_404 : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            if (Request.Cookies["user_cookie"]["user_type"].CompareTo("advisor") == 0)
            {
                this.ulAdvisorLinks.Visible = true;
                this.ulStudentLinks.Visible = false;
                this.ulFacultyLinks.Visible = false;

                this.aLogo.HRef = "Advisor_Search.aspx";
            }
            if (Request.Cookies["user_cookie"]["user_type"].CompareTo("student") == 0)
            {
                this.ulAdvisorLinks.Visible = false;
                this.ulStudentLinks.Visible = true;
                this.ulFacultyLinks.Visible = false;

                this.aLogo.HRef = "Student_Search.aspx";
            }
            if (Request.Cookies["user_cookie"]["user_type"].CompareTo("faculty") == 0)
            {
                this.ulAdvisorLinks.Visible = false;
                this.ulStudentLinks.Visible = false;
                this.ulFacultyLinks.Visible = true;

                this.aLogo.HRef = "Faculty_Search.aspx";
            }
        }
        protected void btnLogout_Click(object sender, EventArgs e)
        {
            Response.Redirect("Logout.aspx");
        }
    }
}