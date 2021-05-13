using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Content;
using Microsoft.Xna.Framework.Graphics;
using System;
using System.Collections.Generic;
using System.IO;
using System.Text;
using System.Threading.Tasks;
using UniversityProject.Interfaces;
using UniversityProject.Scenes;
using UniversityProject.server;

namespace UniversityProject
{
    public enum Scene
	{
        Menu, Game
	}
    class Utilits
    {
        public static List<GameSceneObject> Scenes = new List<GameSceneObject>();
        public static Scene CurrentScene = Scene.Menu;
        public static ContentManager Content;
        public static SpriteBatch SpriteBatch;
        public static GameTime GameTime;
        public static GraphicsDevice GraphicsDevice;
        public static Point ScreenSize;
        public static Dictionary<string, string> Settings = new Dictionary<string, string>();
        public static Texture2D GetTexture(Color color)
		{
            if (Utilits.GraphicsDevice != null)
			{
                Color[] data = new Color[1] { color };
                Texture2D temp = new Texture2D(Utilits.GraphicsDevice, 1, 1);
                temp.SetData(data);
                return temp;
            }
            return null;
        }
        public static string GetSetting(string key)
		{
            return Settings[key];
		}
        public static void SetSetting(string key, string value)
		{
            Settings[key] = value;
		}
        public static void AddSetting(string key, string value)
        {
            Settings.Add(key, value);
        }
        public static void ApplySettings()
		{
            string temp = "";
            foreach (var item in Settings)
            {
                temp += $"{item.Key}:{item.Value}\n";
			}
            temp.Remove(temp.Length - 1);
            File.WriteAllText(@".\settings", temp);
        }
        public static async void Connect(string name, string ip, int port)
        {
            await Task.Run(() => Client.Connect(name, ip, port));
        }
    }
}
