using System.Collections;
using System.Collections.Generic;

namespace TrainingPrep.collections
{
    public class ReadOnlySet <TItem>: IEnumerable<TItem>
    {
        private readonly IEnumerable<TItem> _item;

        public ReadOnlySet(IEnumerable<TItem> item)
        {
            _item = item;
        }

        public IEnumerator<TItem> GetEnumerator()
        {
            return _item.GetEnumerator();
        }

        IEnumerator IEnumerable.GetEnumerator()
        {
            return GetEnumerator();
        }
    }
}