using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;
using Microsoft.Xna.Framework.Input;
using System.Threading.Tasks;
using UniversityProject.server;

namespace UniversityProject
{
	public class Game1 : Game
	{
		private GraphicsDeviceManager graphics;
		private SpriteBatch _spriteBatch;

		public Game1()
		{
			graphics = new GraphicsDeviceManager(this);
			Content.RootDirectory = "Content";
			IsMouseVisible = true;
		}

		protected override void Initialize()
		{
			// TODO: Add your initialization logic here
			base.Initialize();
		}

		SpriteFont font;
		protected override void LoadContent()
		{
			_spriteBatch = new SpriteBatch(GraphicsDevice);
			font = Content.Load<SpriteFont>("font");
			
		}
		bool start = true;
		async void Connect()
		{
			await Task.Run(() => Client.Connect());
		}
		protected override void Update(GameTime gameTime)
		{
			if (GamePad.GetState(PlayerIndex.One).Buttons.Back == ButtonState.Pressed || Keyboard.GetState().IsKeyDown(Keys.Escape))
				Exit();
			if (start)
			{
				Connect();
				start = false;
			}
			base.Update(gameTime);
		}

		protected override void Draw(GameTime gameTime)
		{
			GraphicsDevice.Clear(Color.Tomato);
			_spriteBatch.Begin();
			//_spriteBatch.DrawString(font, Client.GetValue(), new Vector2(10, 10), Color.Black);
			_spriteBatch.End();
			base.Draw(gameTime);
		}
	}
}
