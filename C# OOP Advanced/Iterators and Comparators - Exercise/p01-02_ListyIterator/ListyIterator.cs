namespace p01_ListyIterator
{
    using System;
    using System.Collections;
    using System.Collections.Generic;
    using System.Linq;

    public class ListyIterator<T> : IEnumerable<T>
    {
        private readonly List<T> list;

        private int index;

        public ListyIterator(params T[] items)
        {
            this.list = new List<T>(items);
            this.index = 0;
        }

        public bool Move()
        {
            if (this.index + 1 < this.list.Count)
            {
                index++;
                return true;
            }

            return false;
        }

        public bool HasNext()
        {
            return index + 1 < this.list.Count;
        }

        public string PrintAll()
        {
            return string.Join(" ", this.list);
        }

        public T Print()
        {
            if (!this.list.Any())
            {
                throw new InvalidOperationException("Invalid Operation!");
            }

            return this.list[index];
        }

        public IEnumerator<T> GetEnumerator()
        {
            foreach (var item in list)
            {
                yield return item;
            }
        }

        IEnumerator IEnumerable.GetEnumerator()
        {
            return GetEnumerator();
        }
    }
}