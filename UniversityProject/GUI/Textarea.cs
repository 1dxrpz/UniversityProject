using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;
using Microsoft.Xna.Framework.Input;
using System;
using System.Collections.Generic;
using System.Text;
using UniversityProject.Interfaces;

namespace UniversityProject.GUI
{
	public class Textarea : GuiItem
	{
		public Textarea(Scene scene, string text = "") : base(scene)
		{
			Texture = Utilits.GetTexture(Color.AliceBlue);
			Text = text;
			Bounds = new Rectangle(0, 0, 10, 10);
		}
		public Textarea(Scene scene, Rectangle bounds, string text = "") : base(scene, bounds, text)
		{
			Texture = Utilits.GetTexture(Color.AliceBlue);
		}
		public Textarea(Scene scene, Texture2D texture, string text = "") : base(scene, texture, text)
		{
			Bounds = new Rectangle(0, 0, 10, 10);
		}
		public Textarea(Scene scene, Texture2D texture, Rectangle bounds, string text = "") : base(scene, texture, bounds, text)
		{

		}

		private bool input = false;
		private bool focused = false;
		private string GetInput(Keys[] t)
		{
			if (t.Length == 0)
			{
				input = false;
				return "";
			}
			if (!input && t.Length > 0)
			{
				input = true;
				string temp = t[0].ToString();
				return temp switch
				{
					"D1" => "1",
					"D2" => "2",
					"D3" => "3",
					"D4" => "4",
					"D5" => "5",
					"D6" => "6",
					"D7" => "7",
					"D8" => "8",
					"D9" => "9",
					"D0" => "0",
					"Space" => " ",
					"LeftControl" => "",
					"RightControl" => "",
					"LeftAlt" => "",
					"RightAlt" => "",
					"LeftShift" => "",
					"RightShift" => "",
					"Enter" => "",
					"OemSemicolon" => ":",
					"OemPeriod" => ".",
					"OemPipe" => "",
					"OemQuestion" => "",
					"OemComma" => "",
					"Delete" => "",
					"CapsLock" => "",
					_ => temp
				};
			}
			return "";
		}
		public bool IsFocused
		{
			get
			{
				if (focused)
				{
					var temp = Keyboard.GetState().GetPressedKeys();
					var t = GetInput(temp);
					if (t == "Back")
					{
						if (Text.Length != 0)
							Text = Text.Remove(Text.Length - 1);
					}
					else
						if (Text.Length < 21)
						Text += t;
				}
				return focused;
			}
			set
			{
				focused = value;
			}
		}
	}
}
