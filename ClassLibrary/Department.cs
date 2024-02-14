using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ClassLibrary
{
    public class Department
    {
        private string abbreviated;
        private string email;
        private string dept_full;
        private string last_user;

        public string Abbreviated
        {
            get { return abbreviated; }
            set { abbreviated = value; }
        }

        public string Email
        {
            get { return email; }
            set { email = value; }
        }

        public string Dept_Full
        {
            get { return dept_full; }
            set { dept_full = value; }
        }

        public string Last_User
        {
            get { return last_user; }
            set { last_user = value; }
        }

        //Default Constructor
        public Department()
        {

        }

        //Parameterized Constructor
        public Department(string abbreviated, string email, string full, string last_user)
        {
            this.Abbreviated = abbreviated;
            this.Email = email;
            this.Dept_Full = full;
            this.Last_User = last_user;
        }
    }
}
