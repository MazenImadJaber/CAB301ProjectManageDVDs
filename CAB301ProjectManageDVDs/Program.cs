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
            Movie e = new Movie("Legally Blode", 1);
     
            DVDS.Add(a);
     
         
      
            DVDS.Add(c);


            DVDS.Add(b);
            DVDS.Add(d);
            DVDS.Add(e);
            DVDS.Add(a);
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
            Console.WriteLine("*************************");
            foreach (Movie m in DVDS.ToArray())
            {
                Console.WriteLine(m.ToString());
            }
            DVDS.Remove("ZZZ");

            DVDS.Remove("123");
            DVDS.Remove("A");


            Console.WriteLine("*************************");
            foreach (Movie m in DVDS.ToArray())
            {
                Console.WriteLine(m.ToString());
            }
            Console.ReadKey();
        }
    }
}
