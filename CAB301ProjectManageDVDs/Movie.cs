using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.InteropServices;
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
       
        public string title;
        public string starring;
        public string director;
        public int duration;
        public string genre;
        public string releaseDate;
        public string classification;
        public int numberOfCopies;
        private int numberOfAvailableCopies;
        public int timesBorrowed;


        /// <summary>
        /// Constructor that takes no arguments, sets name to Untitled 
        /// and number of copies to one 
        /// </summary>
        public Movie()
        {
            this.title = "Untitled";
            this.numberOfCopies = 1;
            this.timesBorrowed = 0;
            this.numberOfAvailableCopies = 1;
            this.director = "unknown";
            this.starring = "unknown";
            this.duration = 100;
            this.genre = "Other";
            this.classification = "Unclassified";
        }


        /// <summary>
        /// Constructor that takes one arguments, the title     
        /// </summary>
        /// <param name="title"></param>
        /// Title of movie DVD
        public Movie(string title)
        {
            this.title = title;
            this.numberOfCopies = 1;
            this.timesBorrowed = 0;
            this.numberOfAvailableCopies = 1;
            this.director = "unknown";
            this.starring = "unknown";
            this.duration = 100;
            this.genre = "Other";
            this.classification = "Unclassified";
            this.releaseDate = "unspecified";
        }


        /// <summary>
        /// Constructor that takes twp arguments, the title and number of  copies 
        /// </summary>
        /// <param name="title"></param>
        /// Title of DVD
        /// <param name="numberOfcopies"></param>
        /// Number of copies
        public Movie(string title, int numberOfCopies)
        {
            this.title = title;
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
            this.director = "unknown";
            this.starring = "unknown";
            this.duration = 100;
            this.genre = "Other";
            this.classification ="Unclassified";
            this.releaseDate = "unspecified";
        }
        /// <summary>
        /// movie constructor with title number of copies, genre and classification only 
        /// </summary>
        /// <param name="title"></param>
        /// movie title 
        /// <param name="numberOfCopies"></param>
        /// number of copies
        /// <param name="genre"></param>
        /// genre from the Genres enum
        /// <param name="classification"></param>
        /// classification from the classifications enum 
        public Movie(string title, int numberOfCopies, string genre, string classification, string releaseDate)
        {
            this.title = title;
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
            this.director = "unknown";
            this.starring = "unknown";
            this.duration = 2;
            this.genre = genre;
            this.classification = classification;
            this.releaseDate = releaseDate;
        }
        /// <summary>
        /// constructor with all elements 
        /// </summary>
        /// <param name="title"></param>
        /// movie title 
        /// <param name="numberOfCopies"></param>
        /// number of copies to add to library 
        /// <param name="genre"></param>
        /// movie genre 
        /// <param name="duration"></param>
        /// duration in minutes
        /// <param name="starring"></param>
        /// main actor name
        /// <param name="director"></param>
        /// director name 
        /// <param name="classification"></param>
        /// movie age classifction
        public Movie(string title, int numberOfCopies, string genre, int duration, string releaseDate,
                    string starring, string director, string classification)
        {
            this.title = title;
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
            this.director = director;
            this.starring = starring;
            this.duration = duration;
            this.genre = genre;
            this.classification = classification;
            this.releaseDate = releaseDate;

        }

        /// <summary>
        /// Borrow this movies 
        /// </summary>
        /// <returns></returns>
        /// returns true if successful
        public Movie Borrow()
        {
            if (numberOfAvailableCopies > 0)
            {
                numberOfAvailableCopies--;
                timesBorrowed++;
                return new Movie(title,1,genre,duration,releaseDate,starring
                    ,director,classification);
            }
            else
            {
                Console.WriteLine("No copies are available at the moment! please try again later");
                return null;
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
        public void returnMovie(int copies = 1)
        {
            int missing = numberOfCopies - numberOfAvailableCopies;
            if (copies > 0)
            {
                if (numberOfAvailableCopies < numberOfCopies)
                {
                    if (copies <= missing)
                    {
                        numberOfAvailableCopies += copies;
                        Console.WriteLine("Movie was successfully returned to the library");
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
        /// <summary>
        /// return string represntation for display with all info
        /// </summary>
        /// <returns></returns>
        public string toString()
        {
            string str = string.Format(" Title: {0}\n Number Of Copies avilable: {1}\n Genre: {2}\n Classification: {3}\n" +
                " Dirctor: {4}\n Staring: {5}\n Duration: {6} minutes\n Release Date:" +
                "{7}\n Times Borrowed: {8}\n\n",
                title, numberOfAvailableCopies, genre, classification, 
                director, starring, duration, releaseDate,timesBorrowed);

            return str;

        }
        public string toStringMember()
        {
            string str = string.Format(" Title: {0}\n " +
                                       "Number Of Copies: {1}\n " +
                                       "Genre: {2}\n " +
                                       "Classification: {3}\n " +
                                       "Dirctor: {4}\n " +
                                       "Staring: {5}\n " +
                                       "Duration: {6} minutes\n " +
                                       "Release Date:{7}\n\n",
                title, numberOfAvailableCopies, genre, 
                classification, director, starring,
                duration, releaseDate);

            return str;

        }


        /// <summary>
        /// return string reprenttion with title and frequncey only
        /// </summary>
        /// <returns></returns>
        public string toString10()
        {
            string str = string.Format(" Title: {0}, Frequency: {1}",
                title, timesBorrowed);
            return str;

        }
    }
}
