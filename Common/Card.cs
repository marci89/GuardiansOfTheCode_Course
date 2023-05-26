namespace Common
{
	/// <summary>
	/// Card class
	/// </summary>
	public class Card : ICardComponent
	{
		protected string _name;
		protected int _attack;
		protected int _defense;


		public Card(string name, int attack, int defense)
		{
			_name = name;
			_attack = attack;
			_defense = defense;
		}

		public virtual string Name { get { return _name; }  set { _name = value; } }
		public virtual int Attack { get { return _attack; }  set { _attack = value; } }
		public virtual int Defense { get { return _defense; } set { _defense = value; } }

		public void Add(ICardComponent component)
		{
			throw new InvalidOperationException("Can't call this method on a card");
		}

		public string Display()
		{
			return $"{_name}: {_attack} / {_defense}";
		
		}

		public ICardComponent Get(int index)
		{
			throw new InvalidOperationException("Can't call this method on a card");
		}

		public bool Remove(ICardComponent component)
		{
			throw new InvalidOperationException("Can't call this method on a card");
		}
	}
}