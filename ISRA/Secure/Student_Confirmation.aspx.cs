using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace ISRA
{
    public partial class Student_Confirmation : System.Web.UI.Page
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
            }
        }
        protected void btnLogout_Click(object sender, EventArgs e)
        {
            Response.Redirect("Logout.aspx");
        }
    }
}