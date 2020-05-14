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

      

            DVDS.Add(new Movie("Night at the Museum",1,Movie.Genres.Adventure,108, "Ben Stiller","Shawn Dyke",Movie.Classifications.ParentalGuidance));

            DVDS.Add(a);
     
         
      
            DVDS.Add(c);


            DVDS.Add(b);
            DVDS.Add(d);
            DVDS.Add(e);
            DVDS.Add(a);


            Console.WriteLine("********top**10*************");
            int counter = 0;
            Movie[] movies = DVDS.TopTen();
            if (movies.Length == 0)
            {
                Console.WriteLine("collection is empty!");
                return;
            }
            foreach (Movie m in movies)
            {

                Console.WriteLine(m.toString10());
                counter++;


            }

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
            Console.WriteLine("********top**10*************");
            counter = 0;
           movies = DVDS.TopTen();
            if (movies.Length == 0)
            {
                Console.WriteLine("collection is empty!");
                return;
            }
            foreach (Movie m in movies)
            {

                Console.WriteLine(m.toString10());
                counter++;


            }

            Console.ReadKey();
            display(DVDS);          

            DVDS.Remove("ZZZ");
            display(DVDS);
            DVDS.Remove("123");
            display(DVDS);
            DVDS.Remove("A");
            display(DVDS);
            DVDS.Remove("Superman");
            display(DVDS);

            DVDS.Remove("Sex and the City 1");
            display(DVDS);
            DVDS.Remove("Sex and the City 2");
            display(DVDS);
            DVDS.Remove("Moonlight");
            display(DVDS);


            DVDS.Remove("B");
            display(DVDS);
            DVDS.Remove("noon");
            display(DVDS);
            DVDS.Remove("Zoroo");
            display(DVDS);
            DVDS.Remove("Legallyblode");
            display(DVDS);
            DVDS.Remove("Night at the Museum");
         
            display(DVDS);
            DVDS.Remove("jackie");
            display(DVDS);
            DVDS.Remove("helloketty");
            display(DVDS);
            DVDS.Remove("l");
            display(DVDS);
            DVDS.Remove("c");
            display(DVDS);
            DVDS.Remove("batman");
            display(DVDS);
          

            Console.ReadKey();
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
