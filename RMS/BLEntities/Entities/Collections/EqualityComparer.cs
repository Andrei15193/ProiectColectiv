using System;
using System.Collections.Generic;

namespace ResourceManagementSystem.BusinessLogic.Entities.Collections
{
    class EqualityComparer<T> : IEqualityComparer<T>
    {
        public EqualityComparer(Func<T, T, bool> equalityFunction, Func<T, int> hashCodeFunction)
        {
            this.equalityFunction = equalityFunction;
            this.hashCodeFunction = hashCodeFunction;
        }

        public bool Equals(T x, T y)
        {
            return equalityFunction(x, y);
        }

        public int GetHashCode(T obj)
        {
            return hashCodeFunction(obj);
        }

        private Func<T, T, bool> equalityFunction;
        private Func<T, int> hashCodeFunction;
    }
}
