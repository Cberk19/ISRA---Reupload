using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace ISRA.Secure
{
    public partial class Logout : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            Session.Clear();
            Session.Abandon();
            this.expireCookie();

            if (HttpContext.Current.Request.IsLocal.Equals(false))
            {
                string domain = Request.Url.Host;
                Response.Redirect("https://" + domain + "/Shibboleth.sso/Logout?return=https://" + GetFimEnvironment(domain) + ".temple.edu/idp/profile/Logout");
            }
        }

        private string GetFimEnvironment(string domain)
        {
            switch (domain)
            {
                case "np-stem.temple.edu":
                case "pre-stem.temple.edu":
                    return "np-fim";
                default:
                    return "fim";
            }
        }

        private void expireCookie()
        {
            HttpCookie user_cookie = new HttpCookie("user_cookie");
            HttpCookie tuid_cookie = new HttpCookie("tuid_cookie");
            user_cookie.Expires = DateTime.Now.AddDays(-1);
            tuid_cookie.Expires = DateTime.Now.AddDays(-1);

            Response.Cookies.Add(user_cookie);
            Response.Cookies.Add(tuid_cookie);
        }
    }
}