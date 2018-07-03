namespace p03_Stack
{
    using System;
    using System.Collections;
    using System.Collections.Generic;
    using System.Linq;

    public class MyStack<T> : IEnumerable<T>
    {
        private readonly List<T> items;


        public MyStack()
        {
            this.items = new List<T>();
        }

        public void Push(params T[] elements)
        {
            this.items.AddRange(elements);
        }

        public void Pop()
        {
            if (!this.items.Any())
            {
                throw new InvalidOperationException("No elements");
            }

            this.items.RemoveAt(this.items.Count - 1);
        }


        public IEnumerator<T> GetEnumerator()
        {
            for (int i = 0; i < 2; i++)
            {
                for (int j = this.items.Count - 1; j >= 0; j--)
                {
                    yield return this.items[j];
                }
            }
        }

        IEnumerator IEnumerable.GetEnumerator()
        {
            return GetEnumerator();
        }
    }
}