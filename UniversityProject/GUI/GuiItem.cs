using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;
using Microsoft.Xna.Framework.Input;
using System;
using System.Collections.Generic;
using System.Text;
using UniversityProject.Interfaces;

namespace UniversityProject.GUI
{
	public enum Anchor
	{
		Left, Right, Top, Bottom,
		TopLeft, TopRight,
		BottomLeft, BottomRight,
		Center
	}
	public class GuiItem : IGameObjects
	{
		public Scene Scene;
		public Rectangle Bounds;
		public Texture2D Texture;
		public bool IsVisible = true;
		public string Text;
		public Color TextColor = Color.Black;
		public Anchor Anchor = Anchor.Center;
		public Vector2 Origin;
		public Vector2 Position;
		private bool temp = true;
		SpriteFont font;
		Vector2 fsize;
		public bool IsHover
		{
			get
			{
				return IsVisible && Mouse.GetState().X >= Bounds.X &&
					Mouse.GetState().Y >= Bounds.Y &&
					Mouse.GetState().X <= Bounds.X + Bounds.Width &&
					Mouse.GetState().Y <= Bounds.Y + Bounds.Height;
			}
		}
		public bool IsPressed
		{
			get
			{
				return IsHover && Mouse.GetState().LeftButton == ButtonState.Pressed;
			}
		}
		public bool OnClick
		{
			get
			{
				if (IsPressed && temp)
				{
					temp = false;
					return true;
				}
				if (Mouse.GetState().LeftButton == ButtonState.Released)
				{
					temp = true;
				}
				return false;
			}
		}
		public bool OnRelease
		{
			get
			{
				return Mouse.GetState().LeftButton == ButtonState.Released && IsHover;
			}
		}

		public GuiItem(Scene scene, string text = "")
		{
			Bounds = new Rectangle(0, 0, 10, 10);
			Texture = Utilits.GetTexture(Color.AliceBlue);
			Text = text;
			Utilits.Scenes.Find((v) => v.Scene == scene).GameObjects.Add(this);
		}
		public GuiItem(Scene scene, Rectangle bounds, string text = "")
		{
			Bounds = bounds;
			Texture = Utilits.GetTexture(Color.AliceBlue);
			Text = text;
			Utilits.Scenes.Find((v) => v.Scene == scene).GameObjects.Add(this);
		}
		public GuiItem(Scene scene, Texture2D texture, string text = "")
		{
			Bounds = new Rectangle(0, 0, 10, 10);
			Texture = texture;
			Text = text;
			Utilits.Scenes.Find((v) => v.Scene == scene).GameObjects.Add(this);
		}
		public GuiItem(Scene scene, Texture2D texture, Rectangle bounds, string text = "")
		{
			Bounds = bounds;
			Texture = texture;
			Text = text;
			Utilits.Scenes.Find((v) => v.Scene == scene).GameObjects.Add(this);
		}

		public void Initialize()
		{
			font = Utilits.Content.Load<SpriteFont>("DefaultFont");
		}

		public void Update()
		{
			
		}

		public void Draw()
		{
			if (IsVisible)
			{
				fsize = font.MeasureString(Text);
				switch (Anchor)
				{
					case Anchor.Center: Origin = new Vector2(fsize.X, fsize.Y) / 2; Position = new Vector2(Bounds.X + Bounds.Width / 2, Bounds.Y + Bounds.Height / 2); break;
					case Anchor.Left: Origin = new Vector2(0, fsize.Y) / 2; Position = new Vector2(Bounds.X + 10, Bounds.Y + Bounds.Height / 2); break;
					case Anchor.Right: Origin = new Vector2(fsize.X, fsize.Y / 2); Position = new Vector2(Bounds.X + Bounds.Width - 10, Bounds.Y + Bounds.Height / 2); break;
				}
				Utilits.SpriteBatch.Draw(Texture, Bounds, Color.White);
				Utilits.SpriteBatch.DrawString(font, Text, Position,
					TextColor, 0, Origin, 1f, SpriteEffects.None, 1);
			}
		}
	}
}
