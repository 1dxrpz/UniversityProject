using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;
using Microsoft.Xna.Framework.Input;
using System;
using System.Collections.Generic;
using System.Text;
using UniversityProject.Interfaces;

namespace UniversityProject.GUI
{
	enum Anchor
	{
		Left, Right, Top, Bottom,
		TopLeft, TopRight,
		BottomLeft, BottomRight,
		Center
	}
	class Button : IGameObjects
	{
		public Rectangle Bounds;
		public Texture2D Texture;
		public string Text;
		public Color TextColor = Color.Black;
		public bool IsVisible = true;
		public Anchor Anchor = Anchor.Center;
		// 5 перегрузок, специально для тебя, ляпа ♥
		public Button(string text = "")
		{
			Bounds = new Rectangle(0, 0, 10, 10);
			Texture = Utilits.GetTexture(Color.AliceBlue);
			Utilits.GameObjects.Add(this);
			Text = text;
		}
		public Button(Rectangle bounds, string text = "")
		{
			Bounds = bounds;
			Texture = Utilits.GetTexture(Color.AliceBlue);
			Utilits.GameObjects.Add(this);
			Text = text;
		}
		public Button(Texture2D texture, string text = "")
		{
			Bounds = new Rectangle(0, 0, 10, 10);
			Texture = texture;
			Utilits.GameObjects.Add(this);
			Text = text;
		}
		public Button(Texture2D texture, Rectangle bounds, string text = "")
		{
			Bounds = bounds;
			Texture = texture;
			Utilits.GameObjects.Add(this);
			Text = text;
		}
		public Button(Rectangle bounds, Texture2D texture, string text = "")
		{
			Bounds = bounds;
			Texture = texture;
			Utilits.GameObjects.Add(this);
			Text = text;
		}
		private bool temp = true;
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

		SpriteFont font;
		Vector2 fsize;
		public void Initialize()
		{
			font = Utilits.Content.Load<SpriteFont>("DefaultFont");
			
		}
		public void Update()
		{
			
		}

		public Vector2 Origin;
		public Vector2 Position;
		public void Draw()
		{
			if (IsVisible)
			{
				fsize = font.MeasureString(Text);
				switch (this.Anchor)
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
