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
		public new Scene Scene
		{
			get
			{
                return Scene.Game;
            }
		}

        public GameScene(Scene s)
		{
            //Scene = s;
        }
        Player player;
		public void Initialize() 
        {
            player = new Player(Scene.Game, Utilits.Content.Load<Texture2D>("Tyan"))
            {
                Input = new Input()
                {
                    Up = Keys.W,
                    Down = Keys.S,
                    Right = Keys.D,
                    Left = Keys.A,
                    OpenInventory = Keys.Tab,
                },
                Position = new Vector2(100, 100),
                Speed = 100,
            };
            GameObjects.Add(player);
            GameObjects.Add(
                new MapObject(Scene.Game, Utilits.Content.Load<Texture2D>("chest"))
                {
                    Position = new Vector2(50, 50)
                }
            );
        }

        public void LoadContent()
        {
           
        }

        public void Update()
        {
            Camera.position = Vector2.Lerp(Camera.position, player.Position - new Vector2(1920, 1080) / 2, .2f);

            foreach (var objec in this.GameObjects)
                objec.Update();
        }

        

        public void Draw()
        {
        //    Utilits.GraphicsDevice.Clear(Color.Tomato);

            foreach (var objec in this.GameObjects)
                objec.Draw();
        }
    }
}

