using GuardiansOfTheCode.Enemy;

namespace GuardiansOfTheCode.Weapon
{
    /// <summary>
    /// Sword weapon
    /// </summary>
    public class Sword : IWeapon
	{
		private int _damage;
		private int _armorDamage;

		public int Damage { get => _damage; }
		public int ArmorDamage { get => _armorDamage; }

		public Sword(int damage, int armorDamage)
		{
			_damage = damage;
			_armorDamage = armorDamage;
		}

		public void Use(IEnemy enemy)
		{
			enemy.Health -= Damage;
			enemy.Armor -= ArmorDamage;
		}
	}
}