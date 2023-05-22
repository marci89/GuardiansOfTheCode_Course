namespace GuardiansOfTheCode
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
		/// Enemy attack method
		/// </summary>
		/// <param name="player"></param>
		void Attack(PrimaryPlayer player);

		/// <summary>
		/// Enemy defend method
		/// </summary>
		/// <param name="player"></param>
		void Defend(PrimaryPlayer player);
	}
}