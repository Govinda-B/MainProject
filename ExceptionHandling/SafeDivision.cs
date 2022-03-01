using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ExceptionHandling
{
    public class SafeDivision
    {
        public static double SafeDiv(double x, double y)
        {
            if (y == 0)
                throw new DivideByZeroException();
            return x / y;
        }
    }
}
