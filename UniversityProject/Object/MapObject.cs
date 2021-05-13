using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;
using Microsoft.Xna.Framework.Input;
using System;
using System.Collections.Generic;
using System.Text;

namespace UniversityProject.Object
{
    class MapObject : GameObject
    {
        public MapObject(Texture2D texture)
            : base(texture)
        {

        }

        public override void Update(GameTime gameTime, List<GameObject> sprites)
        {
        }
    }
}