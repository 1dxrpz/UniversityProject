using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;
using Microsoft.Xna.Framework.Input;
using System;
using System.Collections.Generic;
using System.Text;
using UniversityProject.Object;
using UniversityProject.Interfaces;
using UniversityProject.GUI;

namespace UniversityProject
{
    class Inventory : GameObject, IGameObjects
    {
        public Vector2 Position;
        public Input Input;
        public bool temp = true;
        private int ctemp = 0;
        public bool OpenInv
        {
            get
            {
                if (Keyboard.GetState().IsKeyDown(Input.OpenInventory) && temp)
                {
                    temp = false;
                    ctemp++;
                    ctemp %= 2;
                    return ctemp == 0;
                }
                if (Keyboard.GetState().IsKeyUp(Input.OpenInventory))
                {
                    temp = true;
                }
                return ctemp % 2 == 1;
            }
        }

        public Inventory(Scene scene,Texture2D texture)
            : base (scene, texture)
        {

        }

        public void Initialize()
        {
        }

        public void Update()
        {
        }

        public void Draw()
        {
            if (OpenInv == true)
            {
                Utilits.SpriteBatch.Draw
                 (Utilits.Content.Load<Texture2D>("066"),
                 new Rectangle
                     (Position.ToPoint(),
                     new Point(500, 348)),
                 Color.White);
            }
        }

        

        
    }
}
