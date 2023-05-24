using Common;

namespace API.Services
{
	public interface ICardService
	{
		IEnumerable<Card> FetchCards();
	}
}
