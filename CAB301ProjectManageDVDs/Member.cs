using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CAB301ProjectManageDVDs
{
    class Member
    {
        public bool Staff;
        public string firstName, lastName;
        public string userName;
        public string password;
        public string phoneNumber;
        MovieCollection borrowedMovies = new MovieCollection();
        public Member(bool staff, string FirstName, String LastName,string phoneNumber)
        {
            this.Staff = staff;
            if (staff)
            {
                this.firstName = FirstName;
                this.lastName = LastName;
                this.phoneNumber = phoneNumber;
                userName = "staff";
                password = "today123";
            }
            else
            {
                this.firstName = FirstName;
                this.lastName = LastName;
                this.phoneNumber = phoneNumber;
                userName = FirstName+LastName;
                password = "0000";
            }
        }
        public bool setPassword(string password)
        {
            if (password.Length == 4)
            {
                int check;
               if( int.TryParse(password,out check))
                {
                    this.password = password;
                    return true;
                }
               else
                {
                    Console.WriteLine("The password can only be an integer");
                    return false;
                }
            }
            else
            {
                Console.WriteLine("The password is a four-digit integer");
                return false;
            }
        }
    }
 
}
