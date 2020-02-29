using Microsoft.Xna.Framework;
using System.ComponentModel;
using Terraria.ModLoader.Config;

namespace FlightTimer
{
	public class Config : ModConfig
	{
		[Header("Flight")]
		[Label("Flight Timer")]
		[Tooltip("Adds a timer next to the player to show how much wing time is left. False for no timer, true for timer. True by default")]
		[DefaultValue(true)]
		public bool FlightTimer;

		[Label("Flight Time Timer Decimal")]
		[Tooltip("The amount of decimals to show on the flight time timer. Default 1")]
		[DrawTicks]
		[Range(0, 2)]
		[Increment(1)]
		[DefaultValue(1)]
		public int Decimal;

		[Label("Flight Time Timer Position")]
		[Tooltip("The position of the flight time timer. Default center of screen.")]
		[DefaultValue(typeof(Vector2), "0.5, 0.5")]
		public Vector2 Position;

		public override ConfigScope Mode => ConfigScope.ClientSide;
	}
}