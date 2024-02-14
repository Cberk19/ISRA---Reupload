using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ISRA_Class_Library
{
    class Course
    {
        private string course_number;
        private string title;
        private double gpa;
        private string note;
        private string pre_reqs;
        private int min_credits;
        private int max_credits;
        private int min_credits_urp;
        private string last_user;

        public string Course_Number
        {
            get { return course_number; }
            set { course_number = value; }
        }

        public string Title
        {
            get { return title; }
            set { title = value; }
        }

        public double Gpa
        {
            get { return gpa; }
            set { gpa = value; }
        }

        public string Note
        {
            get { return note; }
            set { note = value; }
        }

        public string Pre_Reqs
        {
            get { return pre_reqs; }
            set { pre_reqs = value; }
        }

        public int Min_Credits
        {
            get { return min_credits; }
            set { min_credits = value; }
        }

        public int Max_Credits
        {
            get { return max_credits; }
            set { max_credits = value; }
        }

        public int Min_Credits_Urp
        {
            get { return min_credits_urp; }
            set { min_credits_urp = value; }
        }

        public string Last_User
        {
            get { return last_user; }
            set { last_user = value; }
        }

        //Default Constructor
        public Course()
        {

        }

        //Independent Study Constructor
        public Course(string course, string title, double gpa, string note, string pre_reqs, int min, int max, string last_user)
        {
            this.Course_Number = course;
            this.Title = title;
            this.Gpa = gpa;
            this.Note = note;
            this.Pre_Reqs = pre_reqs;
            this.Min_Credits = min_credits;
            this.Max_Credits = max_credits;
            this.Last_User = last_user;
        }
    }
}
