using System;
using System.Collections.Generic;

namespace ResourceManagementSystem.BusinessLogic.Entities.Collections
{
    class EqualityComparer<T> : IEqualityComparer<T>
    {
        public EqualityComparer(Func<T, T, bool> compareFunction)
        {
            this.compareFunction = compareFunction;
        }

        public bool Equals(T right, T left)
        {
            if (right != null)
                if (left != null)
                    return compareFunction(right, left);
                else
                    throw new ArgumentNullException("The provided left value cannot be null!");
            else
                throw new ArgumentNullException("The provided right value cannot be null!");
        }

        public int GetHashCode(T obj)
        {
            if (obj != null)
                return obj.GetHashCode();
            else
                throw new ArgumentNullException("The provided value cannot be null!");
        }

        private Func<T, T, bool> compareFunction;
    }
}
