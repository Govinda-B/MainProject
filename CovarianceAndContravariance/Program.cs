﻿using System;
using System.Collections.Generic;
using System.Linq;

namespace CovarianceAndContravariance
{
    class Program
    {
        public delegate Parent ParentDelegate(Child child);
        public delegate R NewDelegate<R,P>(P p);
        static void Main(string[] args)
        {

            Parent parent2 = new Parent() { Name = "gvd" };
            Child child3 = new Child() { Name = "gvd" };
            ParentDelegate parentToChildDelegate = GetChildFromParent;
            ParentDelegate parentToParentDelegate = GetParent;
            ParentDelegate childToChildFDelegate = GetChild;
            ParentDelegate childToParentDelegate = GetParentFromChild;

            Parent child2 = parentToChildDelegate(child3);
            Parent child4 = parentToParentDelegate(child3);
            Parent child5 = childToParentDelegate(child3);
            //Parent child6 = childToChildDelegate(child3);



            // Assignment compatibility.
            string str = "test";
            // An object of a more derived type is assigned to an object of a less derived type.
            object obj = str;
            Console.WriteLine(obj);

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


            //Covariance in Interfaces
            IReadOnlyList<string> newstring = new List<string>();
            IReadOnlyList<object> newobject = newstring;


            //Contravariance in Interfaces
            IEqualityComparer<BaseClass> baseComparer = new BaseComparer();

            // Implicit conversion of IEqualityComparer<BaseClass> to
            // IEqualityComparer<DerivedClass>.
            IEqualityComparer<DerivedClass> childComparer = baseComparer;

            IEnumerable<int> integers = new List<int>();
            // The following statement generates a compiler error,
            // because int is a value type.
            // IEnumerable<Object> objects = integers;

            // The following line generates a compiler error
            // because classes are invariant.
            // List<Object> list = new List<String>();

            // You can use the interface object instead.
            IEnumerable<Object> listObjects = new List<String>();


            //ContraVarient Delegates
            Action<Parent> Print = PrintParent;
            Parent parent = new Parent();
            parent.Name = "Dinesh";
            Print(parent);
            Action<Child> PrintChild = PrintParent;
            Child child = new Child();
            child.Name = "Pranav";
            PrintChild(child);

            //Covarient Delegates
            Func<string, Parent> CreateParent = CreateChild;
            Func<string, Child> Create = CreateChild;
            Parent parent1 = CreateParent("abc");
            Child child1 = Create("def");



        }

        static Child CreateChild(string name)
        {
            return new Child() { Name=name};
        }

        static void PrintParent(Parent parent)
        {
            Console.WriteLine(parent.Name);
        }

        public static Parent GetParent(Parent parent)
        {
            return parent;
        }

        public static Parent GetParentFromChild(Child child)
        {
            return new Parent();
        }

        public static Child GetChild(Child child)
        {
            return child;
        }

        public static Child GetChildFromParent(Parent parent)
        {
            return new Child();
        }
        static void SetObject(object o) { }
        static object GetObject() { return null; }

        static string GetString() { return ""; }
        static void SetString(string str) { }
    }
}
