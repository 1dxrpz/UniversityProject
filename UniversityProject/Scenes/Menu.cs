using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;
using Microsoft.Xna.Framework.Input;
using System;
using System.Collections.Generic;
using System.Text;
using UniversityProject.GUI;
using UniversityProject.Interfaces;

namespace UniversityProject
{
	class Menu : IGameObjects
	{
		Button connect_button;
		Button exit_button;
		int swidth;
		int sheight;
		SpriteFont font;
		public void Initialize()
		{
			font = Utilits.Content.Load<SpriteFont>("DefaultFont");
			swidth = Utilits.ScreenSize.X;
			sheight = Utilits.ScreenSize.Y;
			connect_button = new Button(Utilits.Content.Load<Texture2D>("button"), new Rectangle((swidth - 256) / 2, (sheight - 48) / 2 - 30, 256, 48), "Connect to server");
			exit_button = new Button(Utilits.Content.Load<Texture2D>("button"), new Rectangle((swidth - 256) / 2, (sheight - 48) / 2 + 30, 256, 48), "Exit");
		}
		public void Update()
		{
			//Utilits.SetSetting("test", "42");
			//Utilits.ApplySettings();
			if (connect_button.OnClick)
				Console.WriteLine(Utilits.GetSetting("defaultIp"));
			if (exit_button.OnClick)
				Environment.Exit(0);

		}
		StringBuilder builder = new StringBuilder();
		public void Draw()
		{
			var t = Keyboard.GetState().GetPressedKeys();
			if (t.Length > 0)
			{
				//Utilits.SpriteBatch.DrawString(font, t[0].ToString(), new Vector2(10, 10), Color.White);
			}
		}
	}
}
