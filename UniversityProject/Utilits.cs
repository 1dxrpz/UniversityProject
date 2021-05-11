using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Content;
using Microsoft.Xna.Framework.Graphics;
using System;
using System.Collections.Generic;
using System.Text;
using UniversityProject.Interfaces;

namespace UniversityProject
{
    class Utilits
    {
        public static List<IGameObjects> GameObjects = new List<IGameObjects>();
        public static ContentManager Content;
        public static SpriteBatch SpriteBatch;
        public static GameTime GameTime;
        public static GraphicsDevice GraphicsDevice;
        public static Texture2D GetTexture(Color color)
		{
            if (Utilits.GraphicsDevice != null)
			{
                Color[] data = new Color[1] { color };
                Texture2D temp = new Texture2D(Utilits.GraphicsDevice, 1, 1);
                temp.SetData(data);
                return temp;
            }
            return null;
        }
    }
}
