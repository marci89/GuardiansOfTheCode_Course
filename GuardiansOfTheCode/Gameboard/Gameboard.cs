using GuardiansOfTheCode.Enemy;
using GuardiansOfTheCode.Weapon;

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
    }
}