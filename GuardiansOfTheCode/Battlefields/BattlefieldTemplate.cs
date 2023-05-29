using System.Text;

namespace GuardiansOfTheCode.Battlefields
{
	/// <summary>
	/// Template method pattern
	/// </summary>
	public abstract class BattlefieldTemplate
	{
		public string DescripbeSky()
		{
			return "The battlefield sky is blue";
		}

		public abstract string DescripbeGround();

		public abstract string DescripbeClimate();

		public abstract string DescripbeEffects();

		public string Descripbe()
		{
			StringBuilder builder = new StringBuilder();
			builder.Append(DescripbeSky());
			builder.Append("\r\n");
			builder.Append(DescripbeGround());
			builder.Append("\r\n");
			builder.Append(DescripbeClimate());
			builder.Append("\r\n");
			builder.Append(DescripbeEffects());
			builder.Append("\r\n");
			return builder.ToString();
		}

	}
}
