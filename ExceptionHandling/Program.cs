using System;
using System.IO;

namespace ExceptionHandling
{
    class Program
    {

        static void Main(string[] args)
        {
            double a = 98, b = 0;
            double result;

            try
            {
                result = StaticMethods.SafeDiv(a, b);
                Console.WriteLine("{0} divided by {1} = {2}", a, b, result);
            }
            catch (DivideByZeroException ex)
            {
                Console.WriteLine("Attempted divide by zero.");
                Console.WriteLine(ex.Message);
                //throw;
            }
            finally
            {
                Console.WriteLine("Done with execution");
            }
            Console.WriteLine("\n\n\n");
            try
            {
                throw new NotFoundException("File Not Found");
            }
            catch (NotFoundException ex)
            {
                Console.WriteLine(ex.Message);
            }
            finally
            {
                Console.WriteLine("Done with execution");
            }
            Console.WriteLine("\n\n");
            try
            {
                using (var sw = new StreamWriter("C/ffffff/test.txt"))
                {
                    sw.WriteLine("Hello");
                }
            }
            // Put the more specific exceptions first.
            catch (DirectoryNotFoundException ex)
            {
                Console.WriteLine(ex.Message);
            }
            catch (FileNotFoundException ex)
            {
                Console.WriteLine(ex.Message);
            }
            // Put the least specific exception last.
            catch (IOException ex)
            {
                Console.WriteLine(ex.Message);
            }
            int[] intarray = { 1, 2, 3, 4, 5, 6, 7 };
            try
            {
                StaticMethods.GetInt(intarray, -5);
            }
            catch (Exception ex)
            {
                Console.WriteLine(ex.Message);
            }
            
        }
        
    }
}
