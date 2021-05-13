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
using UniversityProject.Scenes;

namespace UniversityProject
{
    public class Game1 : Game
    {
        [DllImport("kernel32")]
        static extern bool AllocConsole(); // для дебага
        private List<GameObject> objects;

        private GraphicsDeviceManager graphics;
        private SpriteBatch spriteBatch;

        public Game1()
        {
            graphics = new GraphicsDeviceManager(this);
            Content.RootDirectory = "Content";
            Utilits.Content = Content;
            IsMouseVisible = true;
        }

        //Player Rancher;
        TileMap Atlas;
        //List<Player> players;


        GameScene gameScene;
        MenuScene menu;

        private void FullScreen()
        {
            graphics.IsFullScreen = true;
            graphics.PreferredBackBufferWidth = 1920;
            graphics.PreferredBackBufferHeight = 1080;
            Window.Title = "Game Project";
            graphics.ApplyChanges();
        }
        protected override void Initialize()
        {
            FullScreen();
            if (!File.Exists(@".\settings"))
            {
                File.WriteAllText(@".\settings", "");
                Utilits.AddSetting("nickname", "dxrpz");
                Utilits.AddSetting("defaultIp", "192.168.0.1");
                Utilits.AddSetting("defaultPort", "8888");
                Utilits.ApplySettings();
            }
			foreach (var item in File.ReadAllLines(@".\settings"))
			{
                //Utilits.Settings.Add(item.Split(":")[0], item.Split(":")[1]);
			}
            spriteBatch = new SpriteBatch(GraphicsDevice);
            Utilits.GraphicsDevice = GraphicsDevice;
            Utilits.Content = Content;
            Utilits.SpriteBatch = spriteBatch;
            Utilits.ScreenSize = new Point(graphics.PreferredBackBufferWidth, graphics.PreferredBackBufferHeight);
            AllocConsole();

            gameScene = new GameScene();
            gameScene.Initialize();
            menu = new MenuScene();
            menu.Initialize();
            Utilits.Scenes.ForEach((v) => {
				if (v.Scene == Utilits.CurrentScene)
				{
                    v.GameObjects.ForEach((e) =>
                    {
                        e.Initialize();
                    });
				}
            });
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
            base.Initialize();
        }
	
		
        protected override void LoadContent()
        {
            gameScene.LoadContent();
            
        }

        bool start = true;
        protected override void Update(GameTime gameTime)
        {
            Utilits.GameTime = gameTime;
            if (GamePad.GetState(PlayerIndex.One).Buttons.Back == ButtonState.Pressed || Keyboard.GetState().IsKeyDown(Keys.Escape))
                Exit();

            Utilits.Scenes.ForEach((v) => {
                if (v.Scene == Utilits.CurrentScene)
                {
                    v.GameObjects.ForEach((e) =>
                    {
                        e.Update();
                    });
                }
            });
            base.Update(gameTime);
        }
        protected override void Draw(GameTime gameTime)
        {
            GraphicsDevice.Clear(Color.White);
            
            spriteBatch.Begin(SpriteSortMode.FrontToBack, BlendState.AlphaBlend, SamplerState.PointClamp);
            gameScene.Draw();
            menu.Draw();
            menu.Update();
            Utilits.Scenes.ForEach((v) => {
                if (v.Scene == Utilits.CurrentScene)
                {
                    v.GameObjects.ForEach((e) =>
                    {
                        e.Draw();
                    });
                }
            });
            spriteBatch.End();

            base.Draw(gameTime);
        }
    }
}
