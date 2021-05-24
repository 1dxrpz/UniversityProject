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
using UniversityProject.Scenes;

namespace UniversityProject
{
	class MenuScene : GameSceneObject, IGameScene
	{
		Button connect_button;
		Button exit_button;
		Button enter_game_button;
		Button back_button;
		Textarea ip_textarea;
		Textarea name_textarea;
		Button github_li;
		Button github_lya;
		Button github_about;
		int swidth;
		int sheight;
		Texture2D button_hover;
		Texture2D button;
		Texture2D logo;
		Texture2D background;

		List<Button> Buttons;
		List<Textarea> Textareas;

		public new Scene Scene
		{
			get
			{
				return Scene.Menu;
			}
		}
		public MenuScene()
		{
			
		}
		public void Initialize()
		{

			Buttons = new List<Button>();
			Textareas = new List<Textarea>();
			background = Utilits.Content.Load<Texture2D>(@"Menu\background");
			logo = Utilits.Content.Load<Texture2D>(@"Menu\game_logo");
			button = Utilits.Content.Load<Texture2D>(@"Menu\button");
			button_hover = Utilits.Content.Load<Texture2D>(@"Menu\button_hover");
			swidth = Utilits.ScreenSize.X;
			sheight = Utilits.ScreenSize.Y;
			var button_texture = Utilits.Content.Load<Texture2D>(@"Menu\button");
			connect_button = new Button(Scene.Menu, button_texture, new Rectangle(20, (sheight - 38) / 2 - 30, 256, 38), "Connect to server"); ;
			exit_button = new Button(Scene.Menu, button_texture, new Rectangle(20 , (sheight - 38) / 2 + 30, 256, 38), "Exit");
			name_textarea = new Textarea(Scene.Menu, Utilits.Content.Load<Texture2D>(@"Menu\textarea"), new Rectangle(20, (sheight - 38) / 2 - 30, 256, 38), "");
			ip_textarea = new Textarea(Scene.Menu, Utilits.Content.Load<Texture2D>(@"Menu\textarea"), new Rectangle(20, (sheight - 38) / 2 + 30, 256, 38), "");
			enter_game_button = new Button(Scene.Menu, button_texture, new Rectangle( 20, (sheight - 38) / 2 + 90, 256, 38), "Connect");
			back_button = new Button(Scene.Menu, button_texture, new Rectangle(20 , (sheight - 38) / 2 + 150, 256, 38), "Back");

			github_li = new Button(Scene.Menu, new Rectangle(20, (sheight - 40), 60, 40), "dxrpz");
			github_lya = new Button(Scene.Menu, new Rectangle(90, (sheight - 40), 40, 40), "Mac");
			github_about = new Button(Scene.Menu, new Rectangle(140, (sheight - 40), 60, 40), "About");

			Buttons.Add(connect_button);
			Buttons.Add(exit_button);
			Buttons.Add(enter_game_button);
			Buttons.Add(back_button);

			Textareas.Add(name_textarea);
			Textareas.Add(ip_textarea);

			enter_game_button.IsVisible = false;
			back_button.IsVisible = false;
			ip_textarea.IsVisible = false;
			name_textarea.IsVisible = false;
			ip_textarea.Anchor = Anchor.Left;
			ip_textarea.TextColor = Color.Black;

			name_textarea.Anchor = Anchor.Left;
			name_textarea.TextColor = Color.Black;

		}
		
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

			Textareas.ForEach((v) =>
			{
				var temp = v.IsFocused;
				if (v.OnClick)
				{
					v.IsFocused = true;
				}
				if (Mouse.GetState().LeftButton == ButtonState.Pressed && !v.IsHover)
					v.IsFocused = false;
			});

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
				name_textarea.IsVisible = true;
			}
			if (back_button.OnClick)
			{
				connect_button.IsVisible = true;
				exit_button.IsVisible = true;
				enter_game_button.IsVisible = false;
				back_button.IsVisible = false;
				ip_textarea.IsVisible = false;
				name_textarea.IsVisible = false;
			}
			if (enter_game_button.OnClick)
			{
				try
				{
					Utilits.Connect(name_textarea.Text, ip_textarea.Text.Split(":")[0], int.Parse(ip_textarea.Text.Split(":")[1]));
					Console.WriteLine("connection success");
				} catch
				{
					Console.WriteLine("connection error");
				}
				finally
				{
					//Utilits.CurrentScene = Scene.Game;
				}
			}
			if (exit_button.OnClick)
			{
				Environment.Exit(0);
			}
			
			
		}
		
		public void Draw()
		{
			//Utilits.SpriteBatch.Draw(background, new Rectangle(0, 0, background.Width, background.Height), new Rectangle(0, 0, swidth, sheight), Color.White);
			//Utilits.SpriteBatch.Draw(logo, new Rectangle(20, sheight / 2 - 180, 53 * 4, 80), Color.White);
		}
	}
}
