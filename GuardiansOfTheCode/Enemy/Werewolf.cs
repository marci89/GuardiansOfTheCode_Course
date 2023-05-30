using GuardiansOfTheCode.Gameboard;

namespace GuardiansOfTheCode.Enemy
{
    /// <summary>
    /// Werewolf enemy
    /// </summary>
    public class Werewolf : IEnemy
    {
        private int _health;
        private readonly int _level;

        public int Health { get => _health; set => _health = value; }

        public int Level => _level;

        public int OverTimeDamage { get; set; }

		public int Damage { get; set; } = 20;
		public int Armor { get; set; }
        public bool Paralyzed { get; set; }
        public int ParalyzedFor { get; set; }

		public Werewolf(int health, int level)
        {
            _health = health;
            _level = level;
        }

        public int Attack(PrimaryPlayer player)
        {
            Console.WriteLine("Werewolf attacking " + player.Name);
            return Damage;
        }

        public void Defend(PrimaryPlayer player)
        {
            Console.WriteLine("Werewolf defending " + player.Name);
        }
    }
}