namespace p04_BubbleSortTests
{
    using System.Collections.Generic;
    using System.Linq;
    using NUnit.Framework;
    using p04_BubbleSort;

    public class BubbleSortTests
    {
        [TestCase(4, 5, 1, 3, 2, 7, 9, 8, 10, 6)]
        public void TestVBubbleSortAlgorithmMethod(params int[] values)
        {
            Bubble bubble = new Bubble();

            List<int> sortedElements = bubble.SortedElements(values.ToList());

            bubble.Sort(values);

            Assert.That(values, Is.EquivalentTo(sortedElements.ToArray()));
        }
    }
}