using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;
using Microsoft.Xna.Framework.Input;
using System.IO;
using System.Threading.Tasks;
using UniversityProject.server;

namespace UniversityProject
{
    public class Game1 : Game
    {
        private GraphicsDeviceManager graphics;
        private SpriteBatch spriteBatch;

        public Game1()
        {
            graphics = new GraphicsDeviceManager(this);
            Content.RootDirectory = "Content";
            Utilits.Content = Content;
            IsMouseVisible = true;
        }

        Player Rancher;
        TileMap Atlas;
        protected override void Initialize()
        {
            Rancher = new Player();
            Atlas = new TileMap();
            Atlas.Texture = Content.Load<Texture2D>("Gate");
            FullScreen();
            base.Initialize();

            //string[] map = File.ReadAllLines(@"C:\Users\IlyaNB\Desktop\Map.txt");

            //Atlas.AddTile('.', new Vector2(1, 18));
            //Atlas.AddTile('!', new Vector2(1, 22));
            //Atlas.AddTile('#', new Vector2(2, 16));


            //for (int a = 0; a < map.Length; a++)
            //{
            //    for (int b = 0; b < map[a].Length; b++)
            //    {
            //        Atlas.SetTiles((map[a][b]), new Vector2(b, a));
            //    }
            //}

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

        }
        bool start = true;
        protected override void Update(GameTime gameTime)
        {
            Utilits.GameTime = gameTime;
            if (GamePad.GetState(PlayerIndex.One).Buttons.Back == ButtonState.Pressed || Keyboard.GetState().IsKeyDown(Keys.Escape))
                Exit();
            Camera.position = Vector2.Lerp(Camera.position, Rancher.position - new Vector2(1920, 1080) / 2, .2f);
            Rancher.Update();
            if (start)
			{
				Connect();
				start = false;
			}
            base.Update(gameTime);
        }
		async void Connect(string name, string ip, int port)
		{
			await Task.Run(() => Client.Connect(name, ip, port));
		}
		

        protected override void Draw(GameTime gameTime)
        {
            GraphicsDevice.Clear(Color.Tomato);

            spriteBatch.Begin(SpriteSortMode.FrontToBack, BlendState.AlphaBlend, SamplerState.PointClamp);
            Atlas.Draw();
            Rancher.Draw();
            spriteBatch.End();

            base.Draw(gameTime);
        }
    }
}
