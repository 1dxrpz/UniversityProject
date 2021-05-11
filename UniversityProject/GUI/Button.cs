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
		Rectangle Bounds;
		Texture2D Texture;
		// 5 перегрузок, специально для тебя, ляпа ♥
		public Button()
		{
			Bounds = new Rectangle(0, 0, 10, 10);
			Texture = Utilits.GetTexture(Color.AliceBlue);
			Utilits.GameObjects.Add(this);
		}
		public Button(Rectangle bounds)
		{
			Bounds = bounds;
			Texture = Utilits.GetTexture(Color.AliceBlue);
			Utilits.GameObjects.Add(this);
		}
		public Button(Texture2D texture)
		{
			Bounds = new Rectangle(0, 0, 10, 10);
			Texture = texture;
			Utilits.GameObjects.Add(this);
		}
		public Button(Texture2D texture, Rectangle bounds)
		{
			Bounds = bounds;
			Texture = texture;
			Utilits.GameObjects.Add(this);
		}
		public Button(Rectangle bounds, Texture2D texture)
		{
			Bounds = bounds;
			Texture = texture;
			Utilits.GameObjects.Add(this);
		}
		private bool temp = true;
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
		void Initialize()
		{

		}
		public void Update()
		{
			
		}
		public void Draw()
		{
			Utilits.SpriteBatch.Draw(Texture, Bounds, Color.White);
		}
	}
}
