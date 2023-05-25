namespace Common
{
	/// <summary>
	/// Decorator pattern
	/// </summary>
	public class DefenseDecorator : CardDecorator
	{
		public DefenseDecorator(Card card, string name, int defense) : base(card, name, 0, defense)
		{
		}
	}
}