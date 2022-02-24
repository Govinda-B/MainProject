using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CovarianceAndContravariance
{
    // Simple hierarchy of classes.
    class BaseClass { }
    class DerivedClass : BaseClass { }

    // Comparer class.
    class BaseComparer : IEqualityComparer<BaseClass>
    {
        public int GetHashCode(BaseClass baseInstance)
        {
            return baseInstance.GetHashCode();
        }
        public bool Equals(BaseClass x, BaseClass y)
        {
            return x == y;
        }
    }
}
