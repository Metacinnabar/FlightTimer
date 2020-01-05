using System.Collections.Generic;
using Terraria.ModLoader;
using Terraria.UI;
using Terraria;
using Microsoft.Xna.Framework;
using Terraria.ModLoader.Config;
using System.ComponentModel;

namespace FlightTimer
{
	public class FlightTimer : Mod
	{
		//Make forum

		public override void ModifyInterfaceLayers(List<GameInterfaceLayer> layers)
		{
			int mouseText = layers.FindIndex(layer => layer.Name.Equals("Vanilla: Mouse Text"));
			if (mouseText != -1)
			{
				layers.Insert(mouseText, new LegacyGameInterfaceLayer("FlightTimer: Player Name", delegate
				{
					if (!Main.gameMenu && Main.LocalPlayer.wingTimeMax != Main.LocalPlayer.wingTime && ModContent.GetInstance<Config>().FlightTimer && !Main.LocalPlayer.dead)
					{
						string text = string.Format("{0:f" + ModContent.GetInstance<Config>().Decimal + "}", Main.LocalPlayer.wingTime / 60f);

						Vector2 position = ModContent.GetInstance<Config>().Position * new Vector2(Main.screenWidth, Main.screenHeight);

						Utils.DrawBorderString(Main.spriteBatch, text, position, Color.WhiteSmoke);
					}
					return true;
				}, InterfaceScaleType.UI));
			}
		}
	}
	 
	public class Config : ModConfig
	{
		public override ConfigScope Mode => ConfigScope.ClientSide;

		[Header("Flight")]

		[Label("Flight Timer")]
		[Tooltip("Adds a timer nexxt to the player to show how much wing time is left. False for no timer, true to for timer. True by default")]
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
		[Tooltip("Adds a timer nexxt to the player to show how much wing time is left. False for no timer, true to for timer. True by default")]
		[DefaultValue(typeof(Vector2), "0.5, 0.5")]
		public Vector2 Position;
	}
}