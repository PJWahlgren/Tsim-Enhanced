using System.Dynamic;
using Tsim.Backend;

public class World
{
    
    public Tile[,] Map { get; private set; }

    public int Width => Map.GetLength(0);
    public int Height => Map.GetLength(1);
    /// <summary>
    /// Creates a world with 16x16 tiles
    /// <code>
    /// World world = new World();
    /// </code>
    /// </summary>
    public World()
    {
        Map = new Tile[16, 16];
    }
    /// <summary>
    /// Creates a nxn sized world
    /// </summary>
    /// <param name="Width">The dimension width and height of the world</param>
    public World(int Width)
    {
        Map = new Tile[Width, Width];
        for (int x = 0; x < Width; x++)
        {
            for (int y = 0; y < Width; y++)
            {
                Map[x, y] = new Tile();
            }
        }
    }
    public World(int Width, int Height)
    {
        Map = new Tile[Width, Height];
    }
}