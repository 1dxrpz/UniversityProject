﻿using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;
using System;
using System.Collections.Generic;
using System.IO;
using System.Text;

namespace UniversityProject
{
    class TileMap
    {
        public Vector2 Size = new Vector2(64, 64);
        public Texture2D Texture;
        public int Width = 60;
        public int Height = 33;
        public Vector2 TileSize = new Vector2(16, 16);


        Dictionary<char, Vector2> tileDictionary = new Dictionary<char, Vector2>();
        public char[,] tiles;

        public TileMap()
        {
            tiles = new char[Width, Height];
            tileDictionary.Add(' ', new Vector2(-1, -1));
            for (int y = 0; y < Height; y++)
            {
                for (int x = 0; x < Width; x++)
                {
                    tiles[x, y] = ' ';
                }
            }
        }

        public void AddTile(char i, Vector2 pos)
        {
            tileDictionary.Add(i, pos);

        }
        public void SetTiles(char i, Vector2 pos)
        {
            tiles[(int)pos.X, (int)pos.Y] = i;
        }

        public void Draw()
        {
            for (int y = 0; y < Height; y++)
            {
                for (int x = 0; x < Width; x++)
                {
                    if (tiles[x, y] != ' ')
                    {
                        Utilits.SpriteBatch.Draw(Texture,
                            new Rectangle(Vector2.Multiply(new Vector2(x, y), Size).ToPoint(), Size.ToPoint()),
                            new Rectangle(Vector2.Multiply(tileDictionary[tiles[x, y]], TileSize).ToPoint(), TileSize.ToPoint()), Color.White); ;
                    }
                }
            }
        }
    }
}
