using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using ClassLibrary;
using System.Data;
using System.Data.SqlClient;
using System.Security.Cryptography;
using System.Text;

namespace ISRA.Classes
{
    public static class ISRAUtils
    {
        public static string GenerateHexColor(string input)
        {
            // Create an MD5 hash of the input string
            using (MD5 md5 = MD5.Create())
            {
                byte[] inputBytes = Encoding.UTF8.GetBytes(input);
                byte[] hashBytes = md5.ComputeHash(inputBytes);

                // Combine the hash bytes into a 24-bit color (RGB)
                int r = hashBytes[0];
                int g = hashBytes[1];
                int b = hashBytes[2];

                // Format the color values as a hex string
                string hexColor = $"#{r:X2}{g:X2}{b:X2}";

                return hexColor;
            }
        }
        public static string DarkenHexColor(string hexColor, double factor)
        {
            // Remove any leading '#' character
            hexColor = hexColor.TrimStart('#');

            if (hexColor.Length != 6)
            {
                throw new ArgumentException("Input must be a 6-character hex color code.");
            }

            // Convert the hex string to RGB components
            int red = Convert.ToInt32(hexColor.Substring(0, 2), 16);
            int green = Convert.ToInt32(hexColor.Substring(2, 2), 16);
            int blue = Convert.ToInt32(hexColor.Substring(4, 2), 16);

            // Darken the color by reducing each RGB component
            red = (int)(red * factor);
            green = (int)(green * factor);
            blue = (int)(blue * factor);

            // Ensure the values are within the valid RGB range (0-255)
            red = Math.Max(0, Math.Min(255, red));
            green = Math.Max(0, Math.Min(255, green));
            blue = Math.Max(0, Math.Min(255, blue));

            // Convert the RGB components back to a hex color string
            string darkerHexColor = string.Format("#{0:X2}{1:X2}{2:X2}", red, green, blue);

            return darkerHexColor;
        }
        public static ISRARequest GetISRAByID(int isra_id)
        {
            Connection conn = new Connection();
            DataSet ds = conn.GetDataSetUsingCmdObj(StoredProcedure.GetISRAByISRAID(isra_id));

            ISRARequest ir = new ISRARequest();

            ir.Isra_Id = int.Parse(ds.Tables[0].Rows[0]["ISRA_ID"].ToString());
            ir.Registrar = ds.Tables[0].Rows[0]["Registrar"].ToString();
            ir.Course_Number = ds.Tables[0].Rows[0]["Course_Number"].ToString();
            ir.Status = ds.Tables[0].Rows[0]["Status"].ToString();
            ir.Grade_Instructor = ds.Tables[0].Rows[0]["Grade_Instructor"].ToString();
            ir.Extra_Note = ds.Tables[0].Rows[0]["Extra_Note"].ToString();
            ir.Semester = ds.Tables[0].Rows[0]["Semester"].ToString();
            ir.TUID = int.Parse(ds.Tables[0].Rows[0]["TUID"].ToString());
            ir.Date_Submitted = ds.Tables[0].Rows[0]["Date_Submitted"].ToString();
            ir.Credit_Hours = double.Parse(ds.Tables[0].Rows[0]["Credit_Hours"].ToString());
            ir.Student_First = ds.Tables[0].Rows[0]["Student_First"].ToString();
            ir.Student_Last = ds.Tables[0].Rows[0]["Student_Last"].ToString();
            ir.Student_Email = ds.Tables[0].Rows[0]["Student_Email"].ToString();
            ir.Student_Major = ds.Tables[0].Rows[0]["Student_Major"].ToString();
            ir.Course_Plan_Url = ds.Tables[0].Rows[0]["Course_Plan_Image"].ToString();
            ir.Course_Plan = ds.Tables[0].Rows[0]["Course_Plan_Image"].ToString();
            ir.Approve_Url = ds.Tables[0].Rows[0]["Instructor_Approval_Image"].ToString();
            ir.Student_Signature = ds.Tables[0].Rows[0]["Student_Signature"].ToString();
            ir.Last_User = ds.Tables[0].Rows[0]["Last_Edited_User"].ToString();

            int parsedCRN;
            bool crnIsNum = int.TryParse(ds.Tables[0].Rows[0]["CRN"].ToString(), out parsedCRN);
            ir.CRN = crnIsNum ? parsedCRN : 0;

            int parsedSection;
            bool sectionIsNum = int.TryParse(ds.Tables[0].Rows[0]["Section_Number"].ToString(), out parsedSection);
            ir.Section_Number = sectionIsNum ? parsedSection : 0;

            switch (ir.Status.ToLower())
            {
                case "approved":
                    ir.Decision_Text = ds.Tables[0].Rows[0]["Pending_Reason_Text"].ToString();
                    break;
                case "pending":
                    ir.Decision_Text = ds.Tables[0].Rows[0]["Pending_Reason_Text"].ToString();
                    break;
                case "denied":
                    ir.Decision_Text = ds.Tables[0].Rows[0]["Denial_Reason_Text"].ToString();
                    break;
                default:
                    ir.Decision_Text = "N/A";
                    break;
            }

            return ir;
        }

        public static List<Admin> GetAllAdmins()
        {
            Connection conn = new Connection();
            DataSet ds = conn.GetDataSetUsingCmdObj(StoredProcedure.GetAllAdmins());
            DataTable dt = ds.Tables[0];

            List<Admin> adminList = new List<Admin>();

            for (int i = 0; i < dt.Rows.Count; i++)
            {
                Admin a = new Admin();
                a.Email = dt.Rows[i]["Faculty_Email"].ToString();
                a.First = dt.Rows[i]["Faculty_First_Name"].ToString();
                a.Last = dt.Rows[i]["Faculty_Last_Name"].ToString();
                a.Last_User = dt.Rows[i]["Last_Edited_User"].ToString();
                a.TUID = dt.Rows[i]["Faculty_TUID"].ToString();
                a.Receive_Emails = bool.Parse(dt.Rows[i]["Receive_Emails"].ToString());
                adminList.Add(a);
            }
            return adminList;
        }
        public static List<Admin> GetAdminsReceivingEmails()
        {
            Connection conn = new Connection();
            DataSet ds = conn.GetDataSetUsingCmdObj(StoredProcedure.GetAllAdmins());
            DataTable dt = ds.Tables[0];

            List<Admin> adminList = new List<Admin>();

            for (int i = 0; i < dt.Rows.Count; i++)
            {
                Admin a = new Admin();
                a.Email = dt.Rows[i]["Faculty_Email"].ToString();
                a.First = dt.Rows[i]["Faculty_First_Name"].ToString();
                a.Last = dt.Rows[i]["Faculty_Last_Name"].ToString();
                a.Last_User = dt.Rows[i]["Last_Edited_User"].ToString();
                a.TUID = dt.Rows[i]["Faculty_TUID"].ToString();
                a.Receive_Emails = bool.Parse(dt.Rows[i]["Receive_Emails"].ToString());
                if (a.Receive_Emails)
                {
                    adminList.Add(a);
                }
            }
            return adminList;
        }


        public static Email GetEmailByID(int id)
        {
            Connection conn = new Connection();
            DataSet ds = conn.GetDataSetUsingCmdObj(StoredProcedure.GetEmailByID(id));
            DataTable dt = ds.Tables[0];

            Email EmailTemplate = new Email();


            for (int i = 0; i < dt.Rows.Count; i++)
            {
                
                EmailTemplate.Subject = dt.Rows[i]["Subject"].ToString();
                EmailTemplate.Intro = dt.Rows[i]["Intro"].ToString();
                EmailTemplate.Additional_info = dt.Rows[i]["Additional_Info"].ToString();
                EmailTemplate.Ending = dt.Rows[i]["Ending"].ToString();
                EmailTemplate.TemplateID = Convert.ToInt32(dt.Rows[i]["Id"].ToString());
                EmailTemplate.Who_to_contact = dt.Rows[i]["Who_To_Contact"].ToString();

            }
            return EmailTemplate;
        }


        public static List<ISRARequest> GetAllISRAByTUID(int tuid)
        {
            Connection conn = new Connection();
            DataSet ds = conn.GetDataSetUsingCmdObj(StoredProcedure.GetAllISRAByTUID(tuid));
            DataTable dt = ds.Tables[0];

            List<ISRARequest> requests = new List<ISRARequest>();
            for (int i = 0; i < dt.Rows.Count; i++)
            {
                ISRARequest ir = new ISRARequest();
                ir.Isra_Id = int.Parse(dt.Rows[i]["ISRA_ID"].ToString());
                ir.Registrar = dt.Rows[i]["Registrar"].ToString();
                ir.Course_Number = dt.Rows[i]["Course_Number"].ToString();
                ir.Status = dt.Rows[i]["Status"].ToString();
                ir.Grade_Instructor = dt.Rows[i]["Grade_Instructor"].ToString();
                ir.Extra_Note = dt.Rows[i]["Extra_Note"].ToString();
                ir.Semester = dt.Rows[i]["Semester"].ToString();
                ir.TUID = int.Parse(dt.Rows[i]["TUID"].ToString());
                ir.Date_Submitted = dt.Rows[i]["Date_Submitted"].ToString();
                ir.Credit_Hours = double.Parse(dt.Rows[i]["Credit_Hours"].ToString());
                ir.Student_First = dt.Rows[i]["Student_First"].ToString();
                ir.Student_Last = dt.Rows[i]["Student_Last"].ToString();
                ir.Student_Email = dt.Rows[i]["Student_Email"].ToString();
                ir.Student_Major = dt.Rows[i]["Student_Major"].ToString();
                ir.Course_Plan_Url = dt.Rows[i]["Course_Plan_Image"].ToString();
                ir.Course_Plan = dt.Rows[i]["Course_Plan_Text"].ToString();
                ir.Approve_Url = dt.Rows[i]["Instructor_Approval_Image"].ToString();
                ir.Student_Signature = dt.Rows[i]["Student_Signature"].ToString();
                ir.Last_User = dt.Rows[i]["Last_Edited_User"].ToString();

                int parsedCRN;
                bool crnIsNum = int.TryParse(dt.Rows[i]["CRN"].ToString(), out parsedCRN);
                ir.CRN = crnIsNum ? parsedCRN : 0;

                int parsedSection;
                bool sectionIsNum = int.TryParse(dt.Rows[i]["Section_Number"].ToString(), out parsedSection);
                ir.Section_Number = sectionIsNum ? parsedSection : 0;

                switch (ir.Status.ToLower())
                {
                    case "pending":
                        ir.Decision_Text = dt.Rows[i]["Pending_Reason_Text"].ToString();
                        break;
                    case "denied":
                        ir.Decision_Text = dt.Rows[i]["Denial_Reason_Text"].ToString();
                        break;
                    default:
                        ir.Decision_Text = "N/A";
                        break;
                }
                requests.Add(ir);
            }
            return requests;
        }
        public static List<ISRARequest> GetAllISRAByRegistrar()
        {
            Connection conn = new Connection();
            DataSet ds = conn.GetDataSetUsingCmdObj(StoredProcedure.GetAllISRAByRegistrar());
            DataTable dt = ds.Tables[0];

            List<ISRARequest> requests = new List<ISRARequest>();
            for (int i = 0; i < dt.Rows.Count; i++)
            {
                ISRARequest ir = new ISRARequest();
                ir.Isra_Id = int.Parse(dt.Rows[i]["ISRA_ID"].ToString());
                ir.Registrar = dt.Rows[i]["Registrar"].ToString();
                ir.Course_Number = dt.Rows[i]["Course_Number"].ToString();
                ir.Status = dt.Rows[i]["Status"].ToString();
                ir.Grade_Instructor = dt.Rows[i]["Grade_Instructor"].ToString();
                ir.Extra_Note = dt.Rows[i]["Extra_Note"].ToString();
                ir.Semester = dt.Rows[i]["Semester"].ToString();
                ir.TUID = int.Parse(dt.Rows[i]["TUID"].ToString());
                ir.Date_Submitted = dt.Rows[i]["Date_Submitted"].ToString();
                ir.Credit_Hours = double.Parse(dt.Rows[i]["Credit_Hours"].ToString());
                ir.Student_First = dt.Rows[i]["Student_First"].ToString();
                ir.Student_Last = dt.Rows[i]["Student_Last"].ToString();
                ir.Student_Email = dt.Rows[i]["Student_Email"].ToString();
                ir.Student_Major = dt.Rows[i]["Student_Major"].ToString();
                ir.Course_Plan_Url = dt.Rows[i]["Course_Plan_Image"].ToString();
                ir.Course_Plan = dt.Rows[i]["Course_Plan_Text"].ToString();
                ir.Approve_Url = dt.Rows[i]["Instructor_Approval_Image"].ToString();
                ir.Student_Signature = dt.Rows[i]["Student_Signature"].ToString();
                ir.Last_User = dt.Rows[i]["Last_Edited_User"].ToString();

                int parsedCRN;
                bool crnIsNum = int.TryParse(dt.Rows[i]["CRN"].ToString(), out parsedCRN);
                ir.CRN = crnIsNum ? parsedCRN : 0;

                int parsedSection;
                bool sectionIsNum = int.TryParse(dt.Rows[i]["Section_Number"].ToString(), out parsedSection);
                ir.Section_Number = sectionIsNum ? parsedSection : 0;

                switch (ir.Status.ToLower())
                {
                    case "pending":
                        ir.Decision_Text = dt.Rows[i]["Pending_Reason_Text"].ToString();
                        break;
                    case "denied":
                        ir.Decision_Text = dt.Rows[i]["Denial_Reason_Text"].ToString();
                        break;
                    default:
                        ir.Decision_Text = "N/A";
                        break;
                }
                requests.Add(ir);
            }
            return requests;
        }
        public static List<ISRARequest> GetAllISRAByInstructor(string instructorEmail)
        {
            Connection conn = new Connection();
            DataSet ds = conn.GetDataSetUsingCmdObj(StoredProcedure.GetAllISRAByInstructor(instructorEmail));
            DataTable dt = ds.Tables[0];

            List<ISRARequest> requests = new List<ISRARequest>();
            for (int i = 0; i < dt.Rows.Count; i++)
            {
                ISRARequest ir = new ISRARequest();
                ir.Isra_Id = int.Parse(dt.Rows[i]["ISRA_ID"].ToString());
                ir.Registrar = dt.Rows[i]["Registrar"].ToString();
                ir.Course_Number = dt.Rows[i]["Course_Number"].ToString();
                ir.Status = dt.Rows[i]["Status"].ToString();
                ir.Grade_Instructor = dt.Rows[i]["Grade_Instructor"].ToString();
                ir.Extra_Note = dt.Rows[i]["Extra_Note"].ToString();
                ir.Semester = dt.Rows[i]["Semester"].ToString();
                ir.TUID = int.Parse(dt.Rows[i]["TUID"].ToString());
                ir.Date_Submitted = dt.Rows[i]["Date_Submitted"].ToString();
                ir.Credit_Hours = double.Parse(dt.Rows[i]["Credit_Hours"].ToString());
                ir.Student_First = dt.Rows[i]["Student_First"].ToString();
                ir.Student_Last = dt.Rows[i]["Student_Last"].ToString();
                ir.Student_Email = dt.Rows[i]["Student_Email"].ToString();
                ir.Student_Major = dt.Rows[i]["Student_Major"].ToString();
                ir.Course_Plan_Url = dt.Rows[i]["Course_Plan_Image"].ToString();
                ir.Course_Plan = dt.Rows[i]["Course_Plan_Text"].ToString();
                ir.Approve_Url = dt.Rows[i]["Instructor_Approval_Image"].ToString();
                ir.Student_Signature = dt.Rows[i]["Student_Signature"].ToString();
                ir.Last_User = dt.Rows[i]["Last_Edited_User"].ToString();

                int parsedCRN;
                bool crnIsNum = int.TryParse(dt.Rows[i]["CRN"].ToString(), out parsedCRN);
                ir.CRN = crnIsNum ? parsedCRN : 0;

                int parsedSection;
                bool sectionIsNum = int.TryParse(dt.Rows[i]["Section_Number"].ToString(), out parsedSection);
                ir.Section_Number = sectionIsNum ? parsedSection : 0;

                switch (ir.Status.ToLower())
                {
                    case "pending":
                        ir.Decision_Text = dt.Rows[i]["Pending_Reason_Text"].ToString();
                        break;
                    case "denied":
                        ir.Decision_Text = dt.Rows[i]["Denial_Reason_Text"].ToString();
                        break;
                    default:
                        ir.Decision_Text = "N/A";
                        break;
                }
                requests.Add(ir);
            }
            return requests;
        }
        public static int ReceiveEmails(string adminEmail, bool boxChecked)
        {
            Connection conn = new Connection();
            SqlCommand command = StoredProcedure.ReceiveEmails(adminEmail, boxChecked);
            int status = conn.DoUpdateUsingCmdObj(command);
            return status;
        }

        public static string AppendToFileName(int tuid)
        {
            List<ISRARequest> requests = ISRAUtils.GetAllISRAByTUID(tuid);
            int requestCount;
            if (requests.Count == 0)
            {
                requestCount = 1;
            }
            requestCount = requests.Count + 1;
            return $"_{tuid}_{requestCount}";
        }
    }
}