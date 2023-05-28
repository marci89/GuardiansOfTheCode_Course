namespace GuardiansOfTheCode.Strategies
{
	/// <summary>
	/// Interface for strategy pattern
	/// </summary>
	public interface IDamageIndicator
	{
		void NotifyAboutDamage(int health, int damage);
	}
}
