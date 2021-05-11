using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;
using Microsoft.Xna.Framework.Input;
using System.Collections.Generic;
using System.IO;
using System.Threading.Tasks;
using UniversityProject.Object;
using UniversityProject.server;

namespace UniversityProject
{
    public class Game1 : Game
    {
        private GraphicsDeviceManager graphics;
        private SpriteBatch spriteBatch;

        private List<GameObject> objects;

        public Game1()
        {
            graphics = new GraphicsDeviceManager(this);
            Content.RootDirectory = "Content";
            Utilits.Content = Content;
            IsMouseVisible = true;
        }

        TileMap Atlas;
        protected override void Initialize()
        {
            Atlas = new TileMap();
            Atlas.Texture = Content.Load<Texture2D>("Gate");
            FullScreen();
            base.Initialize();

            

            for (int x = 0; x < 32; x++)
            {
                for (int y = 0; y < 32; y++)
                {
                    Atlas.AddTile((char)(y * 32 + x + 50), new Vector2(x, y));
                    Atlas.SetTiles((char)(y * 32 + x + 50), new Vector2(x, y));
                }
            }
        }

        private void FullScreen()
        {
            graphics.IsFullScreen = true;
            graphics.PreferredBackBufferWidth = 1920;
            graphics.PreferredBackBufferHeight = 1080;
            Window.Title = "2D Tyan";
            graphics.ApplyChanges();
        }

        protected override void LoadContent()
        {
            spriteBatch = new SpriteBatch(GraphicsDevice);
            Utilits.SpriteBatch = spriteBatch;

            objects = new List<GameObject>()
            {
                new Player(Content.Load<Texture2D>("Tyan"))
                {
                    Input = new Input()
                    {
                        Up = Keys.W,
                        Down = Keys.S,
                        Right = Keys.D,
                        Left = Keys.A,
                    },
                    Position = new Vector2(100,100),
                    Colour = Color.White,
                    Speed = 8,
                },
                new MapObject(Content.Load<Texture2D>("chest"))
                {
                    Position = new Vector2(50,50)
                }
            };

        }
        bool start = true;
        protected override void Update(GameTime gameTime)
        {
            Utilits.GameTime = gameTime;
            if (GamePad.GetState(PlayerIndex.One).Buttons.Back == ButtonState.Pressed || Keyboard.GetState().IsKeyDown(Keys.Escape))
                Exit();
            Camera.position = Vector2.Lerp(Camera.position, objects[0].Position - new Vector2(1920, 1080) / 2, .2f);
            foreach (var objec in objects)
                objec.Update(gameTime,objects);
            if (start)
			{
				Connect("tan", "192.168.1.252",8888);
				start = false;
			}
            base.Update(gameTime);
        }
		async void Connect(string name, string ip, int port)
		{
			//await Task.Run(() => Client.Connect(name, ip, port));
		}
		

        protected override void Draw(GameTime gameTime)
        {
            GraphicsDevice.Clear(Color.Tomato);

            spriteBatch.Begin(SpriteSortMode.FrontToBack, BlendState.AlphaBlend, SamplerState.PointClamp);
            Atlas.Draw();
            foreach (var objec in objects)
                objec.Draw(spriteBatch);
            spriteBatch.End();

            base.Draw(gameTime);
        }
    }
}
