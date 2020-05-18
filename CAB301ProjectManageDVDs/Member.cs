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
        public Movie[] borrowedMovies = new Movie[10];
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
                   " phone number: " + phoneNumber
                   + " username: " + userName + " Password: " + password
                   + " Residential Address: " + residentialAddress;
            return str;
        }
        /// <summary>
        /// Borrow a movie from library and add to collection
        /// </summary>
        /// <param name="Movie"></param>
        public void Borrow(Movie Movie)
        {
            if (Movie == null)
            {
                Console.WriteLine("Unsuccessful");
                return;
            }
            if (numberOfMovies < 10)
            {
                
                if (numberOfMovies >= 0)
                {
                    bool unique = true;
                    if (numberOfMovies > 0)
                    {
                        for (int i = 0; i < numberOfMovies; i++)
                        {
                            if (string.Compare(Movie.title.ToUpper().Replace(" ", string.Empty),
                                borrowedMovies[i].title.ToUpper().Replace(" ", string.Empty)) == 0)
                            {
                                unique = false;
                            }
                        }
                    }
                    
                    if (unique && Movie != null)
                    {
                        borrowedMovies[numberOfMovies] = new Movie(Movie.title,1,Movie.genre,Movie.duration,
                            Movie.releaseDate,Movie.starring,Movie.director,Movie.classification);
                        numberOfMovies++;
                        Console.WriteLine("{0} was successfully borrowed!\n",Movie.title);

                    }
                    else
                    {
                        if (Movie != null)
                        {
                            Console.WriteLine("{0} is already in your collection!\n", Movie.title);
                        }
                        
                    }
                }
     
                
            }
            else
            {
                Console.WriteLine("You can only borrow 10 movies at a time!\n return a movie and try again!");
            } 

        }

        public bool Retrun(string title, out string titleOut)
        {
            if (numberOfMovies == 0)
            {
                Console.WriteLine("You Have no movie in your collection!");
                titleOut = title;
                return false;
            }
            else
            {
                int index=0;
                bool borrowed = false;
                for (int i = 0; i < numberOfMovies; i++)
                {
                    if(string.Compare(title, borrowedMovies[i].title) == 0)
                    {
                        borrowed = true;
                        break;
                    }
                    index++;
                }
                if (borrowed)
                {
                    for (int i = index; i < borrowedMovies.Length - 1; i++)
                    {
                        borrowedMovies[i] = borrowedMovies[i + 1];
                    }
                    titleOut = title;
                    numberOfMovies--;
                    return true;
                }
                else
                {
                    Console.WriteLine("the title you have entred does not match any movie you've borrowed.");
                    titleOut = title;
                    return false;
                }
            }
        }

        /// <summary>
        /// Dispalys all borrowed movies to Console
        /// </summary>
        public void ListMovies()
        {
            if (numberOfMovies == 0)
            {
                Console.WriteLine("Your movie collection is empty");
            }
            else
            {
                for(int i =0; i<numberOfMovies;i++)
                {
                    Console.WriteLine(borrowedMovies[i].toStringMember());
                }
            }
         
        }

    }
 
}
