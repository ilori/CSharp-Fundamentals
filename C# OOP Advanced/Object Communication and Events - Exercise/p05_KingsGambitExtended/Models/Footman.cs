namespace p05_KingsGambitExtended.Models
{
    using System;

    public class Footman : Figure
    {
        public Footman(string name) : base(name, 2)
        {
        }

        public override void KingUnderAttack()
        {
            Console.WriteLine($"{this.GetType().Name} {this.Name} is panicking!");
        }
    }
}