using System;

namespace ResourceManagementSystem.BusinessLogic.Entities.Collections
{
    public class CollectionChangedEventArgs<T> : EventArgs
    {
        public CollectionChangedEventArgs(T item, CollectionChange changeState)
        {
            Item = item;
            ChangeState = changeState;
        }

        public T Item { get; private set; }

        public CollectionChange ChangeState { get; private set; }
    }
}
