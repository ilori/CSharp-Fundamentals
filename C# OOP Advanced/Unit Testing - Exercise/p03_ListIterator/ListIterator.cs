namespace p03_ListIterator
{
    using System;
    using System.Collections.Generic;

    public class ListIterator
    {
        private readonly List<string> items;
        private int currentIndex;
        

        public ListIterator(params string[] elements)
        {
            InitializeComponents(elements);

            this.items = new List<string>(elements);
        }

        public void InitializeComponents(string[] elements)
        {
            if (elements == null)
            {
                throw new ArgumentNullException();
            }
        }

        public bool Move() => this.currentIndex++ < this.items.Count;

        public bool HasNext() => this.currentIndex < this.items.Count - 1;

        public string Print()
        {
            if (this.items.Count == 0)
            {
                throw new InvalidOperationException("Invalid Operation!");
            }

            return this.items[this.currentIndex];
        }
    }
}