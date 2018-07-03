using System.Collections.Generic;
using System.Linq;

public class Family
{
    private List<Person> members = new List<Person>();

    public List<Person> Members
    {
        get => members;
        set => members = value;
    }


    public void AddMember(Person member)
    {
        members.Add(member);
    }

    public Person GetOldestMember()
    {
        return members.Aggregate((x, y) => x.Age >= y.Age ? x : y);
    }
}