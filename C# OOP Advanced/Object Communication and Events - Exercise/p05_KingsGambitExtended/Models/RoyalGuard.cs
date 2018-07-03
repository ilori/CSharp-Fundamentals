namespace p05_KingsGambitExtended.Models
{
    using System;

    public class RoyalGuard : Figure
    {
        public RoyalGuard(string name) : base(name, 3)
        {
        }

        public override void KingUnderAttack()
        {
            Console.WriteLine($"Royal Guard {this.Name} is defending!");
        }
    }
}