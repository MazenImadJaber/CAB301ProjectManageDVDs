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
            Console.WriteLine("Adding a movie without input");
            Movie a = new Movie();
            Console.WriteLine("name: {0}", a.name);
            Console.WriteLine("numberOfAvailableCopies: {0}", a.numberOfAvailableCopies);
            Console.WriteLine("numberOfCopies: {0}", a.numberOfCopies);
            Console.WriteLine("timesBorrowed: {0}", a.timesBorrowed);

            Console.WriteLine("Adding Batman as a movie with title only");
            Movie b = new Movie("BAtman");
            Console.WriteLine("name: {0}", b.name);
            Console.WriteLine("numberOfAvailableCopies: {0}", b.numberOfAvailableCopies);
            Console.WriteLine("numberOfCopies: {0}", b.numberOfCopies);
            Console.WriteLine("timesBorrowed: {0}", b.timesBorrowed);

            Movie queen = new Movie("Kween", 10);
            Console.WriteLine("name: {0}",queen.name);
            Console.WriteLine("numberOfAvailableCopies: {0}", queen.numberOfAvailableCopies);
            Console.WriteLine("numberOfCopies: {0}", queen.numberOfCopies);
            Console.WriteLine("timesBorrowed: {0}", queen.timesBorrowed);


            Console.WriteLine("after three borrow() calls");
            queen.Borrow();
            queen.Borrow();
            queen.Borrow();           
            Console.WriteLine("numberOfAvailableCopies: {0}", queen.numberOfAvailableCopies);
            Console.WriteLine("numberOfCopies: {0}", queen.numberOfCopies);
            Console.WriteLine("timesBorrowed: {0}", queen.timesBorrowed);
            
            Console.WriteLine("after  borrow(2) call");
            queen.Borrow(2);           
            Console.WriteLine("numberOfAvailableCopies: {0}", queen.numberOfAvailableCopies);
            Console.WriteLine("numberOfCopies: {0}", queen.numberOfCopies);
            Console.WriteLine("timesBorrowed: {0}", queen.timesBorrowed);


   
            Console.WriteLine("after  borrow(6) call");
            queen.Borrow(6);
            Console.WriteLine("numberOfAvailableCopies: {0}", queen.numberOfAvailableCopies);
            Console.WriteLine("numberOfCopies: {0}", queen.numberOfCopies);
            Console.WriteLine("timesBorrowed: {0}", queen.timesBorrowed);

            Console.WriteLine("after  borrow(5) call");
            queen.Borrow(5);          
            Console.WriteLine("numberOfAvailableCopies: {0}", queen.numberOfAvailableCopies);
            Console.WriteLine("numberOfCopies: {0}", queen.numberOfCopies);
            Console.WriteLine("timesBorrowed: {0}", queen.timesBorrowed);

            Console.WriteLine("after  borrow() ");
            queen.Borrow();         
            Console.WriteLine("numberOfAvailableCopies: {0}", queen.numberOfAvailableCopies);
            Console.WriteLine("numberOfCopies: {0}", queen.numberOfCopies);
            Console.WriteLine("timesBorrowed: {0}", queen.timesBorrowed);


            Console.WriteLine("after  addCopies(0) ");
            queen.AddCopies(0);
            Console.WriteLine("numberOfAvailableCopies: {0}", queen.numberOfAvailableCopies);
            Console.WriteLine("numberOfCopies: {0}", queen.numberOfCopies);
            Console.WriteLine("timesBorrowed: {0}", queen.timesBorrowed);

            Console.WriteLine("after  addCopies(3) ");
            queen.AddCopies(3);
            Console.WriteLine("numberOfAvailableCopies: {0}", queen.numberOfAvailableCopies);
            Console.WriteLine("numberOfCopies: {0}", queen.numberOfCopies);
            Console.WriteLine("timesBorrowed: {0}", queen.timesBorrowed);



            Console.WriteLine("after  returnMovie() ");
            queen.returnMovie();
            Console.WriteLine("numberOfAvailableCopies: {0}", queen.numberOfAvailableCopies);
            Console.WriteLine("numberOfCopies: {0}", queen.numberOfCopies);
            Console.WriteLine("timesBorrowed: {0}", queen.timesBorrowed);


            Console.WriteLine("after  returnMovie(0)");
            queen.returnMovie(0);
            Console.WriteLine("numberOfAvailableCopies: {0}", queen.numberOfAvailableCopies);
            Console.WriteLine("numberOfCopies: {0}", queen.numberOfCopies);
            Console.WriteLine("timesBorrowed: {0}", queen.timesBorrowed);

            Console.WriteLine("after  returnMovie(-1)");
            queen.returnMovie(-1);
            Console.WriteLine("numberOfAvailableCopies: {0}", queen.numberOfAvailableCopies);
            Console.WriteLine("numberOfCopies: {0}", queen.numberOfCopies);
            Console.WriteLine("timesBorrowed: {0}", queen.timesBorrowed);

            Console.WriteLine("after  returnMovie(10)");
            queen.returnMovie(10);
            Console.WriteLine("numberOfAvailableCopies: {0}", queen.numberOfAvailableCopies);
            Console.WriteLine("numberOfCopies: {0}", queen.numberOfCopies);
            Console.WriteLine("timesBorrowed: {0}", queen.timesBorrowed);

            Console.ReadKey();

        }
    }
}
