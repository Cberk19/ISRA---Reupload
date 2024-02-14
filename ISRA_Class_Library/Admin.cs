using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ISRA_Class_Library
{
    class Admin
    {
        private string email;
        private string first;
        private string last;
        private string is_urp;
        private string last_user;

        public string Email
        {
            get { return email; }
            set { email = value; }
        }

        public string First
        {
            get { return first; }
            set { first = value; }
        }

        public string Last
        {
            get { return last; }
            set { last = value; }
        }

        public string Is_Urp
        {
            get { return is_urp; }
            set { is_urp = value; }
        }

        public string Last_User
        {
            get { return last_user; }
            set { last_user = value; }
        }

        //Default Constructor
        public Admin()
        {

        }

        //Constructor for adding in a new admin
        public Admin(string email, string first, string last, string last_user)
        {
            this.Email = email;
            this.First = first;
            this.Last = last;
            this.Last_User = last_user;
        }
    }
}
