using System;

namespace LifeCycleTest
{
    class Item<T,TS> : Tuple<T,TS>
    {
        public Item(T item1, TS item2) : base(item1, item2)
        {
        }
    }
    
}