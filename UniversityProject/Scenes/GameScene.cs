using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;
using Microsoft.Xna.Framework.Input;
using System.Collections.Generic;
using System.IO;
using System.Threading.Tasks;
using UniversityProject.Object;
using UniversityProject.Interfaces;
using UniversityProject.server;
using MonoGame.Extended.Tiled;
using MonoGame.Extended.Tiled.Renderers;
using MonoGame.Extended.Graphics;


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

        Player GG;

        TiledMap tileMap;
        TiledMapRenderer mapRender;
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
                Position = new Vector2(50, 300),
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
                    Input = new Input()
                    {
                        OpenInventory = Keys.Tab
                    }
                }
                );
            tileMap = Utilits.Content.Load<TiledMap>("Mapa");
            mapRender = new TiledMapRenderer (Utilits.GraphicsDevice, tileMap);
        }


        public void LoadContent()
        {
           
        }

        public void Update()
        {

            mapRender.Update(Utilits.GameTime);
            Camera.position = Vector2.Lerp(Camera.position, GG.Position - new Vector2(1920, 1080) / 2, .1f);
            foreach (var objec in this.GameObjects)
                objec.Update();
        }

        

        public void Draw()
        {
            Utilits.GraphicsDevice.Clear(Color.Tomato);
            mapRender.Draw(Matrix.CreateScale(2));
            foreach (var objec in this.GameObjects)
                objec.Draw();
        }
    }
}

