namespace GuardiansOfTheCode
{
	/// <summary>
	/// Factory pattern implementation
	/// </summary>
	public static class EnemyFactory
	{
		/// <summary>
		/// Create a Werewolf object
		/// </summary>
		public static Werewolf SpawnWerewolf(int areaLevel)
		{
			if (areaLevel < 5)
			{
				return new Werewolf(100, 12);
			}
			else
			{
				return new Werewolf(100, 20);
			}
		}

		/// <summary>
		/// Create a Giant object
		/// </summary>
		public static Giant SpawnGiant(int areaLevel)
		{
			if (areaLevel < 8)
			{
				return new Giant(100, 14);
			}
			else
			{
				return new Giant(100, 32);
			}
		}

		/// <summary>
		/// Create a Zombie object
		/// </summary>
		public static Zombie SpawnZombie(int areaLevel)
		{
			if (areaLevel < 3)
			{
				return new Zombie(66, 2, 15);
			}
			else if (areaLevel >= 3 && areaLevel < 10)
			{
				return new Zombie(66, 5, 15);
			}
			else
			{
				return new Zombie(100, 8, 15);
			}
		}
	}
}