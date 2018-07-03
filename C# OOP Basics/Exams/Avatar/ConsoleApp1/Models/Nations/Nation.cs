using System.Collections.Generic;

public abstract class Nation
{
    protected Nation(string name)
    {
        this.Name = name;
    }

    public string Name { get; set; }

    public virtual double TotalPower { get; protected set; }

    public abstract double NationTotalPower();

    public virtual void AssignBenders(Bender benders)
    {
    }

    public virtual void AssignMonuments(Monument monuments)
    {
    }

    public virtual void RemoveBinders()
    {
    }

    public virtual void RemoveMonuments()
    {
    }
}