using API.Services;
using Common;
using Microsoft.AspNetCore.Mvc;

namespace API.Controllers
{
	/// <summary>
	/// Card controller
	/// </summary>
	[Route("/Card")]
	public class CardController : Controller
	{
		#region DI

		private readonly ICardService _cardService;

		public CardController(ICardService cardService)
		{
			_cardService = cardService;
		}

		#endregion

		/// <summary>
		/// Get cards
		/// </summary>
		[HttpGet("")]
		public IEnumerable<Card> GetAll()
		{
			return _cardService.FetchCards();
		}
	}
}
