using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LinqDemo
{
    public class Queries
    {
        public static IEnumerable<string> QueryMethod1(int[] ints)
        {
            return
            from i in ints
            where i > 4
            select i.ToString();
        }
        
            

        // QueryMethod2 returns a query as the value of the out parameter returnQ
        public static void QueryMethod2(int[] ints, out IEnumerable<string> returnQ)
        {
            returnQ =from i in ints
                     where i < 4
                     select i.ToString();
        }
            
            

    }
}
