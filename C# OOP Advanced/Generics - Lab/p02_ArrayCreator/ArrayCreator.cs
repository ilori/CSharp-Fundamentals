public static class ArrayCreator
{
    public static T[] Create<T>(int length, T item)
    {
        T[] array = new T[length];
        array[0] = item;

        return array;
    }
}