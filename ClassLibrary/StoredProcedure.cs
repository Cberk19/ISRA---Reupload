using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Data;
using System.Data.SqlClient;

namespace ClassLibrary
{
    public static class StoredProcedure
    {

        //Insert new record into ISRA table
        public static SqlCommand InsertISRA(ISRARequest application)
        {
            SqlCommand command = new SqlCommand("dbo.InsertISRA");
            command.Parameters.Add("Registrar", SqlDbType.VarChar).Value = application.Registrar;
            command.Parameters.Add("Course_Number", SqlDbType.VarChar).Value = application.Course_Number;
            command.Parameters.Add("Status", SqlDbType.VarChar).Value = application.Status;
            command.Parameters.Add("Grade_Instructor", SqlDbType.VarChar).Value = application.Grade_Instructor;
            command.Parameters.Add("Extra_Note", SqlDbType.VarChar).Value = application.Extra_Note;
            command.Parameters.Add("Semester", SqlDbType.VarChar).Value = application.Semester;
            command.Parameters.Add("TUID", SqlDbType.Int).Value = application.TUID;
            command.Parameters.Add("Credit_Hours", SqlDbType.VarChar).Value = application.Credit_Hours;
            command.Parameters.Add("Student_First", SqlDbType.VarChar).Value = application.Student_First;
            command.Parameters.Add("Student_Last", SqlDbType.VarChar).Value = application.Student_Last;
            command.Parameters.Add("Student_Email", SqlDbType.VarChar).Value = application.Student_Email;
            command.Parameters.Add("Student_Major", SqlDbType.VarChar).Value = application.Student_Major;
            command.Parameters.Add("Course_Plan_Image", SqlDbType.VarChar).Value = application.Course_Plan_Url;
            command.Parameters.Add("Course_Plan", SqlDbType.VarChar).Value = application.Course_Plan;
            command.Parameters.Add("Instructor_Approval_Image", SqlDbType.VarChar).Value = application.Approve_Url;
            command.Parameters.Add("Student_Signature", SqlDbType.VarChar).Value = application.Student_Signature;
            command.Parameters.Add("Last_Edited_User", SqlDbType.VarChar).Value = application.Last_User;
            command.CommandType = CommandType.StoredProcedure;
            return command;
        }
        public static SqlCommand InsertAdmin(string tuid, string email, string  fname, string lname, string leu)
        {
            SqlCommand command = new SqlCommand("dbo.InsertAdmin");
            command.Parameters.Add("tuid", SqlDbType.Int).Value = int.Parse(tuid);
            command.Parameters.Add("faculty_email", SqlDbType.VarChar).Value = email;
            command.Parameters.Add("faculty_first", SqlDbType.VarChar).Value = fname;
            command.Parameters.Add("faculty_last", SqlDbType.VarChar).Value = lname;
            command.Parameters.Add("last_edited_user", SqlDbType.VarChar).Value = leu;
            command.CommandType = CommandType.StoredProcedure;
            return command;
        }
        // update a ISRA request with pending status
        public static SqlCommand PendingRequest(ISRARequest application)
        {
            SqlCommand command = new SqlCommand("dbo.PendingRequest");
            command.Parameters.Add("status", SqlDbType.VarChar).Value = application.Status;
            command.Parameters.Add("isra_id", SqlDbType.Int).Value = application.Isra_Id;
            command.Parameters.Add("pending_reason_text", SqlDbType.VarChar).Value = application.Decision_Text;
            command.Parameters.Add("last_edited_user", SqlDbType.VarChar).Value = application.Last_User;
            command.CommandType = CommandType.StoredProcedure;
            return command;
        }
        // update a ISRA request with denied status
        public static SqlCommand DenyRequest(ISRARequest application)
        {
            SqlCommand command = new SqlCommand("dbo.DenyRequest");
            command.Parameters.Add("status", SqlDbType.VarChar).Value = application.Status;
            command.Parameters.Add("isra_id", SqlDbType.Int).Value = application.Isra_Id;
            command.Parameters.Add("denial_reason_text", SqlDbType.VarChar).Value = application.Decision_Text;
            command.Parameters.Add("last_edited_user", SqlDbType.VarChar).Value = application.Last_User;
            command.CommandType = CommandType.StoredProcedure;
            return command;
        }
        // update a ISRA request with approved status
        public static SqlCommand ApproveRequest(ISRARequest application)
        {
            SqlCommand command = new SqlCommand("dbo.ApproveRequest");
            command.Parameters.Add("status", SqlDbType.VarChar).Value = application.Status;
            command.Parameters.Add("isra_id", SqlDbType.Int).Value = application.Isra_Id;
            command.Parameters.Add("approve_reason_text", SqlDbType.VarChar).Value = application.Decision_Text;
            command.Parameters.Add("last_edited_user", SqlDbType.VarChar).Value = application.Last_User;
            command.Parameters.Add("crn", SqlDbType.VarChar).Value = application.CRN;
            command.Parameters.Add("section", SqlDbType.VarChar).Value = application.Section_Number;
            command.CommandType = CommandType.StoredProcedure;
            return command;
        }

        //Insert a new admin into the Admin table
        public static SqlCommand InsertAdmin(Admin admin)
        {
            SqlCommand command = new SqlCommand("dbo.InsertAdmin");
            command.Parameters.Add("faculty_email", SqlDbType.VarChar).Value = admin.Email;
            command.Parameters.Add("faculty_first", SqlDbType.VarChar).Value = admin.First;
            command.Parameters.Add("faculty_last", SqlDbType.VarChar).Value = admin.Last;
            command.Parameters.Add("last_edited_user", SqlDbType.VarChar).Value = admin.Last_User;
            command.CommandType = CommandType.StoredProcedure;
            return command;
        }

        //Delete an admin from the Admin table
        public static SqlCommand DeleteAdmin(Admin admin)
        {
            SqlCommand command = new SqlCommand("dbo.DeleteAdmin");
            command.Parameters.Add("faculty_email", SqlDbType.VarChar).Value = admin.Email;
            command.CommandType = CommandType.StoredProcedure;
            return command;
        }

        //Insert a new course into the Course Table
        public static SqlCommand InsertCourse(Course course)
        {
            SqlCommand command = new SqlCommand("dbo.InsertCourse");
            command.Parameters.Add("course_number", SqlDbType.VarChar).Value = course.Course_Number;
            command.Parameters.Add("title", SqlDbType.VarChar).Value = course.Title;
            command.Parameters.Add("gpa", SqlDbType.Float).Value = course.Gpa;
            command.Parameters.Add("note", SqlDbType.VarChar).Value = course.Note;
            command.Parameters.Add("pre_reqs", SqlDbType.VarChar).Value = course.Pre_Reqs;
            command.Parameters.Add("min_credits", SqlDbType.Int).Value = course.Min_Credits;
            command.Parameters.Add("max_credits", SqlDbType.Int).Value = course.Max_Credits;
            command.Parameters.Add("last_edited_user", SqlDbType.VarChar).Value = course.Last_User;
            command.CommandType = CommandType.StoredProcedure;
            return command;
        }

        //Delete a course from the Course Table
        public static SqlCommand DeleteCourse(Course course)
        {
            SqlCommand command = new SqlCommand("dbo.DeleteCourse");
            command.Parameters.Add("course_number", SqlDbType.VarChar).Value = course.Course_Number;
            command.CommandType = CommandType.StoredProcedure;
            return command;
        }

        //Update an existing course in the Course Table
        public static SqlCommand UpdateCourse(Course course)
        {
            SqlCommand command = new SqlCommand("dbo.UpdateCourse");
            command.Parameters.Add("course_number", SqlDbType.VarChar).Value = course.Course_Number;
            command.Parameters.Add("title", SqlDbType.VarChar).Value = course.Title;
            command.Parameters.Add("gpa", SqlDbType.Float).Value = course.Gpa;
            command.Parameters.Add("note", SqlDbType.VarChar).Value = course.Note;
            command.Parameters.Add("pre_reqs", SqlDbType.VarChar).Value = course.Pre_Reqs;
            command.Parameters.Add("min_credits", SqlDbType.Int).Value = course.Min_Credits;
            command.Parameters.Add("max_credits", SqlDbType.Int).Value = course.Max_Credits;
            command.Parameters.Add("last_edited_user", SqlDbType.VarChar).Value = course.Last_User;
            command.CommandType = CommandType.StoredProcedure;
            return command;
        }

        //Insert a new department into the Department table
        public static SqlCommand InsertDepartment(Department department)
        {
            SqlCommand command = new SqlCommand("dbo.InsertDepartment");
            command.Parameters.Add("dept_abbreviated", SqlDbType.VarChar).Value = department.Abbreviated;
            command.Parameters.Add("faculty_email", SqlDbType.VarChar).Value = department.Email;
            command.Parameters.Add("dept_full", SqlDbType.VarChar).Value = department.Dept_Full;
            command.Parameters.Add("last_edited_user", SqlDbType.VarChar).Value = department.Last_User;
            command.CommandType = CommandType.StoredProcedure;
            return command;
        }

        //Get All application associated with the specified TUID
        public static SqlCommand GetAllISRAByTUID(int tuid)
        {
            SqlCommand command = new SqlCommand("dbo.GetAllISRAByTUID");
            command.Parameters.Add("tuid", SqlDbType.Int).Value = tuid;
            command.CommandType = CommandType.StoredProcedure;
            return command;
        }

        //Get the application associated with the specified ISRA_ID
        public static SqlCommand GetISRAByISRAID(int isra_id)
        {
            SqlCommand command = new SqlCommand("dbo.GetISRAByISRAID");
            command.Parameters.Add("isra_id", SqlDbType.Int).Value = isra_id;
            command.CommandType = CommandType.StoredProcedure;
            return command;
        }

        //Get All application associated with the specified Advisor
        public static SqlCommand GetAllISRAByRegistrar()
        {
            SqlCommand command = new SqlCommand("dbo.GetAllISRAByRegistrar");
            command.CommandType = CommandType.StoredProcedure;
            return command;
        }

        //Get All application associated with the specified Instructor
        public static SqlCommand GetAllISRAByInstructor(string instructorEmail)
        {
            SqlCommand command = new SqlCommand("dbo.GetAllISRAByInstructor");
            command.Parameters.Add("grade_instructor", SqlDbType.VarChar).Value = instructorEmail;
            command.CommandType = CommandType.StoredProcedure;
            return command;
        }

        //Return a count to check if the application from this tuid for this course number already exist
        public static SqlCommand PreventApplicationDuplication(ISRARequest application)
        {
            SqlCommand command = new SqlCommand("dbo.PreventApplicationDuplication");
            command.Parameters.Add("tuid", SqlDbType.Int).Value = application.TUID;
            command.Parameters.Add("course_number", SqlDbType.VarChar).Value = application.Course_Number;
            command.CommandType = CommandType.StoredProcedure;
            return command;
        }

        // return all admins
        public static SqlCommand GetAllAdmins()
        {
            SqlCommand command = new SqlCommand("dbo.GetAllAdmins");
            command.CommandType = CommandType.StoredProcedure;
            return command;
        }

        public static SqlCommand GetEmailByID(int id)
        {
            SqlCommand command = new SqlCommand("dbo.GetEmailTemplateByID");
            command.Parameters.Add("id", SqlDbType.Int).Value = id;
            command.CommandType = CommandType.StoredProcedure;
            return command;
        }

        public static SqlCommand UpdateEmailByID(int id, string subject, string intro, string addy, string ending, string contact, string user)
        {
            SqlCommand command = new SqlCommand("dbo.UpdateEmailTemplateByID");
            command.Parameters.Add("id", SqlDbType.Int).Value = id;
            command.Parameters.Add("subject", SqlDbType.VarChar).Value = subject;
            command.Parameters.Add("intro", SqlDbType.VarChar).Value = intro;
            command.Parameters.Add("addy", SqlDbType.VarChar).Value = addy;
            command.Parameters.Add("ending", SqlDbType.VarChar).Value = ending;
            command.Parameters.Add("contact", SqlDbType.VarChar).Value = contact;
            command.Parameters.Add("user", SqlDbType.VarChar).Value = user;
            command.CommandType = CommandType.StoredProcedure;
            return command;
        }

        public static SqlCommand ReceiveEmails(string adminEmail, bool boxChecked)
        {
            SqlCommand command = new SqlCommand("dbo.ReceiveEmails");
            command.Parameters.Add("email", SqlDbType.VarChar).Value = adminEmail;
            command.Parameters.Add("checked", SqlDbType.Bit).Value = boxChecked;
            command.CommandType = CommandType.StoredProcedure;
            return command;
        }
    }
}
