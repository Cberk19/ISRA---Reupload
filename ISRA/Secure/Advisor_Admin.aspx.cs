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

namespace ISRA
{
    public partial class Advisor_Admin : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            // redirect to landing if nobody logged in
            if (Request.Cookies["user_cookie"] == null)
            {
                Response.Redirect("../General_LandingPage.aspx");
            } else
            {
                // redirect 404 if not correct user
                if (Request.Cookies["user_cookie"]["user_type"].CompareTo("advisor") != 0)
                {
                    Response.Redirect("General_404.aspx");
                }
            }

            Connection conn = new Connection();
            SqlCommand cmd = StoredProcedure.GetEmailByID(ddStatus.SelectedIndex + 1);
            DataRow ds = conn.GetDataSetUsingCmdObj(cmd).Tables[0].Rows[0];

            string subject = ds["Subject"].ToString();
            string intro = ds["Intro"].ToString();
            string addy = ds["Additional_Info"].ToString();
            string ending = ds["Ending"].ToString();
            string contact = ds["Who_To_Contact"].ToString();

            if (!IsPostBack)
            {
                txtSubject.Text = subject;
                taIntro.InnerText = intro;
                taAdditional.InnerText = addy;
                taEnding.InnerText = ending;
                txtContact.Text = contact;

                List<Admin> admins = ISRAUtils.GetAllAdmins();
                this.displayAdmins(admins);
            }

            subjectPreview.InnerHtml = txtSubject.Text;
            introPreview.InnerHtml = taIntro.InnerText;
            addyPreview.InnerHtml = taAdditional.InnerText;
            endingPreview.InnerHtml = taEnding.InnerText;
            contactPreview.InnerHtml = txtContact.Text;
        }
        protected void adminAdd_Click(Object sender, EventArgs e)
        {
            WebService.LDAPuser currentUser = WebService.Webservice.getLDAPEntryByTUID(Request.Cookies["tuid_cookie"].Value.ToString());
            string user = currentUser.givenName + currentUser.sn;

            Connection conn = new Connection();
            SqlCommand cmd = StoredProcedure.InsertAdmin(tuid.Value, email.Value, fname.Value, lname.Value, user);

            conn.DoUpdateUsingCmdObj(cmd);

            this.backgroundDim.Visible = false;
            this.adminPanel.Visible = false;

            List<Admin> admins = ISRAUtils.GetAllAdmins();
            this.displayAdmins(admins);
        }

        protected void SaveEmailTemplate_Click(Object sender, EventArgs e)
        {
            Connection conn = new Connection();
            SqlCommand cmd = StoredProcedure.UpdateEmailByID(ddStatus.SelectedIndex + 1, txtSubject.Text, taIntro.InnerText, taAdditional.InnerText, taEnding.InnerText, txtContact.Text, Session["Full_Name"].ToString());
            int status = conn.DoUpdateUsingCmdObj(cmd);

            if (status > 0)
            {
                this.lblEmailTemplateAlert.CssClass = "alert alert-success d-inline-block mb-3";
                this.lblEmailTemplateAlert.Text = "Saved successfully!";
            } else
            {
                this.lblEmailTemplateAlert.CssClass = "alert alert-danger d-inline-block mb-3";
                this.lblEmailTemplateAlert.Text = "Error: could not save to database.";
            }
        }

        protected void btnAddAdmin_Click(Object sender, EventArgs e)
        {
            this.backgroundDim.Visible = true;
            this.adminPanel.Visible = true;
        }

        protected void btnModalClose_Click(Object sender, EventArgs e)
        {
            this.backgroundDim.Visible = false;
            this.adminPanel.Visible = false;
        }

        protected void btnAddUsers_Click(object sender, EventArgs e)
        {
            this.btnEmailTemplate.CssClass = "px-4 border-0 text-start fw-bold py-3 w-100";
            this.btnAddUsers.CssClass = "add-user px-4 border-0 text-start fw-bold py-3 w-100";

            this.emailTemplateView.Visible = false;
            this.addUsersView.Visible = true;
        }

        protected void btnEmailTemplate_Click(object sender, EventArgs e)
        {
            this.btnAddUsers.CssClass = "px-4 border-0 text-start fw-bold py-3 w-100";
            this.btnEmailTemplate.CssClass = "add-user px-4 border-0 text-start fw-bold py-3 w-100";

            this.emailTemplateView.Visible = true;
            this.addUsersView.Visible = false;
        }

        private void displayAdmins(List<Admin> admins)
        {
            this.gvAdmins.DataSource = admins;
            this.gvAdmins.DataBind();
        }
        protected void btnLogout_Click(object sender, EventArgs e)
        {
            Response.Redirect("Logout.aspx");
        }

        protected void changeValues(Object sender, EventArgs e)
        {
            if (ddStatus.SelectedIndex == 0)
            {
                this.emailTypeExplanation1.Visible = true;
                this.emailTypeExplanation2.Visible = false;
                this.emailTypeExplanation3.Visible = false;
            }
            if (ddStatus.SelectedIndex == 1)
            {
                this.emailTypeExplanation1.Visible = false;
                this.emailTypeExplanation2.Visible = true;
                this.emailTypeExplanation3.Visible = false;
            }
            if (ddStatus.SelectedIndex == 2)
            {
                this.emailTypeExplanation1.Visible = false;
                this.emailTypeExplanation2.Visible = false;
                this.emailTypeExplanation3.Visible = true;
            }

            Connection conn = new Connection();
            SqlCommand cmd = StoredProcedure.GetEmailByID(ddStatus.SelectedIndex + 1);
            DataRow ds = conn.GetDataSetUsingCmdObj(cmd).Tables[0].Rows[0];

            string subject = ds["Subject"].ToString();
            string intro = ds["Intro"].ToString();
            string addy = ds["Additional_Info"].ToString();
            string ending = ds["Ending"].ToString();
            string contact = ds["Who_To_Contact"].ToString();

            txtSubject.Text = subject;
            taIntro.InnerText = intro;
            taAdditional.InnerText = addy;
            taEnding.InnerText = ending;
            txtContact.Text = contact;

            subjectPreview.InnerHtml = subject;
            introPreview.InnerHtml = intro;
            addyPreview.InnerHtml = addy;
            endingPreview.InnerHtml = ending;
            contactPreview.InnerHtml = contact;
        }

        protected void gvAdmins_RowCommand(Object sender, GridViewCommandEventArgs e)
        {
            if (e.CommandName == "Save")
            {
                GridViewRow gvr = (GridViewRow)((Button)e.CommandSource).NamingContainer;
                string adminEmail = gvr.Cells[0].Text;
                CheckBox chkReceiveEmails = (CheckBox)gvr.FindControl("chkReceiveEmails");
                bool shouldReceiveEmails = chkReceiveEmails.Checked;

                int status = ISRAUtils.ReceiveEmails(adminEmail, shouldReceiveEmails);
                if (status > 0)
                {
                    if (shouldReceiveEmails)
                    {
                        this.lblAdminAlert.CssClass = "alert alert-success d-inline-block";
                        this.lblAdminAlert.Text = $"{adminEmail} will now receive emails";
                    } else
                    {
                        this.lblAdminAlert.CssClass = "alert alert-primary d-inline-block";
                        this.lblAdminAlert.Text = $"{adminEmail} will not receive emails";
                    }
                } else
                {
                    this.lblAdminAlert.CssClass = "alert alert-danger d-inline-block";
                    this.lblAdminAlert.Text = $"Error: could not update database";
                }
            }
        }
    }
}