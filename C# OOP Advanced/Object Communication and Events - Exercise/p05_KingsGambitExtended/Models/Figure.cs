namespace p05_KingsGambitExtended.Models
{
    public delegate void DeadFigureEventHendler(Figure figure);

    public abstract class Figure
    {
        protected Figure(string name, int health)
        {
            this.Name = name;
            this.Health = health;
        }

        public event DeadFigureEventHendler DeadFigure;

        public string Name { get; }

        public int Health { get; set; }

        public abstract void KingUnderAttack();

        public void TakeAttack()
        {
            this.Health -= 1;

            if (this.Health == 0)
            {
                OnDeadFigure(this);
            }
        }

        protected virtual void OnDeadFigure(Figure figure)
        {
            DeadFigure?.Invoke(figure);
        }
    }
}