namespace p02_KingsGambit
{
    using System;

    public class Footman : Figure
    {
        public Footman(string name) : base(name)
        {
        }

        public override void KingUnderAttack()
        {
            Console.WriteLine($"{this.GetType().Name} {this.Name} is panicking!");
        }
    }
}