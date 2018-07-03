namespace p02_KingsGambit
{
    using System;

    public delegate void KingUnderAttackEventHalnder();

    public class King
    {
        public event KingUnderAttackEventHalnder KingUnderAttack;

        public King(string name)
        {
            this.Name = name;
        }

        public string Name { get;  }

        public void OnKingAttack()
        {
            Console.WriteLine($"{this.GetType().Name} {this.Name} is under attack!");

            KingUnderAttack?.Invoke();
        }
    }
}