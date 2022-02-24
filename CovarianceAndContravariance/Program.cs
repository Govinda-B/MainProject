using System;
using System.Collections.Generic;

namespace CovarianceAndContravariance
{
    class Program
    {
        static void Main(string[] args)
        {
            
            // Assignment compatibility.
            string str = "test";
            // An object of a more derived type is assigned to an object of a less derived type.
            object obj = str;
            //Console.WriteLine(obj);

            // Covariance.
            IEnumerable<string> strings = new List<string>();
            IEnumerable<object> objects = strings;

            // Contravariance.
            Action<object> actObject = SetObject;
            Action<string> actString = actObject;


            //Issue Of type Safety
            object[] array = new String[10];
            try
            {
                array[0] = 10;
            }
            catch (Exception e)
            {

                Console.WriteLine(e.Message);
            }

            // Covariance. A delegate specifies a return type as object,  
            // but you can assign a method that returns a string.  
            Func<object> del = GetString;

            // Contravariance. A delegate specifies a parameter type as string,  
            // but you can assign a method that takes an object.  
            Action<string> del2 = SetObject;


            //implicit reference conversion for generic interfaces
            IEnumerable<String> strings1 = new List<String>();
            IEnumerable<Object> objects1 = strings1;

        }
        static void SetObject(object o) { }
        static object GetObject() { return null; }

        static string GetString() { return ""; }
        static void SetString(string str) { }
    }
}
