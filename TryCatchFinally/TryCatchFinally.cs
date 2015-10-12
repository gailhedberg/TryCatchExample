using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.IO;
/*
* this program demonstrates the use of try -catch - finally block in c#
* errors caught are written to a local file
*/

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
            int result = 0;
            int divisor = 0;
            int i = 0;
            string[] myErrors = new string[2];

            try
            {
                foreach (int item in myInts)
                {
                    Console.WriteLine("{0}", item);
                }

                // go through the list and cause some errors
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
                myErrors[myErrors.Count() - 1] = e.Message;
                Console.WriteLine("{0}", e.Message);
                Console.WriteLine("{0} / {1} - caused the problem", i, divisor);

            }
            catch (Exception ex)
            {
                myErrors[myErrors.Count() - 1] = ex.Message;
                Console.WriteLine("An error occurred");
                Console.WriteLine(ex.GetType().Name);
                Console.WriteLine(ex.Message);
            }
            finally
            {
                Console.WriteLine("finally block");
                WriteToTheLog(myErrors);
            }

            Console.ReadKey();
        }
        static void WriteToTheLog(string [] msgs)
        {
            try
            {
                string path = Directory.GetCurrentDirectory();
                path += @"\ErrorLog.txt";
                StreamWriter writer = new StreamWriter(path);
                Console.WriteLine("Writing error message to loc: {0}", path);
                writer.WriteLine("Error found in TryCatchFinally.cs file.");
                foreach (string item in msgs)
                {
                    writer.WriteLine("{0}", item);
                }
                writer.Close();
            }
            catch (Exception ex)
            {
                Console.WriteLine("An error occurred");
                Console.WriteLine(ex.GetType().Name);
                Console.WriteLine(ex.Message);
            }
          }
       
    }
}
