namespace p01_Database
{
    using System;

    public class Database
    {
        private readonly int[] numbers;
            
        private const int MaxArrayCapacity = 16;
        private int currentIndex;

        public Database()
        {
            this.numbers = new int[MaxArrayCapacity];
            this.currentIndex = 0;
        }


        public Database(params int[] elements)
            : this()
        {
            InitializeComponents(elements);
        }

        private void InitializeComponents(int[] elements)
        {
            try
            {
                if (elements.Length > MaxArrayCapacity)
                {
                    throw new InvalidOperationException("Elements should be below or equal to 16!");
                }

                this.currentIndex = elements.Length;

                elements.CopyTo(numbers, 0);
            }
            catch (Exception e)
            {
                throw new InvalidOperationException("Elements should be below or equal to 16!", e);
            }
        }

        public void Add(int element)
        {
            if (currentIndex == MaxArrayCapacity)
            {
                throw new InvalidOperationException("Cannot add more elements to the Database");
            }

            numbers[currentIndex] = element;
            currentIndex++;
        }

        public void Remove()
        {
            currentIndex--;

            if (currentIndex < 0)
            {
                throw new InvalidOperationException("Database is empty and cannot remove anymore elements from it !");
            }

            numbers[currentIndex] = 0;
        }


        public int[] Fetch()
        {
            int[] finalArray = new int[currentIndex];

            for (int i = 0; i < currentIndex; i++)
            {
                finalArray[i] = numbers[i];
            }

            return finalArray;
        }
    }
}