namespace GuardiansOfTheCode.Battlefields
{
	/// <summary>
	/// Template method pattern
	/// </summary>
	public class SnowyBattlefield : BattlefieldTemplate
	{
		public override string DescripbeClimate()
		{
			return "It is cold!";
		}

		public override string DescripbeEffects()
		{
			return "The snow makes it hard to see far away.";
		}

		public override string DescripbeGround()
		{
			return "The ground is covered in snow";
		}
	}
}
