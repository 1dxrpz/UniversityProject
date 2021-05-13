using System;
using System.Collections.Generic;
using System.Text;
using UniversityProject.Interfaces;

namespace UniversityProject.Scenes
{
	public class GameSceneObject
	{
		public List<IGameObjects> GameObjects = new List<IGameObjects>();
		public Scene Scene;

		public GameSceneObject()
		{
			Utilits.Scenes.Add(this);
		}
	}
}
