using Common;
using GuardiansOfTheCode.Enemy;
using GuardiansOfTheCode.Gameboard;
using GuardiansOfTheCode.Weapon;
using Newtonsoft.Json;

namespace GuardiansOfTheCode.Facades
{
	/// <summary>
	/// Facade pattern
	/// </summary>
	public class GameboardFacade
	{
		private PrimaryPlayer _player;
		private int _areaLevel;
		private HttpClient _http;
		private EnemyFactory _enemyFactory;
		private List<IEnemy> _enimies = new List<IEnemy>();

		/// <summary>
		///  Game start based on level
		/// </summary>
		public async Task Play(PrimaryPlayer palyer, int areaLevel)
		{
			_player = palyer;
			_areaLevel = areaLevel;
			ConfigurePlayerWeapon();
			await AddPlayerCards();
			InitializeEnemyFactory(areaLevel);
			LoadZombies(areaLevel);
			LoadWerewolves(areaLevel);
			LoadGiants(areaLevel);
		}

		/// <summary>
		/// Setting player's weapon
		/// </summary>
		private void ConfigurePlayerWeapon()
		{
			string input;
			int choice;

			while (true)
			{
				Console.WriteLine("Pick a weapon: ");
				Console.WriteLine("1. Sword");
				Console.WriteLine("2. Fire staff");
				Console.WriteLine("3. Ice staff");

				input = Console.ReadLine();

				if (Int32.TryParse(input, out choice))
				{
					if (choice == 1)
					{
						_player.Weapon = new Sword(15, 17);
						break;
					}
					else if (choice == 2)
					{
						_player.Weapon = new FireStaff(12, 14);
						break;
					}
					else if (choice == 2)
					{
						_player.Weapon = new IceStaff(5, 1);
						break;
					}
				}
				else
				{
					Console.WriteLine("Invalid input");
				}
			}
		}

		/// <summary>
		/// Add cards to player
		/// </summary>
		private async Task AddPlayerCards()
		{
			using (var _http = new HttpClient())
			{
				var cardsJson = await _http.GetStringAsync("https://localhost:7164/Card");
				_player.Cards = JsonConvert.DeserializeObject<IEnumerable<Card>>(cardsJson).ToArray();
			}
		}

		/// <summary>
		/// Create EnemyFactory
		/// </summary>
		/// <param name="areaLevel"></param>
		private void InitializeEnemyFactory(int areaLevel)
		{
			_enemyFactory = new EnemyFactory(areaLevel);
		}

		/// <summary>
		/// Load zombies
		/// </summary>
		private void LoadZombies(int areaLevel)
		{
			int count;

			if (_areaLevel < 3)
			{
				count = 10;
			}
			else if (_areaLevel >= 3 && _areaLevel < 10)
			{
				count = 20;
			}
			else
			{
				count = 30;
			}

			for (int i = 0; i < count; i++)
			{
				_enimies.Add(_enemyFactory.SpawnWerewolf(areaLevel));
			}
		}

		/// <summary>
		/// Load werewolves
		/// </summary>
		private void LoadWerewolves(int areaLevel)
		{
			int count;

			if (_areaLevel < 5)
			{
				count = 3;
			}
			else
			{
				count = 10;
			}

			for (int i = 0; i < count; i++)
			{
				_enimies.Add(_enemyFactory.SpawnWerewolf(areaLevel));
			}
		}

		/// <summary>
		/// Load giants
		/// </summary>
		private void LoadGiants(int areaLevel)
		{
			int count;

			if (_areaLevel < 8)
			{
				count = 1;
			}
			else
			{
				count = 3;
			}

			for (int i = 0; i < count; i++)
			{
				_enimies.Add(_enemyFactory.SpawnGiant(areaLevel));
			}
		}
	}
}