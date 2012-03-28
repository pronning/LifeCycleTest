using System;

namespace LifeCycleTest
{
    class Item<T,TS> : Tuple<T,TS>
    {
        // vs2010
        // open ssh
        public Item(T item1, TS item2) : base(item1, item2)
        {
        }
    }
    
}