﻿
namespace GuardiansOfTheCode
{
	/// <summary>
	/// Singleton pattern implementation
	/// </summary>
	public sealed class PrimaryPlayer
	{

		private static readonly PrimaryPlayer _instance;

		 // Private constructor to prevent direct instantiation
		private PrimaryPlayer() { }

		// Lazy initialization: create instance only when accessed for the first time in a static constructor
		static PrimaryPlayer()
		{
			_instance = new PrimaryPlayer()
			{
				Name = "Raptor",
				Level = 1,
			};
		}

		// Public property
		public static PrimaryPlayer Instance
		{
			get
			{
				return _instance;
			}
		}

		/// <summary>
		/// Player's name
		/// </summary>
		public string Name { get; set; }

		/// <summary>
		/// Player's level
		/// </summary>
		public int Level { get; set; }
	}
}