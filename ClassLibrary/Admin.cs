using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ClassLibrary
{
    public class Admin
    {
        private string email;
        private string first;
        private string last;
        private string last_user;
        private string tuid;
        private bool receive_emails;

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


        public string Last_User
        {
            get { return last_user; }
            set { last_user = value; }
        }

        public string TUID
        {
            get { return tuid;}
            set { tuid = value; }
        }
        public bool Receive_Emails
        {
            get { return this.receive_emails; }
            set { this.receive_emails = value; }
        }

        //Default Constructor
        public Admin()
        {

        }

        //Constructor for adding in a new admin
        public Admin(string email, string first, string last, string last_user, string tuid)
        {
            this.Email = email;
            this.First = first;
            this.Last = last;
            this.Last_User = last_user;
            this.TUID = tuid;
        }
    }
}
