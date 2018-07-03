namespace p04_Froggy
{
    using System.Collections;
    using System.Collections.Generic;

    public class Lake<T> : IEnumerable<T> where T : struct
    {
        private readonly List<T> items;

        private readonly List<T> finalOrder;

        public Lake(params T[] elements)
        {
            this.items = new List<T>(elements);
            this.finalOrder = new List<T>();
            this.OrderItems();
        }


        private void OrderItems()
        {
            for (int i = 0; i < this.items.Count; i++)
            {
                if (i % 2 == 0)
                {
                    this.finalOrder.Add(this.items[i]);
                }
            }

            for (int i = this.items.Count - 1; i >= 0; i--)
            {
                if (i % 2 != 0)
                {
                    this.finalOrder.Add(this.items[i]);
                }
            }
        }

        public IEnumerator<T> GetEnumerator()
        {
            foreach (var item in finalOrder)
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