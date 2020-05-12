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
            
            
            
        }
    }
}
