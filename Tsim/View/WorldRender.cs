using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;
using MonoGameLibrary.Graphics;
using Tsim.Backend;

namespace Tsim.View
{
    public class WorldRender : Drawable
    {
        private Sprite[,] Map;
        public WorldRender(World world, TextureAtlas atlas)
        {
            int Width = world.Width;
            int Height = world.Height;
            Map = new Sprite[Width, Height];
            for (int i = 0; i < Width; i++)
            {
                for (int j = 0; j < Height; j++)
                {
                    String TileName = world.Map[i, j].Name;
                    Map[i, j] = atlas.CreateSprite(TileName);
                }
            } 
        }

        public void Draw(SpriteBatch spriteBatch, Vector2 offset)
        {
            int TileSize = 128;
            float Scale = TileSize / 32;
            for (int i = 0; i < Map.GetLength(0); i++)
            {
                for (int j = 0; j < Map.GetLength(1); j++)
                {
                    Vector2 Position = new Vector2(i * TileSize, j * TileSize);
                    Map[i, j].Draw(spriteBatch, Position + offset);
                    Map[i, j].Scale = new Vector2(Scale);
                } 
            }
        }
    }
}