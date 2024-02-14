using System;
using System.Collections.Specialized;
using System.Data;
using System.Data.SqlClient;
using System.Net.Mail;
using System.Web.UI.WebControls;

namespace ClassLibrary
{
    public class Email
    {
        /// <summary>
        /// NP-STEM & PRE-STEM have been white-listed by ITS so you do not need to provide any credentials
        /// to send an email. Also, in order to test emails your application will need to be in your team's live 
        /// directory and test on the browser. You cannot send emails by running your project locally in Visual Studio.
        /// </summary>
       
        private string subject;
        private string intro;
        private string additional_info;
        private string ending;
        private string who_to_contact;
        private DateTime last_edited_time;
        private string last_edited_user;
        private int templateID;


        /*Getters and Setters*/
       
        public String Intro
        {
            get { return this.intro; }
            set { this.intro = value; }
        }
        public String Subject
        {
            get { return this.subject; }
            set { this.subject = value; }
        }
        public String Additional_info
        {
            get { return this.additional_info; }
            set { this.additional_info = value; }
        }
        public string Ending
        {
            get { return this.ending; }
            set { this.ending = value; }
        }
        public string Who_to_contact
        {
            get { return this.who_to_contact; }
            set { this.who_to_contact = value; }
        }
        public DateTime Last_Edited_time
        {
            get { return this.last_edited_time; }
            set { this.last_edited_time = value; }
        }
        public string last_Edited_user
        {
            get { return this.last_edited_user; }
            set { this.last_edited_user = value; }
        }
        public int TemplateID
        {
            get { return this.templateID; }
            set { this.templateID = value; }
        }

        //Default Constructor
        public Email()
        {

        }


        //Constructor for email template

        public Email(string subject, string intro, string additional_info, string ending, string who_to_contact, DateTime last_edited_time, string last_edited_user, int templateID)
        {
            this.Subject = subject;
            this.Intro = intro;
            this.Additional_info = additional_info;
            this.Who_to_contact = who_to_contact;
            this.Last_Edited_time = last_edited_time;
            this.last_Edited_user = last_edited_user;
            this.TemplateID = templateID;
        }

        /*My customizable HTML email methods*/
        //public void Send_Invoice(String TU_ID, String Unique_ID)
        //{
        //    /*Getting Database Information*/
        //    SqlCommand objCommand = new SqlCommand();
        //    objCommand.CommandType = CommandType.StoredProcedure;
        //    objCommand.CommandText = "Email_Select_ByID";
        //    SqlParameter Email_ID = new SqlParameter("@Email_ID", 1);
        //    objCommand.Parameters.Add(Email_ID);
        //    DataSet ds = null;

        //    using (Connection conn = new Connection())
        //    {
        //        ds = conn.GetDataSetUsingCmdObj(objCommand);
        //    }

        //    /*Getting User Information*/
        //    WebService.LDAPuser result = WebService.Webservice.getLDAPEntryByTUID(TU_ID);

        //    /*Sending Email with customized content*/
        //    try
        //    {
        //        String First_Name = result.cn;
        //        String Recipient = result.mail;

        //        MailDefinition md = new MailDefinition();
        //        md.IsBodyHtml = true;
        //        md.From = "noreply@temple.edu";
        //        md.Subject = ds.Tables[0].Rows[0]["Email_Subject"].ToString();
        //        string body = ds.Tables[0].Rows[0]["Email_Content"].ToString();

        //        ListDictionary replacements = new ListDictionary();
        //        replacements.Add("{Full_Name}", First_Name);
        //        replacements.Add("{Query_ID}", Unique_ID);

        //        using (MailMessage msg = md.CreateMailMessage(Recipient, replacements, body, new System.Web.UI.Control()))
        //        {
        //            SmtpClient client = new SmtpClient(this.mailHost);
        //            client.Send(msg);
        //        }
        //    }
        //    catch (Exception ex)
        //    {
        //        throw ex;
        //    }
        //}


        //public void Send_Receipt(String TU_ID, String Item_Name, String Total_Cost, String Unique_ID)
        //{
        //    /*Getting Database Information*/
        //    SqlCommand objCommand = new SqlCommand();
        //    objCommand.CommandType = CommandType.StoredProcedure;
        //    objCommand.CommandText = "Email_Select_ByID";
        //    SqlParameter Email_ID = new SqlParameter("@Email_ID", 2);
        //    objCommand.Parameters.Add(Email_ID);
        //    DataSet ds = null;

        //    using (Connection conn = new Connection())
        //    {
        //        ds = conn.GetDataSetUsingCmdObj(objCommand);
        //    }

        //    /*Getting User Information*/
        //    WebService.LDAPuser result = WebService.Webservice.getLDAPEntryByTUID(TU_ID);

        //    /*Sending Email with customized content*/
        //    try
        //    {
        //        String First_Name = result.cn;
        //        String Recipient = result.mail;

        //        MailDefinition md = new MailDefinition();
        //        md.IsBodyHtml = true;
        //        md.From = "noreply@temple.edu";
        //        md.Subject = ds.Tables[0].Rows[0]["Email_Subject"].ToString(); ;
        //        string body = ds.Tables[0].Rows[0]["Email_Content"].ToString();

        //        ListDictionary replacements = new ListDictionary();
        //        replacements.Add("{Full_Name}", First_Name);
        //        replacements.Add("{Item_Name}", Item_Name);
        //        replacements.Add("{Total_Cost}", Total_Cost);
        //        replacements.Add("{Query_ID}", Unique_ID);

        //        using (MailMessage msg = md.CreateMailMessage(Recipient, replacements, body, new System.Web.UI.Control()))
        //        {
        //            SmtpClient client = new SmtpClient(this.mailHost);
        //            client.Send(msg);
        //        }
        //    }
        //    catch (Exception ex)
        //    {
        //        throw ex;
        //    }
        //}


        //public void Send_Refund_Accepted(String TU_ID, String Item_Name, String Total_Cost, String Notes)
        //{
        //    /*Getting Database Information*/
        //    SqlCommand objCommand = new SqlCommand();
        //    objCommand.CommandType = CommandType.StoredProcedure;
        //    objCommand.CommandText = "Email_Select_ByID";
        //    SqlParameter Email_ID = new SqlParameter("@Email_ID", 3);
        //    objCommand.Parameters.Add(Email_ID);
        //    DataSet ds = null;

        //    using (Connection conn = new Connection())
        //    {
        //        ds = conn.GetDataSetUsingCmdObj(objCommand);
        //    }

        //    /*Getting User Information*/
        //    WebService.LDAPuser result = WebService.Webservice.getLDAPEntryByTUID(TU_ID);

        //    /*Sending Email with customized content*/
        //    try
        //    {
        //        String First_Name = result.cn;
        //        String Recipient = result.mail;

        //        MailDefinition md = new MailDefinition();
        //        md.IsBodyHtml = true;
        //        md.From = "noreply@temple.edu";
        //        md.Subject = ds.Tables[0].Rows[0]["Email_Subject"].ToString(); ;
        //        string body = ds.Tables[0].Rows[0]["Email_Content"].ToString();

        //        ListDictionary replacements = new ListDictionary();
        //        replacements.Add("{Full_Name}", First_Name);
        //        replacements.Add("{Item_Name}", Item_Name);
        //        replacements.Add("{Total_Cost}", Total_Cost);
        //        replacements.Add("{Notes}", Notes);

        //        using (MailMessage msg = md.CreateMailMessage(Recipient, replacements, body, new System.Web.UI.Control()))
        //        {
        //            SmtpClient client = new SmtpClient(this.mailHost);
        //            client.Send(msg);
        //        }
        //    }
        //    catch (Exception ex)
        //    {
        //        throw ex;
        //    }
        //}


        //public void Send_Refund_Rejected(String TU_ID, String Item_Name, String Notes)
        //{
        //    /*Getting Database Information*/
        //    SqlCommand objCommand = new SqlCommand();
        //    objCommand.CommandType = CommandType.StoredProcedure;
        //    objCommand.CommandText = "Email_Select_ByID";
        //    SqlParameter Email_ID = new SqlParameter("@Email_ID", 4);
        //    objCommand.Parameters.Add(Email_ID);
        //    DataSet ds = null;

        //    using (Connection conn = new Connection())
        //    {
        //        ds = conn.GetDataSetUsingCmdObj(objCommand);
        //    }

        //    /*Getting User Information*/
        //    WebService.LDAPuser result = WebService.Webservice.getLDAPEntryByTUID(TU_ID);

        //    /*Sending Email with customized content*/
        //    try
        //    {
        //        String First_Name = result.cn;
        //        String Recipient = result.mail;

        //        MailDefinition md = new MailDefinition();
        //        md.IsBodyHtml = true;
        //        md.From = "noreply@temple.edu";
        //        md.Subject = ds.Tables[0].Rows[0]["Email_Subject"].ToString(); ;
        //        string body = ds.Tables[0].Rows[0]["Email_Content"].ToString();

        //        ListDictionary replacements = new ListDictionary();
        //        replacements.Add("{Full_Name}", First_Name);
        //        replacements.Add("{Item_Name}", Item_Name);
        //        replacements.Add("{Notes}", Notes);

        //        using (MailMessage msg = md.CreateMailMessage(Recipient, replacements, body, new System.Web.UI.Control()))
        //        {
        //            SmtpClient client = new SmtpClient(this.mailHost);
        //            client.Send(msg);
        //        }
        //    }
        //    catch (Exception ex)
        //    {
        //        throw ex;
        //    }
        //}


    }
}