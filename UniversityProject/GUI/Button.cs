using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;
using Microsoft.Xna.Framework.Input;
using System;
using System.Collections.Generic;
using System.Text;
using UniversityProject.Interfaces;

namespace UniversityProject.GUI
{
	class Button : IGameObjects
	{
		public Rectangle Bounds;
		Texture2D Texture;
		public string Text;
		public Color TextColor = Color.Black;
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
		private bool tempr = true;
		public bool IsHover
		{
			get
			{
				return Mouse.GetState().X >= Bounds.X &&
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
			fsize = font.MeasureString(Text);
		}
		public void Update()
		{
			
		}
		public void Draw()
		{
			
			Utilits.SpriteBatch.Draw(Texture, Bounds, Color.White);
			Utilits.SpriteBatch.DrawString(font, Text, new Vector2(
				Bounds.X + Bounds.Width / 2,
				Bounds.Y + Bounds.Height / 2),
				TextColor, 0, new Vector2(fsize.X, fsize.Y) / 2, 1.5f, SpriteEffects.None, 1);
			Utilits.SpriteBatch.DrawString(font, "", Vector2.Zero, Color.White);
		}
	}
}
