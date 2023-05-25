using Common;

namespace API.Services
{
	/// <summary>
	/// Card service
	/// </summary>
	public class CardService : ICardService
	{
		/// <summary>
		/// Get cards
		/// </summary>
		public IEnumerable<Card> FetchCards()
		{
			return new List<Card>()
			{
				new Card ("Ultimate Shadow Wraith", 90, 80),
				new Card ("Puppet of Doom", 64, 91),
				new Card ("Lost Soul", 77, 61),
				new Card ("Plague Druid", 55, 57),
				new Card ("Rage Dragon", 90, 95)
			};
		}
	}
}