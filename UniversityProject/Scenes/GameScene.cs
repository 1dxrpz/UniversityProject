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
		public Scene Scene => Scene.Game;

        public GameScene()
		{
            Utilits.Scenes.Add(this);
        }
        Player GG;
		public void  Initialize() 
        {
            GG = new Player(Scene.Game, Utilits.Content.Load<Texture2D>("test"))
            {
                Input = new Input()
                {
                    Up = Keys.W,
                    Down = Keys.S,
                    Right = Keys.D,
                    Left = Keys.A,
                    OpenInventory = Keys.Tab,
                },
                Position = new Vector2(50, 50),
                Speed = 100,
            };
            GameObjects.Add(GG);
            GameObjects.Add(
                new MapObject(Scene.Game, Utilits.Content.Load<Texture2D>("test"))
                {
                    Position = new Vector2(200, 200)
                }
            );
            GameObjects.Add(
                new Inventory(Scene.Game, Utilits.Content.Load<Texture2D>("066"))
                {
                    Position = new Vector2(480 * 2 + 400, 230 * 2 + 200),
                    OpenInv = false,
                }
                );
        }


        public void LoadContent()
        {
           
        }

        public void Update()
        {
            Camera.position = Vector2.Lerp(Camera.position, GG.Position - new Vector2(1920, 1080) / 2, .1f);
            
            foreach (var objec in this.GameObjects)
                objec.Update();
        }

        

        public void Draw()
        {
            Utilits.GraphicsDevice.Clear(Color.Tomato);

            foreach (var objec in this.GameObjects)
                objec.Draw();
        }
    }
}

