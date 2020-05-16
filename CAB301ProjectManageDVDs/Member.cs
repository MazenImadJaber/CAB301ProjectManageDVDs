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
        MovieCollection borrowedMovies;
        /// <summary>
        /// 
        /// Memeber Class constructor 
        /// </summary>
        /// <param name="staff"></param>
        /// is this member a staff member
        /// <param name="FirstName"></param>
        /// first name
        /// <param name="LastName"></param>
        /// last name 
        /// <param name="phoneNumber"></param>
        /// phone number in string represntation 
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
                borrowedMovies = new MovieCollection();
            }
        }
        /// <summary>
        /// set member password
        /// </summary>
        /// <param name="password"></param>
        /// a four digit int password in string form
        /// <returns></returns>
        /// retuns true if successful 
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
                    Console.WriteLine("The password must be four-digit integer");
                    return false;
                }
            }
            else
            {
                Console.WriteLine("The password must be four-digit integer");
                return false;
            }
        }

        /// <summary>
        /// string represntation of member object
        /// </summary>
        /// <returns></returns>
        public string toString()
        {
            string str;
            if (Staff)
            {
                 str= firstName + " " + lastName +
                    " is a staff member, phone number: " + phoneNumber
                     + " username: " + userName + " Password: " + password;
            }
            else
            {
                str = firstName + " " + lastName +
                    " is a registered member, phone number: " + phoneNumber
                    + " username: " + userName + " Password: " + password;

            }
                
            return str;
        }
    }
 
}
