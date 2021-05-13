using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;
using Microsoft.Xna.Framework.Input;
using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Runtime.InteropServices;
using System.Text;
using UniversityProject.GUI;
using UniversityProject.Interfaces;

namespace UniversityProject
{
	class Menu : IGameObjects
	{
		Button connect_button;
		Button exit_button;
		Button enter_game_button;
		Button back_button;
		Button ip_textarea;
		Button github_li;
		Button github_lya;
		Button github_about;
		int swidth;
		int sheight;
		Texture2D button_hover;
		Texture2D button;
		List<Button> Buttons;
		Texture2D logo;
		Texture2D background;
		public void Initialize()
		{
			background = Utilits.Content.Load<Texture2D>(@"Menu\background");
			logo = Utilits.Content.Load<Texture2D>(@"Menu\game_logo");
			Buttons = new List<Button>();
			button = Utilits.Content.Load<Texture2D>(@"Menu\button");
			button_hover = Utilits.Content.Load<Texture2D>(@"Menu\button_hover");
			swidth = Utilits.ScreenSize.X;
			sheight = Utilits.ScreenSize.Y;
			connect_button = new Button(Utilits.Content.Load<Texture2D>(@"Menu\button"), new Rectangle(20, (sheight - 38) / 2 - 30, 256, 38), "Connect to server");
			enter_game_button = new Button(Utilits.Content.Load<Texture2D>(@"Menu\button"), new Rectangle( 20, (sheight - 38) / 2 + 30, 256, 38), "Connect");
			exit_button = new Button(Utilits.Content.Load<Texture2D>(@"Menu\button"), new Rectangle(20 , (sheight - 38) / 2 + 30, 256, 38), "Exit");
			back_button = new Button(Utilits.Content.Load<Texture2D>(@"Menu\button"), new Rectangle(20 , (sheight - 38) / 2 + 90, 256, 38), "Back");
			ip_textarea = new Button(Utilits.Content.Load<Texture2D>(@"Menu\textarea"), new Rectangle(20, (sheight - 38) / 2 - 30, 256, 38), "");

			github_li = new Button(new Rectangle(20, (sheight - 40), 60, 40), "dxrpz");
			github_lya = new Button(new Rectangle(90, (sheight - 40), 40, 40), "Mac");
			github_about = new Button(new Rectangle(140, (sheight - 40), 60, 40), "About");

			Buttons.Add(connect_button);
			Buttons.Add(exit_button);
			Buttons.Add(enter_game_button);
			Buttons.Add(back_button);

			enter_game_button.IsVisible = false;
			back_button.IsVisible = false;
			ip_textarea.IsVisible = false;
			ip_textarea.Anchor = Anchor.Left;
			ip_textarea.TextColor = Color.Black;

		}
		bool input = false;
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
					"RightShift" => "",
					"OemSemicolon" => ":",
					"OemPeriod" => ".",
					_ => temp
				};
			}
			return "";
		}
		string ip = "192.168.1.";
		private void OpenUrl(string url)
		{
			try
			{
				Process.Start(url);
			}
			catch
			{
				// hack because of this: https://github.com/dotnet/corefx/issues/10361
				if (RuntimeInformation.IsOSPlatform(OSPlatform.Windows))
				{
					url = url.Replace("&", "^&");
					Process.Start(new ProcessStartInfo("cmd", $"/c start {url}") { CreateNoWindow = true });
				}
				else if (RuntimeInformation.IsOSPlatform(OSPlatform.Linux))
				{
					Process.Start("xdg-open", url);
				}
				else if (RuntimeInformation.IsOSPlatform(OSPlatform.OSX))
				{
					Process.Start("open", url);
				}
				else
				{
					throw;
				}
			}
		}
		public void Update()
		{
			if (github_li.OnClick)
				OpenUrl("https://github.com/1dxrpz");
			if (github_lya.OnClick)
				OpenUrl("https://github.com/sssMac");
			if (github_about.OnClick)
				OpenUrl("https://github.com/1dxrpz/UniversityProject/blob/master/README.md");
			Buttons.ForEach((v) =>
			{
				if (v.IsHover)
					v.Texture = button_hover;
				else
					v.Texture = button;
			});

			if (connect_button.OnClick)
			{
				connect_button.IsVisible = false;
				exit_button.IsVisible = false;
				enter_game_button.IsVisible = true;
				back_button.IsVisible = true;
				ip_textarea.IsVisible = true;
			}
			if (back_button.OnClick)
			{
				connect_button.IsVisible = true;
				exit_button.IsVisible = true;
				enter_game_button.IsVisible = false;
				back_button.IsVisible = false;
				ip_textarea.IsVisible = false;
			}
			if (enter_game_button.OnClick)
			{
				// connect player
			}
			if (exit_button.OnClick)
			{
				Environment.Exit(0);
			}
			var temp = Keyboard.GetState().GetPressedKeys();
			var t = GetInput(temp);
			if (t == "Back")
				if (ip.Length != 0)
					ip = ip.Remove(ip.Length - 1);
			else
				if (ip.Length < 21)
					ip += t;
			ip_textarea.Text = ip;
			
		}
		
		public void Draw()
		{
			Utilits.SpriteBatch.Draw(background, new Rectangle(0, 0, background.Width, background.Height), new Rectangle(0, 0, swidth, sheight), Color.White);
			Utilits.SpriteBatch.Draw(logo, new Rectangle(20, sheight / 2 - 160, 53 * 4, 80), Color.White);
		}
	}
}
