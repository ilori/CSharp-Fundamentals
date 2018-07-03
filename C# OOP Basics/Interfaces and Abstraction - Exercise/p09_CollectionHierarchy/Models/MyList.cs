using System.Collections.Generic;
using System.Linq;

public class MyList<T> : AddRemoveCollection<T>, IMyList<T>
{
    private const int RemovalIndex = 0;

    public IReadOnlyCollection<T> Used => Data;

    public override T Remove()
    {
        var firstElemennt = Data.First();
        Data.RemoveAt(RemovalIndex);
        return firstElemennt;
    }
}