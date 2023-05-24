using System.Reflection.Emit;

namespace GuardiansOfTheCode.Enemy
{
	/// <summary>
	/// Factory pattern implementation
	/// </summary>
	public class EnemyFactory
	{
		private int _areaLevel;
		public int AreaLevel { get => _areaLevel; }

		/// <summary>
		/// Pools for object pool pattern
		/// </summary>
		private Stack<Zombie> _zombiesPool = new Stack<Zombie>();
		private Stack<Werewolf> _werewolvesPool = new Stack<Werewolf>();
		private Stack<Giant> _giantsPool = new Stack<Giant>();

		/// <summary>
		/// Constructor
		/// </summary>
		public EnemyFactory(int areaLevel)
		{
			_areaLevel = areaLevel;
			PreLoadZombies();
			PreLoadWerewolves();
			PreLoadGiants();
		}

		#region PreLoads

		/// <summary>
		/// Add data to the Werewolves pool
		/// </summary>
		private void PreLoadWerewolves()
		{
			int count, health, level;

			if (_areaLevel < 5)
			{
				count = 10;
			}
			else
			{
				count = 50;
			}

			(health, level) = GetWerewolfStatus(_areaLevel);
			for (int i = 0; i < count; i++)
			{
				_werewolvesPool.Push(new Werewolf(health, level));
			}

		}

		/// <summary>
		/// Add data to the Giant's pool
		/// </summary>
		private void PreLoadGiants()
		{
			int count, health, level;

			if (_areaLevel < 8)
			{
				count = 5;
			}
			else
			{
				count = 15;
			}

			(health, level) = GetGiantStatus(_areaLevel);
			for (int i = 0; i < count; i++)
			{
				_giantsPool.Push(new Giant(health, level));
			}

		}

		/// <summary>
		/// Add data to the Zombie's pool
		/// </summary>
		private void PreLoadZombies()
		{
			int count;
			int health;
			int armor;
			int level;

			if (_areaLevel < 3)
			{
				count = 15;

			}
			else if (_areaLevel >= 3 && _areaLevel < 10)
			{
				count = 50;
			}
			else
			{
				count = 200;
			}

			(health, level, armor) = GetZombieStatus(_areaLevel);

			for(int i=0; i<count; i++)
			{
				_zombiesPool.Push(new Zombie(health, level, armor));
			}
		}

		#endregion

		#region Get statuses

		/// <summary>
		/// Get werewolf status
		/// </summary>
		private (int health, int level) GetWerewolfStatus(int areaLvl)
		{
			int health, level;

			if (areaLvl < 5)
			{
				health = 100;
				level = 12;
			}
			else
			{
				health = 100;
				level = 20;
			}

			return (health, level);
		}

		/// <summary>
		/// Get giant status
		/// </summary>
		private (int health, int level) GetGiantStatus(int areaLvl)
		{
			int health, level;

			if (areaLvl < 8)
			{
				health = 100;
				level = 14;
			}
			else
			{
				health = 100;
				level = 32;
			}

			return (health, level);
		}

		/// <summary>
		/// Get zombie status
		/// </summary>
		private (int health, int level, int armor) GetZombieStatus(int areaLvl)
		{
			int health, armor, level;

			if (areaLvl < 3)
			{
				health = 66;
				level = 2;
				armor = 15;

			}
			else if (areaLvl >= 3 && areaLvl < 10)
			{
				health = 66;
				level = 5;
				armor = 15;
			}
			else
			{
				health = 100;
				level = 8;
				armor = 15;
			}

			return (health, level, armor);

		}

		#endregion

		#region Reclaiming enemies

		/// <summary>
		/// Reclaim Zombie
		/// </summary>
		public void ReclaimZombie(Zombie zombie)
		{
			(int health, int level, int armor) = GetZombieStatus(_areaLevel);
			zombie.Health = health;
			zombie.Armor = armor;

			_zombiesPool.Push(zombie);
		}

		/// <summary>
		/// Reclaim Werewolf
		/// </summary>
		public void ReclaimWerewolf(Werewolf werewolf)
		{
			(int health, int level) = GetWerewolfStatus(_areaLevel);
			werewolf.Health = health;

			_werewolvesPool.Push(werewolf);
		}

		/// <summary>
		/// Reclaim Giant
		/// </summary>
		public void ReclaimGiant(Giant giant)
		{
			(int health, int level) = GetGiantStatus(_areaLevel);
			giant.Health = health;

			_giantsPool.Push(giant);
		}

		#endregion

		#region Spaw enemies

		/// <summary>
		/// Create a Werewolf object
		/// </summary>
		public Werewolf SpawnWerewolf(int areaLevel)
		{
			if (_werewolvesPool.Count > 0)
			{
				return _werewolvesPool.Pop();
			}
			else
			{
				throw new Exception("Werewolves pool depleted");
			}
		}

		/// <summary>
		/// Create a Giant object
		/// </summary>
		public Giant SpawnGiant(int areaLevel)
		{
			if (_giantsPool.Count > 0)
			{
				return _giantsPool.Pop();
			}
			else
			{
				throw new Exception("Giants pool depleted");
			}
		}

		/// <summary>
		/// Create a Zombie object
		/// </summary>
		public Zombie SpawnZombie(int areaLevel)
		{
			if (_zombiesPool.Count  > 0)
			{
				return _zombiesPool.Pop();
			} else
			{
				throw new Exception("Zombies pool depleted");
			}	
		}

		#endregion
	}
}