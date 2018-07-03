namespace p05_KingsGambitExtended.Models
{
    using System;
    using System.Collections.Generic;

    public delegate void KingUnderAttackEventHalnder();

    public class King
    {
        public event KingUnderAttackEventHalnder KingUnderAttack;

        private readonly List<Figure> figures;

        public King(string name)
        {
            this.Name = name;
            this.figures = new List<Figure>();
        }

        public string Name { get; }

        public void AddSoldier(Figure figure)
        {
            this.figures.Add(figure);
            this.KingUnderAttack += figure.KingUnderAttack;
            figure.DeadFigure += this.OnSoldierDead;
        }

        public IReadOnlyCollection<Figure> Figures => this.figures;

        public void OnKingAttack()
        {
            Console.WriteLine($"King {this.Name} is under attack!");
            KingUnderAttack?.Invoke();
        }

        public void OnSoldierDead(Figure figure)
        {
            this.KingUnderAttack -= figure.KingUnderAttack;
            this.figures.Remove(figure);
        }
    }
}