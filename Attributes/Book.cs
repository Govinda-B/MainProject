using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Runtime.InteropServices;
using System.Text;
using System.Threading.Tasks;

namespace Attributes
{
    [Author("Brian Kernighan")]
    class Book
    {
        [MinLength(length:20,ErrorMessage ="Minimum length should be 20")] 
        public string newstring { get; set; }
        [EmailAddress(ErrorMessage ="Enter a valid email address")]
        [Required(ErrorMessage ="Field can not be empty")]
        public string email { get; set; }
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
