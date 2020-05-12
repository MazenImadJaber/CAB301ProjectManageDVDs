using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CAB301ProjectManageDVDs
{
    /// <summary>
    /// The Movie Class creates Movie DVD objects 
    /// that contain the name of the DVDs and the number 
    /// of copies and time borrowed to mange the library.
    /// </summary>
    class Movie
    {
       public string name;
       public int numberOfCopies;
        public int numberOfAvailableCopies;
        public int timesBorrowed;


        /// <summary>
        /// Constructor that takes no arguments, sets name to Untitled 
        /// and number of copies to one 
        /// </summary>
        public Movie()
        {
            this.name = "Untitled";
            this.numberOfCopies = 1;
            this.timesBorrowed = 0;
            this.numberOfAvailableCopies = 1;
        }


        /// <summary>
        /// Constructor that takes one arguments, the title     
        /// </summary>
        /// <param name="title"></param>
        /// Title of movie DVD
        public Movie(string title)
        {
            this.name = title;
            this.numberOfCopies = 1;
            this.timesBorrowed = 0;
            this.numberOfAvailableCopies = 1;
        }


        /// <summary>
        /// Constructor that takes twp arguments, the title and number of  copies 
        /// </summary>
        /// <param name="title"></param>
        /// Title of DVD
        /// <param name="numberOfcopies"></param>
        /// Number of copies
        public Movie(string title,int numberOfCopies)
        {
            this.name = title;
            if (numberOfCopies > 0)
            {
                this.numberOfCopies = numberOfCopies;
            }
            else
            {
                this.numberOfCopies = 1;
                Console.WriteLine("Number of Copies Must be a non-zero " +
                    "positive number!! \n number is set to 1");
            }
            
            this.timesBorrowed = 0;
            this.numberOfAvailableCopies = this.numberOfCopies;
        }


        /// <summary>
        /// this function returns the frequncy of borrowing
        /// </summary>
        /// <returns></returns>
        /// frequncy of borrowing (number of times borrowed/number of copies;
        public int getFrequncy()
        {
            return timesBorrowed;
        }

        /// <summary>
        /// Borrow this movies 
        /// </summary>
        /// <returns></returns>
        /// returns true if successful
        public bool Borrow()
        {
            if (numberOfAvailableCopies>0)
            {
                numberOfAvailableCopies--;
                timesBorrowed++;
                return true;
            }
            else
            {
                Console.WriteLine("No copies are available at the moment! please try again later");
                return false;
            }
        }


        /// <summary>
        /// Borrow a number of copies
        /// </summary>
        /// <param name="copies"></param>
        /// number of wanted copies
        /// <returns></returns>
        /// returns true if successful
        public bool Borrow(int copies)
        {
            if (numberOfAvailableCopies > 0 && copies <= numberOfAvailableCopies)
            {
                numberOfAvailableCopies-=copies;
                timesBorrowed+=copies;
                return true;
            }
            else
            {
                Console.WriteLine("there are {0} availabe copies! please try again",numberOfAvailableCopies);
                return false;
            }
        }
        
        /// <summary>
        /// Add extra copies 
        /// </summary>
        /// <param name="copies"></param>
        /// number of new copies
        public void AddCopies(int copies)
        {
            if (copies > 0)
            {
                numberOfAvailableCopies += copies;
                numberOfCopies += copies;
            }
            else
            {
                Console.WriteLine("Number of new copies must be a possitve intger!");
            }
        }
        /// <summary>
        /// retuen borrowed movie
        /// </summary>
        /// <param name="copies"></param>
        /// number of copies to return
        public void returnMovie(int copies =1)
        {
            int missing = numberOfCopies - numberOfAvailableCopies;
            if (copies > 0)
            {
                if (numberOfAvailableCopies < numberOfCopies)
                {
                    if (copies <= missing)
                    {
                        numberOfAvailableCopies += copies;
                    }
                    else
                    {
                        numberOfAvailableCopies += missing;
                        Console.WriteLine("Only {0} are ours! keep the rest!", missing);
                    }


                }
                else
                {
                    Console.WriteLine("All copies of this movie are in stock!");
                }
            }
            else
            {
                Console.WriteLine("Number of new copies must be a possitve intger!");
            }
        }
    }
}
