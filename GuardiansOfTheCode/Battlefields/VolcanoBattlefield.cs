namespace GuardiansOfTheCode.Battlefields
{
	/// <summary>
	/// Template method pattern
	/// </summary>
	public class VolcanoBattlefield : BattlefieldTemplate
	{
		public override string DescripbeClimate()
		{
			return "It is hot!";
		}

		public override string DescripbeEffects()
		{
			return "There are flames jumping from underneath";
		}

		public override string DescripbeGround()
		{
			return "The ground is rocky and unstable";
		}
	}
}
