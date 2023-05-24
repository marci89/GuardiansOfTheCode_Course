using GuardiansOfTheCode.Gameboard;
using System.Runtime.CompilerServices;

public class Program
{
	public static void Main()
	{
		try {
			testApiConncetion().Wait();

			Gameboard board = new Gameboard();
			board.PlayArea(1);

			Console.ReadKey();
		}
		catch
		{
			Console.WriteLine("Failed to initialize game.");
			Console.ReadKey();
		}

		

		
	}

	/// <summary>
	/// Testing Connection
	/// </summary>
	private async static Task testApiConncetion()
	{
		int maxAttempts = 20;

		//interval in milliseconds
		int attemptInterval = 2000;

		using(var http = new HttpClient())
		{
			for(int i = 0; i < maxAttempts; i++)
			{
				try
				{
					var response = await http.GetAsync("https://localhost:7164/Card");
					if (response.StatusCode == System.Net.HttpStatusCode.OK)
					{
						return;
					}
				}
				catch
				{

				}
				finally {
					Console.WriteLine("Lost connection to server. Attempting to re-connect");
					Thread.Sleep(attemptInterval);
						}
			}
			throw new Exception("Failed to connect to server.");
		}


	}
}
