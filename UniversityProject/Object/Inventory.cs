using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;
using Microsoft.Xna.Framework.Input;
using System;
using System.Collections.Generic;
using System.Text;
using UniversityProject.Object;

namespace UniversityProject
{
    class Inventory : GameObject
    {

        public Inventory(Scene scene,Texture2D texture)
            : base (scene, texture)
        {

        }

        public void Update()
        {
            OpenInv = IsOpenInv();
        }

        public void Draw()
        {

        }
        
    }
}
