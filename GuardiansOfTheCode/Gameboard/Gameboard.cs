using Common;
using GuardiansOfTheCode.Enemy;
using GuardiansOfTheCode.Weapon;
using Newtonsoft.Json;

namespace GuardiansOfTheCode.Gameboard
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
			_player.Weapon = new Sword(12, 8);
		}

		/// <summary>
		/// The play area
		/// </summary>
		/// <param name="lvl"></param>
		public async Task PlayArea(int lvl)
		{
			if (lvl == 1)
			{
				_player.Cards = (await FetchCards()).ToArray();
				Console.WriteLine("Ready to play level 1?");
				Console.ReadKey();
				PlayFirstLevel();

			}
		}

		/// <summary>
		/// First level implementation
		/// </summary>
		public void PlayFirstLevel()
		{
			const int currentLvl = 1;
			EnemyFactory factory = new EnemyFactory(currentLvl);
			List<IEnemy> enemies = new List<IEnemy>();

			for (int i = 0; i < 10; i++)
			{
				enemies.Add(factory.SpawnZombie(currentLvl));
			}

			for (int i = 0; i < 3; i++)
			{
				enemies.Add(factory.SpawnWerewolf(currentLvl));
			}

			foreach (var enemy in enemies)
			{
				while (enemy.Health > 0 || _player.Health > 0)
				{
					_player.Weapon.Use(enemy);
					enemy.Attack(_player);
				}
			}
		}

		/// <summary>
		/// Get cards from API
		/// </summary>
		private async Task<IEnumerable<Card>> FetchCards()
		{
			using (var http = new HttpClient())
			{
				var cardsJson = await http.GetStringAsync("https://localhost:7164/Card");
				return JsonConvert.DeserializeObject<IEnumerable<Card>>(cardsJson);
			}
		}
	}
}