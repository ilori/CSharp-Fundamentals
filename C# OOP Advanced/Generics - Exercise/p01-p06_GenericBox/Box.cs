namespace p01_GenericBox
{
    using System;
    using System.Collections.Generic;
    using System.Text;

    public class Box<T> : IComparable<T>
        where T : IComparable<T>

    {
        private readonly List<T> items;

        public Box()
        {
            this.items = new List<T>();
        }

        public void Add(T element)
        {
            this.items.Add(element);
        }

        public void SwapElementPositions(int[] args)
        {
            int firstIndex = args[0];
            int secondIndex = args[1];

            T firstElement = this.items[firstIndex];
            T secondElement = this.items[secondIndex];

            this.items[firstIndex] = secondElement;
            this.items[secondIndex] = firstElement;
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
            StringBuilder sb = new StringBuilder();

            foreach (var item in items)
            {
                sb.AppendLine($"{item.GetType().FullName}: {item}");
            }

            return sb.ToString().Trim();
        }
    }
}