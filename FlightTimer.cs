using Microsoft.Xna.Framework;
using System.Collections.Generic;
using Terraria;
using Terraria.ModLoader;
using Terraria.UI;

namespace FlightTimer
{
	public class FlightTimer : Mod
	{
		// GoodProLib v1.0 - layers.NewInterfaceLayer
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
}