namespace p07_CustomList
{
    using System;
    using System.Collections.Generic;
    using System.Linq;

    public class CustomList<T> where T : IComparable<T>
    {
        private List<T> items;

        public CustomList()
        {
            this.items = new List<T>();
        }

        public void Add(T element)
        {
            this.items.Add(element);
        }

        public T Remove(int index)
        {
            T element = this.items[index];

            this.items.RemoveAt(index);

            return element;
        }

        public bool Contains(T element)
        {
            foreach (var item in items)
            {
                if (EqualityComparer<T>.Default.Equals(item, element))
                {
                    return true;
                }
            }

            return false;
        }

        public void Swap(int index1, int index2)
        {
            T firstElement = this.items[index1];
            T secondElement = this.items[index2];

            this.items[index1] = secondElement;
            this.items[index2] = firstElement;
        }

        public int CountGreaterThan(T element)
        {
            int result = this.CompareTo(element);

            return result;
        }

        public T Max()
        {
            return this.items.Max();
        }

        public T Min()
        {
            return this.items.Min();
        }

        public void Sort()
        {
            this.items = this.items.OrderBy(x => x).ToList();
        }

        public int CompareTo(T other)
        {
            int count = 0;

            foreach (var item in items)
            {
                if (item.CompareTo(other) > 0)
                {
                    count += item.CompareTo(other);
                }
            }

            return count;
        }

        public override string ToString()
        {
            return $"{string.Join(Environment.NewLine, this.items)}";
        }
    }
}