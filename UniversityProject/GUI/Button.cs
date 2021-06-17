using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;
using Microsoft.Xna.Framework.Input;
using System;
using System.Collections.Generic;
using System.Text;
using UniversityProject.Interfaces;

namespace UniversityProject.GUI
{
	class Button : GuiItem
	{
		public Button(Scene scene, string text = "") : base(scene)
		{
			Texture = Utilits.GetTexture(Color.AliceBlue);
			Text = text;
			Bounds = new Rectangle(0, 0, 10, 10);
		}
		public Button(Scene scene, Rectangle bounds, string text = "") : base(scene, bounds, text)
		{
			Texture = Utilits.GetTexture(Color.AliceBlue);
		}
		public Button(Scene scene, Texture2D texture, string text = "") : base(scene, texture, text)
		{
			Bounds = new Rectangle(0, 0, 10, 10);
		}
		public Button(Scene scene, Texture2D texture, Rectangle bounds, string text = "") : base(scene, texture, bounds, text)
		{
		}
	}
}
