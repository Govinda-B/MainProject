﻿using System;
using System.Collections.Generic;
using System.Reflection;

//[assembly : AssemblyVersion("2.0.1")]
[assembly: AssemblyDescription("My Assembly Description")]
namespace Attributes
{
    class Program
    {
        static void Main(string[] args)
        {
            int add = Book.Addition(1, 2);
            int add2 = Book.Addition(new List<int> { 1, 2, 3, 4 });
            Console.WriteLine(add+"\n"+add2);


            int number = 5;
            Book.Square(ref number);
            Console.WriteLine(number);

            Assembly assembly = typeof(Program).Assembly;
            AssemblyName assemblyName = assembly.GetName();
            Version version = assemblyName.Version;
            object[] attributes =
                assembly.GetCustomAttributes(typeof(AssemblyDescriptionAttribute),false);
            var assemblydescriptionattribute = attributes[0] as AssemblyDescriptionAttribute;
            Console.WriteLine("Assembly name : "+assemblyName);
            Console.WriteLine("Assembly Version : "+version);
            if (assemblydescriptionattribute!= null)
            {
                Console.WriteLine("Assembly Description : "+
                    assemblydescriptionattribute.Description);
            }

            Book book = new Book { newstring = "ssss" };
            Console.WriteLine(book.newstring);
            
            Product product = new Product { Id = 1 };
            Console.WriteLine(product.Id);
            Console.WriteLine(product.Name);

            Console.WriteLine(book.newstring);

            Registration registration = new Registration();
            Console.WriteLine("Enter Email id");
            registration.Email = Console.ReadLine();
            Console.WriteLine(registration.Email);
            Console.ReadKey();

        }
    }
}
