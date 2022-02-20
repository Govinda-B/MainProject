using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Attributes
{
    using System;
    [AttributeUsage(AttributeTargets.Class, AllowMultiple = true)]
    public class AuthorAttribute : Attribute
    {
        private string name;
        public AuthorAttribute(string name)
        {
            this.name = name;
        }
        public string Name
        {
            get { return name; }
        }
    }
}
