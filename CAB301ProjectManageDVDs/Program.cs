using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.Remoting.Services;
using System.Text;
using System.Threading.Tasks;

namespace CAB301ProjectManageDVDs
{
    class Program
    {
        static void Main(string[] args)
        {
            bool exit = false;
            string[] Genres ={ "Drama", "Adventure", "Family", "Action", "Sci-Fi",
                                  "Comedy", "Animated" , "Thriller", "Other" };
            string[] Classifications = { "General (G)", "Parental Guidance (PG)" ,
                                            "Mature (M15+)", "Mature Accompanied (MA15+)"};

            MovieCollection DVDS = new MovieCollection();
            MemberCollection members = new MemberCollection();

            DVDS.Add(new Movie("Night at the Museum",10, Genres[1], 108, "2006", "Ben Stiller, Carla Gugino, Ricky Gervais", 
                                "Shawn Dyke", Classifications[1]));
            DVDS.Add(new Movie("Legally Blonde", 10, Genres[5], 96, "2001", "Reese Witherspoon, Luke Wilson, Selma Blair",
                "Robert Luketic", Classifications[1]));
            DVDS.Add(new Movie("Quantum Of Solace", 10, Genres[3], 96, "2008", "Daniel Craig, Olga Kurylenko, Mathieu Amalric",
                "Marc Forster", Classifications[2]));
            DVDS.Add(new Movie("Mean Girls", 10, Genres[5], 96, "2004", "Lindsay Lohan, Jonathan Bennett, Rachel McAdams", 
                "Mark Waters", Classifications[2]));
            members.Register("Mazen", "Jaber", "n9940669", "QUT_CAB301", "0000");

            while (!exit)
            {
                mainMenu();

                int key;
               if( int.TryParse(Console.ReadLine(),out key) && key<3){
                    if (key == 0)
                    {
                        exit = true;
                    }
                    if (key == 1)
                    {
                        Console.Write("Enter username:  ");
                        if (string.Compare(members.staff.userName, Console.ReadLine()) == 0)
                        {
                            Console.Write("Enter password:  ");
                            if (string.Compare(members.staff.password, Console.ReadLine()) == 0)
                            {
                                staffMenu(ref DVDS, ref members);
                            }
                            else
                            {
                                Console.WriteLine("Password is incorrect!");
                            } 
                                

                        }
                        else
                        {
                            Console.WriteLine("Staff username invalid.");

                        } 
                    }
                }
               else
                {
                    Console.WriteLine("invalid input");
                }
              

            }

            
        }

        private static void staffMenu( ref MovieCollection DVDS, ref MemberCollection members)
        {
            string[] Genres ={ "Drama", "Adventure", "Family", "Action", "Sci-Fi",
                                  "Comedy", "Animated" , "Thriller", "Other" };
            string[] Classifications = { "General (G)", "Parental Guidance (PG)" ,
                                            "Mature (M15+)", "Mature Accompanied (MA15+)"};
         string title;
         int numberOfCopies;
         string starring;
         string director;
         int duration;
         string genre;
         string releaseDate;
         string classification;
         string firstName;
         string lastName;
         string phoneNumber;
         string residentialAddress;
         string password;




        bool exist = false;
            while (!exist)
            {
                Console.Write("\n\n===============Staff Menu==================\n" +
                             "1. Add a new Movie DVD.\n" +
                             "2. Remove a Movie DVD.\n" +
                             "3. Display all movies.\n" +
                             "4. Register a new Member.\n" +
                             "5. Find a registered member's phone number.\n" +
                             "6. Display members.\n" +
                             "0. return to main menu.\n" +
                             "===========================================\n" +
                             "Please make a Selection(1-6, or 0 to exist):");
                int key;
                if (int.TryParse(Console.ReadLine(), out key) && key < 7)
                {
                    if (key == 0)
                    {
                        exist = true;
                    }
                  
                    if (key == 1)
                    {
                        Console.Write("Enter Movie Title: ");
                         title = Console.ReadLine();
                        Movie[] movieArray = DVDS.ToArray();
                        bool movieExists = false;
                        foreach (Movie m in movieArray)
                        {
                            if (string.Compare(m.title.ToUpper().Replace(" ", string.Empty)
                                , title.ToUpper().Replace(" ", string.Empty)) == 0)
                            {
                                movieExists = true;
                                break;
                            }
                        }
                        if (movieExists)
                        {
                            Console.WriteLine("Movie aleady exists!");
                            Console.Write("Enter number of copies: ");
                           
                            if(int.TryParse(Console.ReadLine(),out numberOfCopies))
                            {
                                DVDS.addCpies(title, numberOfCopies);
                            }
                            else
                            {
                                Console.WriteLine("invalid input");
                            }


                        }
                        else
                        {
                            Console.Write("Enter number of copies: ");

                            if (int.TryParse(Console.ReadLine(), out numberOfCopies))
                            {
                                Console.Write("Enter release date (year): ");
                                releaseDate = Console.ReadLine();
                                Console.Write("Enter Starring actor/s: ");
                                starring = Console.ReadLine();
                                Console.Write("Enter Director/s: ");
                                director= Console.ReadLine();
                                Console.Write("Enter Duration (minutes): ");
                                if(int.TryParse(Console.ReadLine(), out duration))
                                {
                                    Console.WriteLine("Select Genre: ");
                                    int i = 1;
                                    foreach(string g in Genres)
                                    {
                                        Console.WriteLine(i+". "+g);
                                        i++;
                                    }
                                    Console.Write("Enter selection(1-{0}): ",Genres.Length);
                                    int selction;
                                    if (int.TryParse(Console.ReadLine(), out selction))
                                    {
                                        if (selction <= Genres.Length)
                                        {
                                            genre = Genres[selction - 1];

                                            Console.WriteLine("Select Classifaction: ");
                                            i = 1;
                                            foreach (string c in Classifications)
                                            {
                                                Console.WriteLine(i + ". " + c);
                                                i++;
                                            }
                                            Console.Write("Enter selection(1-{0}): ",Classifications.Length);
                                            if (int.TryParse(Console.ReadLine(), out selction))
                                            {
                                                if (selction <= Classifications.Length)
                                                {
                                                    classification = Classifications[selction - 1];
                                                    DVDS.Add(new Movie(title, numberOfCopies, genre, duration, releaseDate, starring,
                                                        director, classification));
                                                }
                                                else
                                                {
                                                    Console.WriteLine("invalid input");
                                                }
                                                
                                            }
                                            else
                                            {
                                                Console.WriteLine("invalid input");
                                            }

                                        }
                                        else
                                        {
                                            Console.WriteLine("invalid input");
                                        }
                                        
                                    }
                                    else
                                    {
                                        Console.WriteLine("invalid input");
                                    }

                                }
                                else
                                {
                                    Console.WriteLine("invalid input");
                                }
                            }
                            else
                            {
                                Console.WriteLine("invalid input");
                            }
                            



                        }
                    }
                    if (key == 2)
                    {
                        Console.Write("Enter title of movie to remove: ");
                        DVDS.Remove(Console.ReadLine());
                    }
                    if (key == 3)
                    {
                        display(DVDS);
                    }
                    if (key == 4)
                    {
                        //todo regestor member
                    }
                    if (key == 5)
                    {
                        // Find a registered member's phone number
                    }
                    if (key == 6)
                    {
                        Console.WriteLine("Members in Library:");
                        foreach(Member m in members.members)
                        {
                            Console.WriteLine(m.toString());
                        }
                    }
                 
                }
                else
                {
                    Console.WriteLine("invalid input");
                }

            }
            
        }

        private static void mainMenu()
        {
            Console.Write("\n\nWelcome to the Communtiy Library!\n" +
                              "===============Main Menu===================\n" +
                              "1. Staff Login.\n" +
                              "2. Member Login.\n" +
                              "0. Exit.\n" +
                              "===========================================\n" +
                              "Please make a Selection(1-2, or 0 to exist):");
        }


        /// <summary>
        /// Displays Top10 movies in a collection
        /// </summary>
        /// <param name="DVDS"></param>
        private static void displayTop10(MovieCollection DVDS)
        {
            Console.WriteLine("********top**10*************");
            int counter = 0;
            Movie[] movies = DVDS.TopTen();
            if (movies.Length == 0)
            {
                Console.WriteLine("library is empty!");
                return;
            }
            foreach (Movie m in movies)
            {
                Console.WriteLine((counter + 1) + ".  " + m.toString10());



            }

        }


        /// <summary>
        /// 
        /// </summary>
        /// <param name="DVDS"></param>
        private static void display(MovieCollection DVDS)
        {
            Console.WriteLine("*************************");

            Movie[] a = DVDS.ToArray();
            if (a.Length == 0)
            {
                Console.WriteLine("collection is empty!");
                return;
            }
            foreach (Movie m in a)
            {

                Console.WriteLine(m.toString());

            }

        }

    }
}
