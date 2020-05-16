using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CAB301ProjectManageDVDs
{
    class Member
    {
    
        public string firstName, lastName;
        public string userName;
        public string password;
        public string phoneNumber;
        public string residentialAddress;
        Movie[] borrowedMovies = new Movie[10];
        public int numberOfMovies = 0;

        /// <summary>
        /// Memeber constructor given fist and last name, phone number
        /// residential address and an int Password.
        /// </summary>
        /// <param name="firstName"></param>
        /// <param name="lastName"></param>
        /// <param name="phoneNumber"></param>
        /// <param name="residentialAddress"></param>
        /// <param name="password"></param>
        public Member( string firstName, String lastName, string phoneNumber, string residentialAddress,string password)
        {
            this.firstName = firstName;
            this.lastName = lastName;
            this.phoneNumber = phoneNumber;
            userName = lastName + firstName;
            this.password = password;
            this.residentialAddress= residentialAddress;

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
            str = firstName + " " + lastName +
                   " is a registered member, phone number: " + phoneNumber
                   + " username: " + userName + " Password: " + password;
            return str;
        }
        /// <summary>
        /// Borrow a movie from library and add to collection
        /// </summary>
        /// <param name="Movie"></param>
        public void Borrow(Movie Movie)
        {
            if (numberOfMovies < 10)
            {
                bool unique = true;
                if (numberOfMovies > 0)
                {
                    for(int i = 0; i < numberOfMovies; i++)
                    {
                      if(  string.Compare(Movie.title.ToUpper().Replace(" ", string.Empty),
                          borrowedMovies[i].title.ToUpper().Replace(" ", string.Empty)) == 0)
                        {
                            unique = false;
                        }
                    }
                    if (unique)
                    {
                        borrowedMovies[numberOfMovies] = new Movie(Movie.title,1,Movie.genre,Movie.duration,
                            Movie.releaseDate,Movie.releaseDate,Movie.director,Movie.classification);
                        Console.WriteLine("{0} was successfully borrowed!\n",Movie.title);

                    }
                    else
                    {
                        Console.WriteLine("{0} is already in your collection!\n", Movie.title);
                    }
                }
     
                
            }
            else
            {
                Console.WriteLine("You can only borrow 10 movies at a time!\n return a movie and try again!");
            } 

        }

        /// <summary>
        /// Dispalys all borrowed movies to Console
        /// </summary>
        public void ListMovies()
        {
            foreach(Movie m in borrowedMovies)
            {
                Console.WriteLine(m.toString());
            }
        }

    }
 
}
