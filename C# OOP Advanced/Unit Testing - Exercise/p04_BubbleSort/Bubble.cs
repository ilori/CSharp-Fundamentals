namespace p04_BubbleSort
{
    using System.Collections.Generic;
    using System.Linq;

    public class Bubble
    {
        public void Sort(int[] elements)
        {
            bool swap = true;

            while (swap)
            {
                swap = false;

                for (int i = 1; i < elements.Length; i++)
                {
                    if (elements[i - 1] > elements[i])
                    {
                        int tempElement = elements[i - 1];

                        elements[i - 1] = elements[i];

                        elements[i] = tempElement;

                        swap = true;
                    }
                }
            }
        }

        public List<int> SortedElements(List<int> elements)
        {
            List<int> sortedElements = new List<int>(elements);

            sortedElements.Sort();

            return sortedElements;
        }
    }
}