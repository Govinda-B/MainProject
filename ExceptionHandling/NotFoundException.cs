using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ExceptionHandling
{
    public class NotFoundException:Exception
    {
        public NotFoundException(string message):base(message)
        {
        }
    }
    //public class FileNotFoundException : NotFoundException
    //{
    //    public FileNotFoundException(string message) : base(message)
    //    {
    //    }
    //}
    //public class DirectoryNotFoundException : NotFoundException
    //{
    //    public DirectoryNotFoundException(string message) : base(message)
    //    {
    //    }
    //}
}
