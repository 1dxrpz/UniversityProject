using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;
using Microsoft.Xna.Framework.Input;
using System;
using System.Collections.Generic;
using System.Text;
using UniversityProject.Object;

namespace UniversityProject
{
    class Player : GameObject
    {
        public Player(Texture2D texture)
             : base(texture)
        {

        }
        public void Update(GameTime gameTime, List<GameObject> sprites)
        {
            Action();

            foreach (var sprite in sprites)
            {
                if (sprite == this)
                    continue;

                if ((this.Velocity.X > 0 && this.IsTouchingLeft(sprite)) ||
                    (this.Velocity.X < 0 & this.IsTouchingRight(sprite)))
                    this.Velocity.X = 0;

                if ((this.Velocity.Y > 0 && this.IsTouchingTop(sprite)) ||
                    (this.Velocity.Y < 0 & this.IsTouchingBottom(sprite)))
                    this.Velocity.Y = 0;
            }

            Position += Velocity;

            Velocity = Vector2.Zero;
        }

        public void Draw()
        {
            Utilits.SpriteBatch.Draw
                (_texture,
                new Rectangle
                    (Position.ToPoint() - Camera.position.ToPoint(),
                    new Point(96, 96)),
                new Rectangle(0, 0, 24, 24),
                Color.White);
            //spriteBatch.Draw(_texture, Position - Camera.position, Colour);
        }

        private void Action()
        {
            if (Keyboard.GetState().IsKeyDown(Input.Left))
                Velocity.X = -Speed;
            else if (Keyboard.GetState().IsKeyDown(Input.Right))
                Velocity.X = Speed;

            if (Keyboard.GetState().IsKeyDown(Input.Up))
                Velocity.Y = -Speed;
            else if (Keyboard.GetState().IsKeyDown(Input.Down))
                Velocity.Y = Speed;

            if (Keyboard.GetState().IsKeyDown(Input.OpenInventory))
            {

            }

        }
    }
}