using System;
using System.Collections.Generic;

public class RandomList : List<string>
{
    private Random random;

    public string RandomString()
    {
        var index = random.Next(0, this.Count);
        RemoveAt(index);
        return this[index];
    }
}