using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;
using Microsoft.Xna.Framework.Input;
using System;
using System.Collections.Generic;
using System.IO;
using System.Runtime.InteropServices;
using System.Threading.Tasks;
using UniversityProject.GUI;
using UniversityProject.server;

namespace UniversityProject
{
    public class Game1 : Game
    {
        [DllImport("kernel32")]
        static extern bool AllocConsole(); // для дебага

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

        List<Player> players;

        Button button;
        Button button2;

        protected override void Initialize()
        {
            spriteBatch = new SpriteBatch(GraphicsDevice);
            Utilits.GraphicsDevice = this.GraphicsDevice;
            Utilits.Content = this.Content;
            Utilits.SpriteBatch = spriteBatch;
            AllocConsole();
            button = new Button(new Rectangle(100, 100, 100, 100));
            button2 = new Button(new Rectangle(300, 100, 100, 100));
			#region temp
			/*
            players = new List<Player>();
            Rancher = new Player();
            Atlas = new TileMap();
            Atlas.Texture = Content.Load<Texture2D>("Gate");
            FullScreen();
            base.Initialize();
            
            //string[] map = File.ReadAllLines(@"C:\Users\IlyaNB\Desktop\Map.txt");
            
            //Atlas.AddTile('.', new Vector2(1, 18));
            //Atlas.AddTile('!', new Vector2(1, 22));
            //Atlas.AddTile('#', new Vector2(2, 16));
            
            
            for (int a = 0; a < map.Length; a++)
            {
                for (int b = 0; b < map[a].Length; b++)
                {
                    Atlas.SetTiles((map[a][b]), new Vector2(b, a));
                }
            }
            
            for (int x = 0; x < 32; x++)
            {
                for (int y = 0; y < 32; y++)
                {
                    Atlas.AddTile((char)(y * 32 + x + 50), new Vector2(x, y));
                    Atlas.SetTiles((char)(y * 32 + x + 50), new Vector2(x, y));
                }
            }
            */
			#endregion
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
            
        }

        bool start = true;
        protected override void Update(GameTime gameTime)
        {
            Utilits.GameTime = gameTime;

			if (button.IsHover)
			{
                Console.WriteLine("lol");
			}
            if (button2.IsPressed)
			{
                Console.WriteLine("kek");
			}

            if (GamePad.GetState(PlayerIndex.One).Buttons.Back == ButtonState.Pressed || Keyboard.GetState().IsKeyDown(Keys.Escape))
				Exit();
			//if (start)
			//{
			//	//Connect("test1", "192.168.1.252", 8888);
			//	start = false;
			//}
            //
            //if (GamePad.GetState(PlayerIndex.One).Buttons.Back == ButtonState.Pressed || Keyboard.GetState().IsKeyDown(Keys.Escape))
            //    Exit();
            //Camera.position = Vector2.Lerp(Camera.position, Rancher.position - new Vector2(1920, 1080) / 2, .2f);
            //Rancher.Update();
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
            Utilits.GameObjects.ForEach((v) => v.Draw());
            //Atlas.Draw();
            //Rancher.Draw();
            spriteBatch.End();

            base.Draw(gameTime);
        }
    }
}
