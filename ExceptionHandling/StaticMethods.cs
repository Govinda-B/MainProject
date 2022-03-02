using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ExceptionHandling
{
    public class StaticMethods
    {
        public static double SafeDiv(double x, double y)
        {
            if (y == 0)
                throw new DivideByZeroException();
            return x / y;
        }
        public static int GetInt(int[] array, int index)
        {
            try
            {
                return array[index];
            }
            catch (IndexOutOfRangeException e) when (index < 0)
            {
                throw new ArgumentOutOfRangeException(
                    "Parameter index cannot be negative.", e);
            }
            catch (IndexOutOfRangeException e)
            {
                throw new ArgumentOutOfRangeException(
                    "Parameter index cannot be greater than the array size.", e);
            }
        }
    }
}
