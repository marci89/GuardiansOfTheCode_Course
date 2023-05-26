namespace Common
{
	/// <summary>
	/// ICardComponent interface
	/// </summary>
	public interface ICardComponent
	{
		void Add(ICardComponent component);

		ICardComponent Get(int index);

		bool Remove(ICardComponent component);

		string Display();
	}
}