using System;
using System.Collections.Generic;
using System.Text;
using UniversityProject.Interfaces;

namespace UniversityProject.Scenes
{
	public class GameScene
	{
		public List<IGameObjects> GameObjects = new List<IGameObjects>();
		public Scene Scene;

		public GameScene()
		{
			Utilits.Scenes.Add(this);
		}
	}
}
