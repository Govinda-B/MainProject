using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Attributes.Logging
{
    public class Logging
    {
        [Conditional("LOG_INFO")]
        public static void LogToScreen(string msg)
        {
            Console.WriteLine(msg);
        }
    }
}
