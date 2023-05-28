
namespace GuardiansOfTheCode.Strategies
{
	/// <summary>
	/// Class for strategy pattern
	/// </summary>
	public class CriticalHealthIndicator : IDamageIndicator
	{
		public void NotifyAboutDamage(int health, int damage)
		{
			Console.ForegroundColor = ConsoleColor.Red;
			Console.WriteLine($"HEALTH CRITICAL! {damage} damage points taken, {health} HP remaining");
			Console.ForegroundColor = ConsoleColor.Green;
		}
	}
}
