using System;
using System.Text;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using ISRA.Classes;
using System.Configuration;
using ClassLibrary;

namespace ISRA.Secure
{
    public partial class Login : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            string tuid = string.Empty;

            // during local or development
            if (HttpContext.Current.Request.IsLocal.Equals(true))
            {
                //tuid = "915898044"; // student's tuid
                tuid = "915597611"; // advisor's tuid
                //tuid = "888000088"; // faculty's tuid
            }
            else
            // in production
            {
                tuid = GetShibbolethHeaderAttributes();
            }
            setTUIDCookie(tuid);
            GetUserInformation(tuid);
        }

        // Retrieve user information from Shibboleth headers
        // return tuid
        protected string GetShibbolethHeaderAttributes()
        {
            string employeeNumber = Request.Headers["employeeNumber"]; //Use this to retrieve the user's information via the web services  
            Session["SSO_Attribute_employeeNumber"] = employeeNumber;


            // The following 4 lines of code are also attributes returned via Shibboleth, but can also be retrieved for ITS soap web services
            Session["SSO_Attribute_affiliation"] = Request.Headers["affiliation"];
            Session["SSO_Attribute_eduPersonPrincipalName"] = Request.Headers["eppn"];
            Session["SSO_Attribute_mail"] = Request.Headers["mail"];
            Session["SSO_Attribute_remote_user"] = Request.Headers["remoteuser"];


            //This is for display purposes only so you can see what is returned in the request headers and not needed for application development
            Session["HTTP_Request_Headers"] = RetrieveHTTPHeaders();

            return employeeNumber;
        }
        private string RetrieveHTTPHeaders()
        {
            StringBuilder headers = new StringBuilder();
            foreach (var key in Request.Headers.AllKeys)
                headers.Append(key + "=" + Request.Headers[key] + "\n");

            return headers.ToString();
        }

        // Use (TUid) to retrieve information about the user from the web services.
        protected void GetUserInformation(string tuid)
        {
            if (!string.IsNullOrWhiteSpace(tuid))
            {
                /*Security Session Variable*/
                Session["Authenticated"] = true;

                /* Requesting user's LDAP information via Web Service */
                WebService.LDAPuser Temple_Information = WebService.Webservice.getLDAPEntryByTUID(tuid);
                

                /* Checking we received something from Web Services*/
                if (Temple_Information != null)
                {
                    /*Populating the Session Object with the user's information*/
                    Session["TU_ID"] = Temple_Information.templeEduID;
                    Session["First_Name"] = Temple_Information.givenName;
                    Session["Last_Name"] = Temple_Information.sn;
                    Session["Email"] = Temple_Information.mail;
                    Session["Title"] = Temple_Information.title;
                    Session["Affiliation_Primary"] = Temple_Information.eduPersonPrimaryAffiliation;
                    Session["Affiliation_Secondary"] = Temple_Information.eduPersonAffiliation;
                    Session["Full_Name"] = Temple_Information.cn;

                    /* If the user is a student, we can request academic information via the Web Service */
                    WebService.StudentObj Student_Information = WebService.Webservice.getStudentInfo(Temple_Information.templeEduID);

                    /* Checking we received something from Web Service and then adding information to the Session Object*/
                    if (Student_Information != null)
                    {
                        Session["School"] = Student_Information.school;
                        Session["Major_1"] = Student_Information.major1;
                        Session["Major_2"] = Student_Information.major2;
                    }
                }


                //database call

                /*Successful Login - Allowed to be redirected to Home.aspx*/
                this.redirectUser(Temple_Information);
            }
            else
            {
                //Error: Couldn't retrieve employeeNumber from request header
                Server.Transfer("General_404.aspx");
            }
        }

        // manage redirects
        private void redirectUser(WebService.LDAPuser templeInfo)
        {
            // is user advisor / admin?
            List<Admin> adminList = ISRAUtils.GetAllAdmins();
            foreach (Admin admin in adminList)
            {
                if (admin.TUID.CompareTo(templeInfo.templeEduID) == 0)
                {
                    setUserTypeCookie("advisor");
                    Response.Redirect("Advisor_Search.aspx");
                }
            }
            // is user student?
            if (templeInfo.eduPersonPrimaryAffiliation.Contains("student") && templeInfo.eduPersonAffiliation.Contains("student"))
            {
                setUserTypeCookie("student");
                Response.Redirect("Student_Search.aspx");
            }
            else
            // otherwise user has faculty privileges
            {
                setUserTypeCookie("faculty");
                Response.Redirect("FacultyMember_Search.aspx");
            }
        }
        public void setUserTypeCookie(string userType)
        {
            HttpCookie cookie = new HttpCookie("user_cookie");
            cookie["user_type"] = userType;
            cookie.Expires = DateTime.MaxValue;
            Response.Cookies.Add(cookie);
        }

        public void setTUIDCookie(string value)
        {
            HttpCookie cookie = new HttpCookie("tuid_cookie");
            cookie.Value = value;
            cookie.Expires = DateTime.MaxValue;
            Response.Cookies.Add(cookie);
        }
    }
}