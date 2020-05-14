﻿using System;
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
        public enum Genres { Drama, Adventure, Family, Action, SciFi, Comedy, Animated, Thriller, Other };
        public enum Classifications { General, ParentalGuidance, Mature, MatureAccompanied, Unclassified };
        public string title;

        public string starring;
   

        public string director;
     

        public int duration;
      
        public Genres genre;
    
        public Classifications classification;
   
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
            this.genre = Genres.Other;
            this.classification = Classifications.Unclassified;
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
            this.genre = Genres.Other;
            this.classification = Classifications.Unclassified;
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
            this.genre = Genres.Other;
            this.classification = Classifications.Unclassified;
        }
        public Movie(string title, int numberOfCopies, Genres genre, Classifications classification)
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
        }

            public Movie(string title, int numberOfCopies, Genres genre, int duration,
                        string starring, string director, Classifications classification)
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


            }/// <summary>
             /// Borrow this movies 
             /// </summary>
             /// <returns></returns>
             /// returns true if successful
            public bool Borrow()
        {
            if (numberOfAvailableCopies > 0)
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
                numberOfAvailableCopies -= copies;
                timesBorrowed += copies;
                return true;
            }
            else
            {
                Console.WriteLine("there are {0} availabe copies! please try again", numberOfAvailableCopies);
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
        public string toString()
        {
            string str = string.Format(" Movie name: {0}, Number Of Available Copies: {1}, Genre:{2}, Classification:{3}" +
                " Dirctor:{4}, Staring:{5}, Duration:{6}min, frequncy:{7}", 
                title, numberOfAvailableCopies,genre,classification,director,starring,duration,timesBorrowed);
            return str;

        }
    }
}
