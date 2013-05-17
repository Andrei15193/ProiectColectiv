using System;
using System.Collections.Generic;

namespace ResourceManagementSystem.BusinessLogic.Entities.Collections
{
    public interface IObservableCollection<T> : ICollection<T>
    {
        event EventHandler<CollectionChangedEventArgs<T>> CollectionChanging;
    }
}
