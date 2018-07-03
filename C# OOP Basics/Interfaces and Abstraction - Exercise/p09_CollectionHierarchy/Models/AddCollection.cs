using System.Collections.Generic;

public class AddCollection<T> : IAddCollection<T>
{
    protected List<T> Data { get; set; } = new List<T>();

    public virtual int Add(T item)
    {
        Data.Add(item);

        return Data.Count - 1;
    }
}