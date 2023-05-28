using Common;
using Newtonsoft.Json;

namespace GuardiansOfTheCode.Proxies
{
	/// <summary>
	/// Proxy pattern
	/// </summary>
	public class CardsProxy
	{
		private HttpClient _http;
		private IEnumerable<Card> _cards;

		public CardsProxy()
		{
			_http = new HttpClient();
		}

		/// <summary>
		/// Get cards
		/// </summary>
		public async Task<IEnumerable<Card>> GetCards()
		{
			if (_cards != null)
			{
				return _cards;
			}
			else
			{
				await FetchCards();
				return _cards;
			}
		}

		/// <summary>
		/// Get cards from API
		/// </summary>
		private async Task FetchCards()
		{
			var cardsJson = await _http.GetStringAsync("https://localhost:7164/Card");
			_cards = JsonConvert.DeserializeObject<IEnumerable<Card>>(cardsJson);
		}
	}
}