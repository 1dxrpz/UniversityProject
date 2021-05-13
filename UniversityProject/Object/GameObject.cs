using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;
using Microsoft.Xna.Framework.Input;
using System;
using System.Collections.Generic;
using System.Text;
using UniversityProject.Interfaces;
using UniversityProject.Object;

namespace UniversityProject
{
    class GameObject : IGameObjects
    {
        protected Texture2D _texture;

        public Vector2 Position;
        public Vector2 Velocity;
        public Color Colour = Color.White;
        public float Speed;
        public Input Input;

        public Rectangle Rectangle
        {
            get
            {
                if (this is Player)
                    return new Rectangle((int)Position.X, (int)Position.Y, 24 * 4, 24 * 4);
                else if (this is GameObject)
                    return new Rectangle((int)Position.X, (int)Position.Y, _texture.Width * 3, _texture.Height * 4);
                return default;
            }
        }

        public GameObject(Texture2D texture)
        {
            _texture = texture;
        }


        #region Colloision
        protected bool IsTouchingLeft(GameObject sprite)
        {
            return this.Rectangle.Right + this.Velocity.X > sprite.Rectangle.Left &&
              this.Rectangle.Left < sprite.Rectangle.Left &&
              this.Rectangle.Bottom > sprite.Rectangle.Top &&
              this.Rectangle.Top < sprite.Rectangle.Bottom;
        }

        protected bool IsTouchingRight(GameObject sprite)
        {
            return this.Rectangle.Left + this.Velocity.X < sprite.Rectangle.Right &&
              this.Rectangle.Right > sprite.Rectangle.Right &&
              this.Rectangle.Bottom > sprite.Rectangle.Top &&
              this.Rectangle.Top < sprite.Rectangle.Bottom;
        }

        protected bool IsTouchingTop(GameObject sprite)
        {
            return this.Rectangle.Bottom + this.Velocity.Y > sprite.Rectangle.Top &&
              this.Rectangle.Top < sprite.Rectangle.Top &&
              this.Rectangle.Right > sprite.Rectangle.Left &&
              this.Rectangle.Left < sprite.Rectangle.Right;
        }

        protected bool IsTouchingBottom(GameObject sprite)
        {
            return this.Rectangle.Top + this.Velocity.Y < sprite.Rectangle.Bottom &&
              this.Rectangle.Bottom > sprite.Rectangle.Bottom &&
              this.Rectangle.Right > sprite.Rectangle.Left &&
              this.Rectangle.Left < sprite.Rectangle.Right;
        }



        #endregion

        public void Initialize()
        {

        }

        public void Update()
        {

        }

        public void Draw()
        {
            if (this is Player)
            {
                Utilits.SpriteBatch.Draw
                (_texture,
                new Rectangle
                    (Position.ToPoint() - Camera.position.ToPoint(),
                    new Point(96, 96)),
                new Rectangle(0, 0, 24, 24),
                Color.White);
            }
            else if (this is MapObject)
            {
                Utilits.SpriteBatch.Draw
                 (_texture,
                 new Rectangle
                     (Position.ToPoint() - Camera.position.ToPoint(),
                     new Point(64, 64)),
                 new Rectangle(0, 0, 16, 16),
                 Color.White);
            }
        }
    }
}