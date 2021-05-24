using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;
using Microsoft.Xna.Framework.Input;
using System;
using System.Collections.Generic;
using System.Text;
using UniversityProject.Object;
using UniversityProject.Scenes;

namespace UniversityProject
{
    class Player : GameObject
    {
        public Player(Scene scene, Texture2D texture)
             : base(scene, texture)
        {
            
        }

		public override void Update()
        {
            Action();
            foreach (GameObject sprite in Utilits.Scenes.Find((v) => v.Scene == Scene.Game).GameObjects)
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


            Position += Velocity ;

            Velocity = Vector2.Zero;
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
           
            Velocity *= Time.deltaTime;

        }
        


    }
}