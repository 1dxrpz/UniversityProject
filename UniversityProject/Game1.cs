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

        private GraphicsDeviceManager graphics;
        private SpriteBatch spriteBatch;

        public Game1()
        {
            graphics = new GraphicsDeviceManager(this);
            Content.RootDirectory = "Content";
            Utilits.Content = Content;
            IsMouseVisible = true;
        }



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

            gameScene = new GameScene(Scene.Game);
            menu = new MenuScene();
            Utilits.Scenes.Add(menu);
            Utilits.Scenes.Add(gameScene);

			//Console.WriteLine(Utilits.Scenes[1].Scene.ToString());

            gameScene.Initialize();
            menu.Initialize();

            Utilits.Scenes[0].Scene = Scene.Menu;
            Utilits.Scenes[1].Scene = Scene.Game;

            Utilits.Scenes.ForEach((v) => {
				if (v.Scene == Utilits.CurrentScene)
				{
                    v.GameObjects.ForEach((e) =>
                    {
                        e.Initialize();
                    });
				}
            });
			foreach (var item in Utilits.Scenes)
			{
				Console.WriteLine(item.Scene.ToString());
			}
            base.Initialize();
        }
        protected override void Update(GameTime gameTime)
        {
            Utilits.GameTime = gameTime;
            Time.Update();
            if (GamePad.GetState(PlayerIndex.One).Buttons.Back == ButtonState.Pressed || Keyboard.GetState().IsKeyDown(Keys.Escape))
                Exit();

            if (Utilits.CurrentScene == Scene.Menu)
            {
                menu.Update();
            }
            if (Utilits.CurrentScene == Scene.Game)
            {
                gameScene.Update();
            }
            
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

            if (Utilits.CurrentScene == Scene.Menu)
            {
                menu.Draw();
            }
            if (Utilits.CurrentScene == Scene.Game)
            {
                Console.WriteLine(1);
                gameScene.Draw();
            }

            
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
