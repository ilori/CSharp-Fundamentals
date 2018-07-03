using System.Linq;

public class AddRemoveCollection<T> : AddCollection<T>, IAddRemoveCollection<T>
{
    private const int Index = 0;

    public virtual T Remove()
    {
        var lastElement = Data.Last();
        Data.RemoveAt(Data.Count - 1);
        return lastElement;
    }

    public override int Add(T element)
    {
        Data.Insert(Index, element);
        return Index;
    }
}