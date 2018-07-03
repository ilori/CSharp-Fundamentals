using System;

public class Player
{
    private string name;
    private int endurance;
    private int sprint;
    private int dribble;
    private int passing;
    private int shooting;
    public double OverallPlayerStats => CalculatePlayerStats();

    private double CalculatePlayerStats()
    {
        return (this.Endurance + this.Sprint + this.Dribble + this.Passing + this.Shooting) / 5d;
    }


    public Player(string name, int endurance, int sprint, int dribble, int passing, int shooting)
    {
        this.Name = name;
        this.Endurance = endurance;
        this.Sprint = sprint;
        this.Dribble = dribble;
        this.Passing = passing;
        this.Shooting = shooting;
    }


    public int Shooting
    {
        get { return shooting; }
        private set
        {
            if (!Validator.IsStatsValid(value))
            {
                throw new ArgumentException(string.Format(Validator.InvalidStatsMessage, nameof(Shooting)));
            }

            shooting = value;
        }
    }


    public int Passing
    {
        get { return passing; }
        private set
        {
            if (!Validator.IsStatsValid(value))
            {
                throw new ArgumentException(string.Format(Validator.InvalidStatsMessage, nameof(Passing)));
            }


            passing = value;
        }
    }


    public int Dribble
    {
        get { return dribble; }
        private set
        {
            if (!Validator.IsStatsValid(value))
            {
                throw new ArgumentException(string.Format(Validator.InvalidStatsMessage, nameof(Dribble)));
            }

            dribble = value;
        }
    }


    public int Sprint
    {
        get { return sprint; }
        private set
        {
            if (!Validator.IsStatsValid(value))
            {
                throw new ArgumentException(string.Format(Validator.InvalidStatsMessage, nameof(Sprint)));
            }

            sprint = value;
        }
    }

    public int Endurance
    {
        get { return endurance; }
        private set
        {
            if (!Validator.IsStatsValid(value))
            {
                throw new ArgumentException(string.Format(Validator.InvalidStatsMessage, nameof(Endurance)));
            }

            endurance = value;
        }
    }

    public string Name
    {
        get { return name; }
        private set
        {
            if (!Validator.IsNameValid(value))
            {
                throw new ArgumentException(Validator.InvalidNameMessage);
            }

            name = value;
        }
    }
}