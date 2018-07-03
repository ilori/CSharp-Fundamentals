namespace p01_Box.Models
{
    using System.Collections.Generic;
    using System.Linq;
    using Contracts;

    public class Box<T> : IBox<T>
    {
        public Box()
        {
            this.items = new List<T>();
        }

        private readonly List<T> items;


        public void Add(T element)
        {
            this.items.Add(element);
        }

        public T Remove()
        {
            T element = this.items.Last();

            this.items.RemoveAt(this.items.Count - 1);

            return element;
        }

        public int Count => this.items.Count;
    }
}