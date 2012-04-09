using System;

namespace LifeCycleTest
{
    public class Item<T,TS> : Tuple<T,TS>
    {
        // vs2010
        // open ssh
        // cloned command line
        public Item(T item1, TS item2) : base(item1, item2)
        {
        }
    }
    
}