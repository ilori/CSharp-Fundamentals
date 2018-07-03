namespace p08_CustomLinkedListTests
{
    using NUnit.Framework;
    using p08_CustomLinkedList;
    using System;

    public class CustomLinkedListTests
    {
        [Test]
        public void CannotCallElementWithNegativeIndex()
        {
            DynamicList<int> list = new DynamicList<int>();

            int index = -5;

            Assert.That(() => list[index], Throws.TypeOf(typeof(ArgumentOutOfRangeException)));
        }

        [Test]
        public void CannotCallElementWithGreaterThanTheCountIndex()
        {
            DynamicList<int> list = new DynamicList<int>();

            int index = 100;

            Assert.That(() => list[index], Throws.TypeOf(typeof(ArgumentOutOfRangeException)));
        }

        [TestCase(5)]
        [TestCase(3)]
        [TestCase(2)]
        [TestCase(1)]
        public void AddMethodShouldIncreaseTheCountOfTheCollection(int value)
        {
            DynamicList<int> list = new DynamicList<int>();


            for (int i = 0; i < value; i++)
            {
                list.Add(i);
            }

            Assert.That(list.Count, Is.EqualTo(value));
        }

        [TestCase(5, 0)]
        [TestCase(3, 2)]
        [TestCase(7, 4)]
        [TestCase(1, 0)]
        public void AddShouldSaveTheElementInTheCollection(int elements, int index)
        {
            DynamicList<int> list = new DynamicList<int>();

            for (int i = 0; i < elements; i++)
            {
                list.Add(i);
            }

            Assert.That(list[index], Is.EqualTo(index));
        }

        [Test]
        [TestCase(-32)]
        [TestCase(-3)]
        [TestCase(10)]
        [TestCase(1)]
        public void RemoveAtIndexOusideTheBoundariesOfTheCollectionIsImpossible(int indexToRemove)
        {
            DynamicList<int> list = new DynamicList<int>();

            Assert.That(() => list.RemoveAt(indexToRemove),
                Throws.TypeOf(typeof(ArgumentOutOfRangeException)));
        }

        [TestCase(3, 1)]
        [TestCase(10, 5)]
        [TestCase(10, 0)]
        [TestCase(10, 8)]
        public void RemoveAtShouldRemoveTheElementAtTheGivenIndex(int count, int indexToRemove)
        {
            DynamicList<int> list = new DynamicList<int>();

            for (int i = 0; i < count; i++)
            {
                list.Add(i);
            }

            list.RemoveAt(indexToRemove);

            Assert.That(list[indexToRemove], Is.EqualTo(indexToRemove + 1));
        }

        [TestCase(3, 1)]
        [TestCase(5, 4)]
        [TestCase(10, 7)]
        public void IndexOfShouldReturnTheIndexPointingAtTheCurrentLocationOfTheElement(int count,
            int elementToSearch)
        {
            DynamicList<int> list = new DynamicList<int>();

            for (int i = 0; i < count; i++)
            {
                list.Add(i);
            }

            int expectedIndex = elementToSearch;


            int foundIndex = list.IndexOf(elementToSearch);

            Assert.That(foundIndex, Is.EqualTo(expectedIndex));
        }

        [Test]
        [TestCase(3, 3)]
        [TestCase(5, -1)]
        [TestCase(10, 15)]
        public void IndexOfShouldReturnNegativeIntegerIfTheGivenElementDoesNotExists(int count,
            int keyElement)
        {
            DynamicList<int> list = new DynamicList<int>();

            for (int i = 0; i < count; i++)
            {
                list.Add(i);
            }

            bool isReturnedValueLessThanZero = list.IndexOf(keyElement) < 0;

            Assert.That(isReturnedValueLessThanZero, Is.True);
        }

        [TestCase(3, 1)]
        [TestCase(25, 5)]
        [TestCase(11,6)]
        [TestCase(4, 1)]
        [TestCase(7, 3)]
        public void RemoveShouldDeleteParticularElement(int count, int elementToRemove)
        {
            DynamicList<int> list = new DynamicList<int>();

            for (int i = 0; i < count; i++)
            {
                list.Add(i);
            }

            Assert.That(list.IndexOf(elementToRemove), Is.EqualTo(elementToRemove));
        }

        [TestCase(5, 8)]
        [TestCase(3, -1)]
        [TestCase(5, 10)]
        public void RemoveUnexistentEelementShouldReturnNegativeInteger(int count, int elementToRemove)
        {
            DynamicList<int> list = new DynamicList<int>();

            for (int i = 0; i < count; i++)
            {
                list.Add(i);
            }

            bool isRemovingResultLesThanZero = list.Remove(elementToRemove) < 0;

            Assert.That(isRemovingResultLesThanZero, Is.True);
        }

        [TestCase(7, 1)]
        [TestCase(6, 2)]
        [TestCase(55, 12)]
        public void RemoveShouldReturnTheIndexOfTheRemovedElement(int count, int elementToRemove)
        {
            DynamicList<int> list = new DynamicList<int>();

            for (int i = 0; i < count; i++)
            {
                list.Add(i);
            }

            int expectedIndex = elementToRemove;

            int returnedIndex = list.Remove(elementToRemove);

            Assert.That(returnedIndex, Is.EqualTo(expectedIndex));
        }

        [TestCase(7, 0)]
        [TestCase(15, 3)]
        [TestCase(44, 6)]
        public void ContainsShouldReturnTrueIfElementExists(int count, int elementToSearch)
        {
            DynamicList<int> list = new DynamicList<int>();

            for (int i = 0; i < count; i++)
            {
                list.Add(i);
            }


            Assert.That(list.Contains(elementToSearch), Is.EqualTo(true));
        }

        [TestCase(1, 3)]
        [TestCase(2, 10)]
        [TestCase(8, 15)]
        public void ContainsShouldReturnfalseIfElementDoesNotExists(int count, int keyElement)
        {
            DynamicList<int> list = new DynamicList<int>();

            for (int i = 0; i < count; i++)
            {
                list.Add(i);
            }

            Assert.That(list.Contains(keyElement), Is.EqualTo(false));
        }
    }
}