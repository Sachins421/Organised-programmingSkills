using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;


namespace LINQAndExtensionMethod
{
    public class DeckSet<T> : IEnumerable<T>
    {
        private List<T> _Inner = new List<T>();

        public IEnumerator<T> GetEnumerator()
        {
            return _Inner.GetEnumerator();
        }

        IEnumerator IEnumerable.GetEnumerator()
        {
            return _Inner.GetEnumerator();
        }

        public DeckSet<T> Add(T item)
        {
            if (item == null) 
                throw new ArgumentNullException("item");
            var InsertAt = _Inner.Count == 0 ? 0 : new Random().Next(0,_Inner.Count()+1);
            _Inner.Insert(InsertAt,item);
            return this;
        }

        public DeckSet<T> Shuffle()
        {
            _Inner = _Inner.OrderBy(s => Guid.NewGuid()).ToList();
            return this;
        }

    }
}
