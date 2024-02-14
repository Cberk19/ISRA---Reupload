using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace ISRA
{
    public partial class General_LandingPage : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {
           
        }

        public void setUserTypeCookie(string value) {
            HttpCookie cookie = new HttpCookie("user_cookie");
            cookie["user_type"] = value;
            Response.Cookies.Add(cookie);
        }

        protected void btnLoginTemple_Click(object sender, EventArgs e)
        {
            // in development
            if (HttpContext.Current.Request.IsLocal.Equals(true))
            {
                Response.Redirect("Secure/Login.aspx");
            }
            else
            // in production
            {
                string domain = Request.Url.Host;
                Response.Redirect($"https://{domain}/cis4396-f01/Secure/Login.aspx");
            }
        }
    }
}