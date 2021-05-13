using System;
using System.Collections.Generic;
using System.Text;
using UniversityProject.Interfaces;

namespace UniversityProject.Scenes
{
	public class GameSceneObject : IGameScene
	{
		public List<IGameObjects> GameObjects = new List<IGameObjects>();

		public Scene Scene => Scene.Game;
		public GameSceneObject()
		{
			
		}


		public void Draw()
		{
			
		}

		public void Initialize()
		{
			
		}

		public void Update()
		{
			
		}
	}
}
