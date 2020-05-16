using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CAB301ProjectManageDVDs
{
    class Program
    {
        static void Main(string[] args)
        {
            MovieCollection DVDS = new MovieCollection();
         
            Movie a = new Movie("Superman", 1);
            Movie b = new Movie("Moonlight", 1);
            Movie c = new Movie("Zoroo", 1);
            Movie d = new Movie("Batman", 1);
            Movie e = new Movie("Legally Blode", 10);
            c.Borrow();
            d.Borrow();

            e.Borrow();
            e.Borrow();
            e.Borrow();
            e.Borrow();
            e.Borrow();
            e.Borrow();
            e.Borrow();
            e.Borrow();
            e.Borrow();
            e.Borrow();


            a.Borrow();
            a.returnMovie();
            a.Borrow();
            a.returnMovie();
            a.Borrow();
            a.returnMovie();
            a.Borrow();
            a.returnMovie();
            a.Borrow();
            a.returnMovie();
            a.Borrow();
            a.returnMovie();
            a.Borrow();
            a.returnMovie();
            a.Borrow();
            a.returnMovie();


            b.Borrow();
            b.returnMovie();
            b.Borrow();
            b.returnMovie();
            b.Borrow();
            b.returnMovie();

      

            DVDS.Add(new Movie( "Night at the Museum",1,Movie.Genres.Adventure,108,"2014", "Ben Stiller","Shawn Dyke",Movie.Classifications.ParentalGuidance));

            DVDS.Add(a);
            DVDS.Add(c);
            DVDS.Add(b);
            DVDS.Add(d);
            DVDS.Add(e);
            DVDS.Add(a);


            displayTop10(DVDS);

            Console.ReadKey();
            DVDS.Add(new Movie("A", 1));
            DVDS.Add(new Movie("L", 1));
            DVDS.Add(new Movie("B", 1));
            DVDS.Add(new Movie("C", 1));
            DVDS.Add(new Movie("123", 1));
            DVDS.Add(new Movie("Hello Ketty", 1));
            DVDS.Add(new Movie("Jackie", 1));
            DVDS.Add(new Movie("Noon", 1));
            DVDS.Add(new Movie("Sex and the City 1", 1));
            DVDS.Add(new Movie("Sex and the City 2", 1));
            DVDS.Add(new Movie("123", 1));
            DVDS.Add(new Movie("Zoroo", 1));
            DVDS.Add(new Movie("ZZZ", 1));
            DVDS.Add(new Movie("ZZZ", 2));
            
            
            displayTop10(DVDS);
            Console.ReadKey();

            DVDS.borrow("Sex and the City 1");
            DVDS.borrow("zzz");
            DVDS.borrow("123");

            DVDS.borrow("Night at the Museum");
            DVDS.borrow("Night at the Museum");


            DVDS.borrow(a.title);
            display(DVDS);
            displayTop10(DVDS);
            Console.ReadKey();
        }

        private static void displayTop10(MovieCollection DVDS)
        {
            Console.WriteLine("********top**10*************");
           int  counter = 0;
            Movie[] movies = DVDS.TopTen();
            if (movies.Length == 0)
            {
                Console.WriteLine("collection is empty!");
                return;
            }
            foreach (Movie m in movies)
            {
                if (m.timesBorrowed>0)
                {
                    Console.WriteLine((counter+1)+".  "+m.toString10());
                    
                }else
                {
                    Console.WriteLine((counter+1)+".");
                }

                counter++;

            }

        }

        private static void display(MovieCollection DVDS)
        {
            Console.WriteLine("*************************");
            int counter = 0;
            Movie[] a = DVDS.ToArray();
            if (a.Length == 0)
            {
                Console.WriteLine("collection is empty!");
                return;
            }
            foreach (Movie m in a)
            {
                
                    Console.WriteLine(m.toString());
                    counter++;
              
            
            }
            Console.WriteLine("Counter:{0}", counter);
        }
    }
}
