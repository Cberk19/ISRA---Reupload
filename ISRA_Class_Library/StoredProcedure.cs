using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Data;
using System.Data.SqlClient;

namespace ISRA_Class_Library
{
    class StoredProcedure
    {

        //Insert new record into ISRA table
        public SqlCommand InsertISRA(ISRA application)
        {
            SqlCommand command = new SqlCommand("InsertISRA");
            command.Parameters.Add("ISRA_ID", SqlDbType.Int).Value = application.Isra_Id;
            command.Parameters.Add("Registrar", SqlDbType.VarChar).Value = application.Registrar;
            command.Parameters.Add("Course_Number", SqlDbType.VarChar).Value = application.Course_Number;
            command.Parameters.Add("Status", SqlDbType.VarChar).Value = "Pending";
            command.Parameters.Add("Grade_Instructor", SqlDbType.VarChar).Value = application.Grade_Instructor;
            command.Parameters.Add("Additional_Professor", SqlDbType.VarChar).Value = application.Additional_Professor;
            command.Parameters.Add("Semester", SqlDbType.VarChar).Value = application.Semester;
            command.Parameters.Add("TUID", SqlDbType.Int).Value = application.TUID;
            command.Parameters.Add("Is_URP", SqlDbType.VarChar).Value = application.Is_Urp;
            command.Parameters.Add("Credit_Hours", SqlDbType.VarChar).Value = application.Credit_Hours;
            command.Parameters.Add("Student_First", SqlDbType.VarChar).Value = application.Student_First;
            command.Parameters.Add("Student_Last", SqlDbType.VarChar).Value = application.Student_Last;
            command.Parameters.Add("Student_Email", SqlDbType.VarChar).Value = application.Student_Email;
            command.Parameters.Add("Student_Major", SqlDbType.VarChar).Value = application.Student_Major;
            command.Parameters.Add("Course_Plan", SqlDbType.VarChar).Value = application.Course_Plan;
            command.Parameters.Add("Instructor_Approval_Image", SqlDbType.VarChar).Value = application.Approve_Url;
            command.Parameters.Add("Instructor_Approval_Text", SqlDbType.VarChar).Value = application.Approve_Text;
            command.Parameters.Add("Student_Signature", SqlDbType.VarChar).Value = application.Student_Signature;
            command.Parameters.Add("Last_Edited_User", SqlDbType.VarChar).Value = application.Last_User;
            command.CommandType = CommandType.StoredProcedure;
            return command;
        }

        //Update pending ISRA application with decision
        public SqlCommand UpdateDecision(ISRA application)
        {
            SqlCommand command = new SqlCommand("UpdateDecision");
            command.Parameters.Add("status", SqlDbType.VarChar).Value = application.Status;
            command.Parameters.Add("isra_id", SqlDbType.Int).Value = application.Isra_Id;
            command.Parameters.Add("tuid", SqlDbType.Int).Value = application.TUID;
            command.Parameters.Add("denial_reason_text", SqlDbType.VarChar).Value = application.Decision_Text;
            command.Parameters.Add("crn", SqlDbType.Int).Value = application.CRN;
            command.Parameters.Add("section", SqlDbType.Int).Value = application.Section_Number;
            command.Parameters.Add("last_edited_user", SqlDbType.VarChar).Value = application.Last_User;
            command.CommandType = CommandType.StoredProcedure;
            return command;
        }

        //Insert a new admin into the Admin table
        public SqlCommand InsertAdmin(Admin admin)
        {
            SqlCommand command = new SqlCommand("InsertAdmin");
            command.Parameters.Add("faculty_email", SqlDbType.VarChar).Value = admin.Email;
            command.Parameters.Add("faculty_first", SqlDbType.VarChar).Value = admin.First;
            command.Parameters.Add("faculty_last", SqlDbType.VarChar).Value = admin.Last;
            command.Parameters.Add("last_edited_user", SqlDbType.VarChar).Value = admin.Last_User;
            command.CommandType = CommandType.StoredProcedure;
            return command;
        }

        //Delete an admin from the Admin table
        public SqlCommand DeleteAdmin(Admin admin)
        {
            SqlCommand command = new SqlCommand("DeleteAdmin");
            command.Parameters.Add("faculty_email", SqlDbType.VarChar).Value = admin.Email;
            command.CommandType = CommandType.StoredProcedure;
            return command;
        }

        //Insert a new course into the Course Table
        public SqlCommand InsertCourse(Course course)
        {
            SqlCommand command = new SqlCommand("InsertCourse");
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
        public SqlCommand DeleteCourse(Course course)
        {
            SqlCommand command = new SqlCommand("DeleteCourse");
            command.Parameters.Add("course_number", SqlDbType.VarChar).Value = course.Course_Number;
            command.CommandType = CommandType.StoredProcedure;
            return command;
        }

        //Update an existing course in the Course Table
        public SqlCommand UpdateCourse(Course course)
        {
            SqlCommand command = new SqlCommand("UpdateCourse");
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
        public SqlCommand InsertDepartment(Department department)
        {
            SqlCommand command = new SqlCommand("InsertDepartment");
            command.Parameters.Add("dept_abbreviated", SqlDbType.VarChar).Value = department.Abbreviated;
            command.Parameters.Add("faculty_email", SqlDbType.VarChar).Value = department.Email;
            command.Parameters.Add("dept_full", SqlDbType.VarChar).Value = department.Dept_Full;
            command.Parameters.Add("last_edited_user", SqlDbType.VarChar).Value = department.Last_User;
            command.CommandType = CommandType.StoredProcedure;
            return command;
        }

        //Get All application associated with the specified TUID
        public SqlCommand GetAllISRAByTUID(ISRA application)
        {
            SqlCommand command = new SqlCommand("GetAllISRAByTUID");
            command.Parameters.Add("tuid", SqlDbType.Int).Value = application.TUID;
            command.CommandType = CommandType.StoredProcedure;
            return command;
        }

        //Get the application associated with the specified TUID and ISRA_ID
        public SqlCommand GetISRAByISRAID(ISRA application)
        {
            SqlCommand command = new SqlCommand("GetISRAByISRAID");
            command.Parameters.Add("tuid", SqlDbType.Int).Value = application.TUID;
            command.Parameters.Add("isra_id", SqlDbType.Int).Value = application.Isra_Id;
            command.CommandType = CommandType.StoredProcedure;
            return command;
        }

        //Prevent ISRA_ID duplication by counting how many records with the provided ID
        public SqlCommand ISRA_ID_DuplicationPrevention(string hexadecimal)
        {
            SqlCommand command = new SqlCommand("ISRA_ID_DuplicationPrevention");
            command.Parameters.Add("id", SqlDbType.Int).Value = hexadecimal;
            command.CommandType = CommandType.StoredProcedure;
            return command;
        }
    }
}
