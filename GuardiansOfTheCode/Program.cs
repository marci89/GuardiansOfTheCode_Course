
using Common;
using GuardiansOfTheCode.Facades;
using GuardiansOfTheCode.Gameboard;

public class Program
{
	public static void Main()
	{
		PrimaryPlayer player = PrimaryPlayer.Instance;
		Console.WriteLine($"{player.Name} - lvl {player.Level}");

		try {
			testApiConncetion().Wait();
			//TestDecorators();

			//Gameboard board = new Gameboard();
			//board.PlayArea(1).Wait();

			GameboardFacade gameboard = new GameboardFacade();
			gameboard.Play(player, 1).Wait();

			//TestComposite();

			Console.ReadKey();
		}
		catch(Exception ex)
		{
			Console.WriteLine("Failed to initialize game.");
			Console.WriteLine(ex.Message);
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

	/// <summary>
	/// Testing Decorator
	/// </summary>
	private static void TestDecorators()
	{
		Card soldier = new Card("Soldier", 25, 20);
		soldier = new AttackDecorator(soldier, "Sword", 15);
		soldier = new AttackDecorator(soldier, "Amulet", 5);
		soldier = new DefenseDecorator(soldier, "Helmet", 10);
		soldier = new DefenseDecorator(soldier, "Heavy Armor", 45);

		Console.WriteLine($"Final stats: {soldier.Attack} / {soldier.Defense}");
	}

	/// <summary>
	/// Testing composite
	/// </summary>
	private static void TestComposite()
	{
		CardDeck deck = new CardDeck();
		CardDeck attackDeck = new CardDeck();
		CardDeck defensekDeck = new CardDeck();

		attackDeck.Add(new Card("Basic Infantry Unit", 12, 15));
		attackDeck.Add(new Card("Advanced Infantry Unit", 25, 18));
		attackDeck.Add(new Card("Cavarly Unit", 32, 24));

		defensekDeck.Add(new Card("Wooden Shield", 0, 6));
		defensekDeck.Add(new Card("Iron Shield", 0, 9));
		defensekDeck.Add(new Card("Shining Royal Armor", 0, 40));

		deck.Add(attackDeck);
		deck.Add(new Card("Small Beast", 16, 3));
		deck.Add(new Card("High Elf Rogue", 22, 7));
		deck.Add(defensekDeck);

		Console.WriteLine(deck.Display());

	}
}
