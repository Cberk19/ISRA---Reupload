using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ClassLibrary
{
    [Serializable]
    public class ISRARequest
    {
        private int isra_id;
        private string registrar;
        private string course_number;
        private string status;
        private string grade_instructor;
        private string extra_note;
        private string semester;
        private int tuid;
        private double credit_hours;
        private string student_first;
        private string student_last;
        private string student_email;
        private string student_major;
        private string course_plan_url;
        private string course_plan;
        private string approve_url;
        private string decision_text;
        private string student_signature;
        private int crn;
        private int section_number;
        private string last_user;
        private string date_submitted;

        public int Isra_Id
        {
            get { return isra_id; }
            set { isra_id = value; }
        }

        public string Registrar
        {
            get { return registrar; }
            set { registrar = value; }
        }

        public string Course_Number
        {
            get { return course_number; }
            set { course_number = value; }
        }

        public string Status
        {
            get { return status; }
            set { status = value; }
        }

        public string Grade_Instructor
        {
            get { return grade_instructor; }
            set { grade_instructor = value; }
        }

        public string Extra_Note
        {
            get { return extra_note; }
            set { extra_note = value; }
        }

        public string Semester
        {
            get { return semester; }
            set { semester = value; }
        }

        public int TUID
        {
            get { return tuid; }
            set { tuid = value; }
        }

        public double Credit_Hours
        {
            get { return credit_hours; }
            set { credit_hours = value; }
        }

        public string Student_First
        {
            get { return student_first; }
            set { student_first = value; }
        }

        public string Student_Last
        {
            get { return student_last; }
            set { student_last = value; }
        }

        public string Student_Email
        {
            get { return student_email; }
            set { student_email = value; }
        }

        public string Student_Major
        {
            get { return student_major; }
            set { student_major = value; }
        }

        public string Course_Plan_Url
        {
            get { return course_plan_url; }
            set { course_plan_url = value; }
        }

        public string Course_Plan
        {
            get { return course_plan; }
            set { course_plan = value; }
        }

        public string Approve_Url
        {
            get { return approve_url; }
            set { approve_url = value; }
        }

        public string Decision_Text
        {
            get { return decision_text; }
            set { decision_text = value; }
        }

        public string Student_Signature
        {
            get { return student_signature; }
            set { student_signature = value; }
        }

        public int CRN
        {
            get { return crn; }
            set { crn = value; }
        }

        public int Section_Number
        {
            get { return section_number; }
            set { section_number = value; }
        }

        public string Last_User
        {
            get { return last_user; }
            set { last_user = value; }
        }
        public string Date_Submitted
        {
            get { return this.date_submitted; }
            set { this.date_submitted = value; }
        }
        public string GetStudentInitials
        {
            get { return this.student_first.Substring(0, 1) + this.student_last.Substring(0, 1); }
        }

        //Empty Constructor
        public ISRARequest()
        {

        }


        //Base Constructor
        public ISRARequest(int isra_id, string registrar, string course_number, string status, string grade_instructor, string extra_note, string semester, int tuid, double credit_hours,
           string student_first, string student_last, string student_email, string student_major, string course_plan, string approve_url, string decision, string signature,
            int crn, int section, string last_user)
        {
            this.Isra_Id = isra_id;
            this.Registrar = registrar;
            this.Course_Number = course_number;
            this.Status = status;
            this.Grade_Instructor = grade_instructor;
            this.Extra_Note = extra_note;
            this.Semester = semester;
            this.TUID = tuid;
            this.Credit_Hours = credit_hours;
            this.Student_First = student_first;
            this.Student_Last = student_last;
            this.Student_Email = student_email;
            this.Student_Major = student_major;
            this.Course_Plan = course_plan;
            this.Approve_Url = approve_url;
            this.Decision_Text = decision;
            this.Student_Signature = signature;
            this.CRN = crn;
            this.Section_Number = section;
            this.Last_User = last_user;
        }

        //Constructor for submitting a new application
        public ISRARequest(string registrar, string course_number, string status, string grade_instructor, string extra_note, string semester, int tuid, double credit_hours,
           string student_first, string student_last, string student_email, string student_major, string course_plan_url, string course_plan, string approve_url, string signature,
             string last_user)
        {
            this.Registrar = registrar;
            this.Course_Number = course_number;
            this.Status = status;
            this.Grade_Instructor = grade_instructor;
            this.Extra_Note = extra_note;
            this.Semester = semester;
            this.TUID = tuid;
            this.Credit_Hours = credit_hours;
            this.Student_First = student_first;
            this.Student_Last = student_last;
            this.Student_Email = student_email;
            this.Student_Major = student_major;
            this.Course_Plan_Url = course_plan_url;
            this.Course_Plan = course_plan;
            this.Approve_Url = approve_url;
            this.Student_Signature = signature;
            
            this.Last_User = last_user;
        }


        //Constructor for denying the application
        public ISRARequest(int isra_id, int tuid, string status, string decision, string last_user)
        {
            this.Isra_Id = isra_id;
            this.TUID = tuid;
            this.Status = status;
            this.Decision_Text = decision;
            this.Last_User = last_user;
        }

        //Constructor for approving the application
        public ISRARequest(int isra_id, int tuid, string status, string decision, int crn, int section, string last_user)
        {
            this.Isra_Id = isra_id;
            this.TUID = tuid;
            this.Status = status;
            this.Decision_Text = decision;
            this.CRN = crn;
            this.Section_Number = section;
            this.Last_User = last_user;
        }

        //Constructor for getting all application associated with a TUID
        public ISRARequest(int tuid)
        {
            this.TUID = tuid;
        }

        //Constructor for getting an application associated with a TUID and ISRA_ID
        public ISRARequest(int tuid, int isra_id)
        {
            this.TUID = tuid;
            this.Isra_Id = isra_id;
        }



    }
}
