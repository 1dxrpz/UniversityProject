using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;
using Microsoft.Xna.Framework.Input;
using System;
using System.Collections.Generic;
using System.Text;

namespace UniversityProject
{
    class Player
    {
        public Texture2D texture;
        public Vector2 position;
        public float speed;
        public float velosity = 8;
        public Texture2D ColTexture;
        public Rectangle Colision;

        public Player()
        {
            texture = Utilits.Content.Load<Texture2D>("Tyan");
            position = new Vector2(100, 100);
            speed += velosity;
        }

        public void Update()
        {
            ColTexture = Utilits.Content.Load<Texture2D>("chest");
            Colision = new Rectangle(50, 50, 64, 64);

            if (position.Y == Colision.Y)


            Move();
        }

        private void Move()
        {
            KeyboardState k = Keyboard.GetState();

            if (k.IsKeyDown(Keys.W))
            {
                position.Y -= speed;
            }
            else if (k.IsKeyDown(Keys.S))
            {
                position.Y += speed;
            }

            if (k.IsKeyDown(Keys.D))
            {
                position.X += speed;
            }
            else if (k.IsKeyDown(Keys.A))
            {
                position.X -= speed;
            }
        }

        public void Draw()
        {
            Utilits.SpriteBatch.Draw(texture, new Rectangle(position.ToPoint() - Camera.position.ToPoint(), new Point(96, 96)), new Rectangle(0, 0, 24, 24), Color.White);
        }
    }

    static class Camera
    {
        static public Vector2 position = Vector2.Zero;
    }
}
