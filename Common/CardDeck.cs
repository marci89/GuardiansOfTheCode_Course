using System.Text;

namespace Common
{
	/// <summary>
	/// Composite pattern
	/// </summary>
	public class CardDeck :ICardComponent
	{
		private List<ICardComponent> _components = new List<ICardComponent>();

		/// <summary>
		/// Add a card to list
		/// </summary>
		public void Add(ICardComponent component)
		{
			_components.Add(component);
		}


		/// <summary>
		/// Delete a card from list
		/// </summary>
		public bool Remove(ICardComponent component)
		{
			return _components.Remove(component);
		}

		/// <summary>
		/// Get a card from list
		/// </summary>
		ICardComponent Get(int index)
		{
			return _components[index];
		}

		ICardComponent ICardComponent.Get(int index)
		{
			throw new NotImplementedException();
		}

		/// <summary>
		/// Display components
		/// </summary>
		public string Display()
		{
			StringBuilder builder = new StringBuilder();

			foreach (var component in _components)
			{ 
				builder.Append(component.Display() + "\r\n");
			}

			return builder.ToString();
		}
	}
}