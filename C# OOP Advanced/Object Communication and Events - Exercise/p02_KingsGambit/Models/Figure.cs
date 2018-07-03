namespace p02_KingsGambit
{
    public abstract class Figure
    {
        protected Figure(string name)
        {
            this.Name = name;
        }

        public string Name { get;  }

        public abstract void KingUnderAttack();
    }
}