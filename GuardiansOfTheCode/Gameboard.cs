﻿namespace GuardiansOfTheCode
{
	/// <summary>
	/// Gameboard class
	/// </summary>
	public class Gameboard
	{
		/// <summary>
		/// Private player
		/// </summary>
		private PrimaryPlayer _player;

		public Gameboard()
		{
			// Inicializing the player
			_player = PrimaryPlayer.Instance;
		}

		public void PlayArea(int lvl)
		{
			if (lvl == 1)
			{
				PlayFirstLevel();
			}
		}

		public void PlayFirstLevel()
		{
			const int currentLvl = 1;
			List<IEnemy> enemies = new List<IEnemy>();

			for (int i = 0; i < 10; i++)
			{
				enemies.Add(EnemyFactory.SpawnZombie(currentLvl));
			}

			for (int i = 0; i < 3; i++)
			{
				enemies.Add(EnemyFactory.SpawnWerewolf(currentLvl));
			}

			foreach (var enemy in enemies)
			{
				Console.WriteLine(enemy.GetType());
			}
		}
	}
}