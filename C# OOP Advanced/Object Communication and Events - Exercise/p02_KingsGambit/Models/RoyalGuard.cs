namespace p02_KingsGambit
{
    using System;

    public class RoyalGuard : Figure
    {
        public RoyalGuard(string name) : base(name)
        {
        }

        public override void KingUnderAttack()
        {
            Console.WriteLine($"Royal Guard {this.Name} is defending!");
        }
    }
}