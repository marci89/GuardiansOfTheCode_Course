﻿using GuardiansOfTheCode.Gameboard;

namespace GuardiansOfTheCode.Enemy
{
    /// <summary>
    /// Zombie enemy
    /// </summary>
    public class Zombie : IEnemy
    {
        private int _health;
        private readonly int _level;

        public int Damage { get; set; } = 10;
        public int Health { get => _health; set => _health = value; }

        public int Level => _level;

        public int OverTimeDamage { get; set; }
        public int Armor { get; set; }
        public bool Paralyzed { get; set; }
        public int ParalyzedFor { get; set; }

        public Zombie(int health, int level, int armor)
        {
            _health = health;
            _level = level;
            Armor = armor;
        }

        public int Attack(PrimaryPlayer player)
        {
            Console.WriteLine("Zombie attacking " + player.Name);
			return Damage;
		}

        public void Defend(PrimaryPlayer player)
        {
            Console.WriteLine("Zombie defending " + player.Name);
        }
    }
}