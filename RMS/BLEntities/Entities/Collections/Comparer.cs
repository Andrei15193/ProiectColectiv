using System;
using System.Collections.Generic;

namespace ResourceManagementSystem.BusinessLogic.Entities.Collections
{
    class Comparer<T> : IComparer<T>
    {
        public Comparer(Func<T, T, int> compareFunction)
        {
            this.compareFunction = compareFunction;
        }

        public int Compare(T right, T left)
        {
            if (right != null)
                if (left != null)
                    return compareFunction(right, left);
                else
                    throw new ArgumentNullException("The provided left value cannot be null!");
            else
                throw new ArgumentNullException("The provided right value cannot be null!");
        }

        private Func<T, T, int> compareFunction;
    }
}
