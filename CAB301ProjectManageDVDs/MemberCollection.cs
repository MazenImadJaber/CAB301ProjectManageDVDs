using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Timers;

namespace CAB301ProjectManageDVDs
{
    class MemberCollection
    {

        public int numberOfMembers = 0; // number of members in collection
        public Member staff = new Member("staff", string.Empty, "1111", "today123"); // regiser staff member
        public Member[] members; // array to hold members
        /// <summary>
        /// constructor
        /// </summary>
        MemberCollection()
        {
            staff.userName = "staff";
        }


        /// <summary>
        /// registors Memeber  given their fist and last name, phone number
        /// residential address and an int Password.
        /// </summary>
        /// <param name="firstName"></param>
        /// <param name="lastName"></param>
        /// <param name="phoneNumber"></param>
        /// <param name="residentialAddress"></param>
        /// <param name="password"></param>
        public void Register(string firstName, string lastName, string phoneNumber, string residentialAddress, string password)
        {
            if (numberOfMembers == 0)
            {
                members = new Member[1];
                members[0] = new Member(firstName, lastName, phoneNumber, residentialAddress, password);
                numberOfMembers++;
            }
            else
            {
                Member temp = new Member(firstName, lastName, phoneNumber, residentialAddress, password);
                bool unique = true;
                foreach (Member m in members)
                {
                    if (string.Compare(temp.userName.ToUpper(), m.userName.ToUpper()) == 0)
                    {
                        unique = false;
                        break;
                    }

                }
                if (unique)
                {
                    Array.Resize(ref members, members.Length + 1);
                    members[numberOfMembers] = temp;
                    numberOfMembers++;
                    Console.WriteLine("{0} was successfully added to the library.", temp.userName);
                }
                else
                {
                    Console.WriteLine("A member with the username \"{0}\" already exists!", temp.userName);
                }
            }
        }


        /// <summary>
        /// displays a members Contact Number given thier username(lastname+firstname)
        /// </summary>
        /// <param name="userName"></param>
        ///  username(lastname+firstname)
        public void FindContactNumber(string userName)
        {
            if (numberOfMembers > 0)
            {

                foreach (Member m in members)
                {
                    if (string.Compare(userName.ToLower(), m.userName.ToLower()) == 0)
                    {
                        Console.WriteLine("{0} contact number is {1}", m.userName, m.phoneNumber);
                        return;
                    }

                }
                Console.WriteLine("{0} is not registered!", userName);
            }
            else
            {
                Console.WriteLine("Collection is empty!");
            }
        }

        /// <summary>
        /// adds a movie to member  given thier username(lastname+firstname) 
        /// </summary>
        /// <param name="userName"></param>
        /// <param name="movie"></param>
        public void Borrow(string userName, Movie movie)
        {
            if (numberOfMembers > 0)
            {

                foreach (Member m in members)
                {
                    if (string.Compare(userName.ToLower(), m.userName.ToLower()) == 0)
                    {
                        m.Borrow(movie);
                        return;
                    }

                }
                Console.WriteLine("{0} is not registered!", userName);
            }
            else
            {
                Console.WriteLine("Memeber Collection is empty!");
            }
        }


        /// <summary>
        /// displays movies in a member's collection given thier username(lastname+firstname)
        /// </summary>
        /// <param name="userName"></param>
        public void ListMovies(string userName)
        {
            if (numberOfMembers > 0)
            {

                foreach (Member m in members)
                {
                    if (string.Compare(userName.ToLower(), m.userName.ToLower()) == 0)
                    {
                        m.ListMovies();
                        return;
                    }

                }
                Console.WriteLine("{0} is not registered!", userName);
            }
            else
            {
                Console.WriteLine("Memeber Collection is empty!");
            }
        }
    }
}
