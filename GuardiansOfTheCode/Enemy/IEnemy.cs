using GuardiansOfTheCode.Gameboard;

namespace GuardiansOfTheCode.Enemy
{
    public interface IEnemy
    {
        /// <summary>
        /// Enemy's health
        /// </summary>
        public int Health { get; set; }

        /// <summary>
        /// Enemy's level
        /// </summary>
        public int Level { get; }

        /// <summary>
        /// Enemy's over time damage
        /// </summary>
        public int OverTimeDamage { get; set; }

		/// <summary>
		/// Enemy's damage
		/// </summary>
		public int Damage { get; }

		/// <summary>
		/// Enemy's armor
		/// </summary>
		public int Armor { get; set; }

        /// <summary>
        /// Enemy paralyzed
        /// </summary>
        public bool Paralyzed { get; set; }

        /// <summary>
        /// Enemy paralyzedFor
        /// </summary>
        public int ParalyzedFor { get; set; }

        /// <summary>
        /// Enemy attack method
        /// </summary>
        /// <param name="player"></param>
        int Attack(PrimaryPlayer player);

        /// <summary>
        /// Enemy defend method
        /// </summary>
        /// <param name="player"></param>
        void Defend(PrimaryPlayer player);
    }
}