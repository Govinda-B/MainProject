using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.InteropServices;
using System.Text;
using System.Threading.Tasks;

namespace Attributes
{
    [Author("Brian Kernighan"), Author("Dennis Ritchie")]
    class Book
    {
        [Obsolete]
        public static int Addition(int a, int b)
        {
            return a + b;
        }
        public static int Addition(List<int> numbers)
        {
            int addition=0;
            foreach (var item in numbers)
            {
                addition += item;
            }
            return addition;
        }
        public static void Square([In,Out]ref int number)
        {
            number *= number;
        }
    }
}
