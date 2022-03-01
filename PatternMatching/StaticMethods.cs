using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PatternMatching
{
    class StaticMethods
    {
        public static T MidPoint<T>(IEnumerable<T> sequence)
        {
            if (sequence is IList<T> list && sequence.Count() !=0)
            {
                return list[list.Count / 2];
            }
            else if (sequence is null || sequence.Count() is 0)
            {
                throw new ArgumentNullException(nameof(sequence), "Sequence can't be null.");
            }
            else
            {
                int halfLength = sequence.Count() / 2 - 1;
                if (halfLength < 0) 
                    halfLength = 0;
                return sequence.Skip(halfLength).First();
            }
        }
    }
}
