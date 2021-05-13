using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;
using Microsoft.Xna.Framework.Input;
using System.Collections.Generic;
using System.IO;
using System.Threading.Tasks;
using UniversityProject.Object;
using UniversityProject.Interfaces;
using UniversityProject.server;

namespace UniversityProject.Scenes
{
    class GameScene : GameSceneObject, IGameScene
    {

        public GameScene()
        {
            Utilits.Content.RootDirectory = "Content";
        }

        public void  Initialize() 
        {
            //objects = new List<GameObject>()
            //{
            //    new Player(Utilits.Content.Load<Texture2D>("Tyan"))
            //    {
            //        Input = new Input()
            //        {
            //            Up = Keys.W,
            //            Down = Keys.S,
            //            Right = Keys.D,
            //            Left = Keys.A,
            //            OpenInventory = Keys.Tab,
            //        },
            //        Position = new Vector2(100,100),
            //        Colour = Color.White,
            //        Speed = 8,
            //    },
            //    new MapObject(Utilits.Content.Load<Texture2D>("chest"))
            //    {
            //        Position = new Vector2(50,50)
            //    }
            //};
        }

        public void LoadContent()
        {
           
        }

        public void Update()
        {
            //Camera.position = Vector2.Lerp(Camera.position, objects[0].Position - new Vector2(1920, 1080) / 2, .2f);

            //foreach (var objec in objects)
            //    objec.Update(Utilits.GameTime, objects);
        }

        

        public void Draw()
        {
        //    Utilits.GraphicsDevice.Clear(Color.Tomato);

        //    foreach (var objec in objects)
        //        objec.Draw(Utilits.SpriteBatch);
        }
    }
}

