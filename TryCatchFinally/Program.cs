using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TryCatchFinally
{
    class Program
    {
        static void Main(string[] args)
        {
            // create an array of ints, then process the array
            // to exercise the caught exceptions
            // use the finally block to write out the error message

            int [] myInts = { 1, 2, 3, 4, 5, 6, 10, 7, };

            foreach (int item in myInts)
            {
                Console.WriteLine("{0}", item);
            }

            int result = 0;
            int divisor = 0;
            int i = 0;
            try
            {
                foreach (int item in myInts)
                {
                    i = item;
                    divisor = item % 2;
                    result = item / divisor;
                    Console.WriteLine("{0}", item);
                }
            }
            catch (DivideByZeroException e)
            {
                Console.WriteLine("{0}", e.Message);
            }
            finally
            {
                Console.WriteLine("{0} / {1} - caused the problem", i, divisor);

            }
            Console.ReadKey();
        }
       
    }
}
