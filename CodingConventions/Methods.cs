using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CodingConventions
{
    public class Methods
    {
        // Use a try-catch statement for most exception handling.
        public static string GetValueFromArray(string[] array, int index)
        {
            try
            {
                return array[index];
            }
            catch (System.IndexOutOfRangeException ex)
            {
                Console.WriteLine("Index is out of range: {0}", index);
                throw;
            }
        }
    }
}
