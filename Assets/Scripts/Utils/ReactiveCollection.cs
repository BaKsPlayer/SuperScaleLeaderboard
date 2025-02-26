using System;
using System.Collections;
using System.Collections.Generic;

namespace SC.Utils
{
    public class ReactiveCollection<T> : IEnumerable<T>
    {
        public event Action CollectionChanged;

        private readonly List<T> _items;

        public ReactiveCollection()
        {
            _items = new List<T>();
        }

        public ReactiveCollection(IEnumerable<T> collection)
        {
            _items = new List<T>(collection);
        }

        public void Add(T item)
        {
            _items.Add(item);
            CollectionChanged?.Invoke();
        }

        public void AddRange(IEnumerable<T> items)
        {
            _items.AddRange(items);
            CollectionChanged?.Invoke();
        }

        public bool Remove(T item)
        {
            bool removed = _items.Remove(item);
            if (removed)
            {
                CollectionChanged?.Invoke();
            }
            return removed;
        }

        public void Clear()
        {
            if (_items.Count > 0)
            {
                _items.Clear();
                CollectionChanged?.Invoke();
            }
        }

        public int Count => _items.Count;

        public T this[int index]
        {
            get => _items[index];
            set
            {
                if (!_items[index].Equals(value))
                {
                    _items[index] = value;
                    CollectionChanged?.Invoke();
                }
            }
        }

        public bool Contains(T item) => _items.Contains(item);

        public IEnumerator<T> GetEnumerator() => _items.GetEnumerator();

        IEnumerator IEnumerable.GetEnumerator() => GetEnumerator();

        public override string ToString()
        {
            return string.Join(", ", _items);
        }
    }
}