using Common;
using GuardiansOfTheCode.Gameboard;
using System.Runtime.CompilerServices;

public class Program
{
	public static void Main()
	{
		try {
			testApiConncetion().Wait();
			TestDecorators();

			Gameboard board = new Gameboard();
			board.PlayArea(1).Wait();
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

	private static void TestDecorators()
	{
		Card soldier = new Card("Soldier", 25, 20);
		soldier = new AttackDecorator(soldier, "Sword", 15);
		soldier = new AttackDecorator(soldier, "Amulet", 5);
		soldier = new DefenseDecorator(soldier, "Helmet", 10);
		soldier = new DefenseDecorator(soldier, "Heavy Armor", 45);

		Console.WriteLine($"Final stats: {soldier.Attack} / {soldier.Defense}");
	}
}
