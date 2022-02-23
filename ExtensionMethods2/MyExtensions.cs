//using System;

//namespace ExtensionMethods2
//{
//    public static class MyExtensions2
//    {
//        public static int WordCount(this string str)
//        {
//            return str.Split(new char[] { ' ', '.', '?' },
//                             StringSplitOptions.RemoveEmptyEntries).Length;
//        }

//        public static string[] SentanceSplit(this string str)
//        {
//            return str.Split(new char[] { ' ', '.', '?' },
//                             StringSplitOptions.RemoveEmptyEntries);
//        }
//        public static string FullName(this DomainEntity value)
//        {
//            return $"{value.FirstName} {value.LastName}";
//        }
//    }
//}
