using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AdventureGame.Core
{
    /// <summary>
    /// creates a new maze for the adventure game with 
    /// items, monsters, and the player all being obligated to be in the maze. 
    /// The maze has a randomly generated layout.
    /// </summary>
    public class Maze
    {
        public int Width { get; set; }

        public int Height { get; set; }

        /// <summary>
        /// tracks the visited tiles 
        /// </summary>
        public bool[,] visited;

        /// <summary>
        /// set the grid for the maze
        /// </summary>
        public char[,] grid;

        /// <summary>
        /// creates the ability doe the player to move in the maze
        /// </summary>
        public static readonly (int x, int y)[] Directions = new (int, int)[]
        {
            (0, 1), // right
            (1, 0), // down
            (0, -1), // left
            (-1, 0) // up
        };

        /// <summary>
        /// generates a random maze layout starting from the top-left corner (0, 0)
        /// </summary>
        public Random random = new Random();

        /// <summary>
        /// creates a dictionary for the items that will appear in the maze
        /// </summary>
        public Dictionary<(int x, int y), Item> Items = new();

        /// <summary>
        /// ditto items 
        /// </summary>
        public Dictionary<(int x, int y), Monster> Monsters = new();

        /// <summary>
        /// creates a new maze with the specified width and height, and generates a random layout for the maze
        /// </summary>
        /// <param name="width"></param>
        /// <param name="height"></param>
        public Maze(int width, int height)
        {
            Width = width;
            Height = height;
            visited = new bool[width, height];
            grid = new char[width, height];
            InitializeGrid();
            GenerateMaze(0, 0);
            SetEndTile();
        }

        /// <summary>
        /// defines the walls of the maze
        /// </summary>
        public void InitializeGrid()
        {
            for (int x = 0; x < Width; x++)
            {
                for (int y = 0; y < Height; y++)
                {
                    grid[x, y] = '#'; // wall
                }
            }
        }

        /// <summary>
        /// generates a maze using from the InitializeGrid method
        /// </summary>
        /// <param name="x">x cord of the starting postion of generation</param>
        /// <param name="y">y cord of the starting position of generation</param>
        public void GenerateMaze(int x, int y)
        {
            visited[x, y] = true;
            grid[x, y] = '.'; // path
            var directions = Directions.OrderBy(_ => random.Next()).ToArray();
            foreach (var (dx, dy) in directions)
            {
                int newX = x + dx;
                int newY = y + dy;
                GenerateMaze(newX, newY);
            }
        }

        /// <summary>
        /// creates the end tile (escape) for the maze
        /// </summary>
        public void SetEndTile()
        {
            grid[Width - 1, Height - 1] = 'E'; // end tile
        }

        /// <summary>
        /// creates the items's only positions in the maze
        /// </summary>
        /// <param name="playerX">the items's positioning x cord</param>
        /// <param name="playerY">the items's positioning y cord</param>
        public void PlaceItems(int itemX, int itemY)
        {
            for (int y = 0; y < Height; y++)
            {
                for (int x = 0; x < Width; x++)
                {
                    if (x == itemX && y == itemY)
                    {
                        Console.Write('I'); // item
                    }
                    else
                    {
                        Console.Write(grid[x, y]);
                    }
                }
                Console.WriteLine();
            }
        }

        /// <summary>
        /// creates the monster's only position in the maze
        /// </summary>
        /// <param name="playerX">the monster's positioning x cord</param>
        /// <param name="playerY">the monster's positioning y cord</param>
        public void PlaceMonster(int monsterX, int monsterY)
        {
            for (int y = 0; y < Height; y++)
            {
                for (int x = 0; x < Width; x++)
                {
                    if (x == monsterX && y == monsterY)
                    {
                        Console.Write('M'); // monster
                    }
                    else
                    {
                        Console.Write(grid[x, y]);
                    }
                }
                Console.WriteLine();
            }
        }

        /// <summary>
        /// creates the player's intitial position in the maze
        /// </summary>
        /// <param name="playerX">the player's starting x cord</param>
        /// <param name="playerY">the player's starting y cord</param>
        public void PrintPlayer(int playerX, int playerY)
        {
            for (int y = 0; y < Height; y++)
            {
                for (int x = 0; x < Width; x++)
                {
                    if (x == playerX && y == playerY)
                    {
                        Console.Write('P'); // player
                    }
                    else
                    {
                        Console.Write(grid[x, y]);
                    }
                }
                Console.WriteLine();
            }
        } 

        /// <summary>
        /// checks if the tile that the player is trying to move to is walkable (not a wall)
        /// </summary>
        /// <param name="x">the checked x cord</param>
        /// <param name="y">the checked y cord</param>
        /// <returns>a moveable place in the maze</returns>
        public bool IsWalkable(int x, int y)
        {
            return grid[x, y] == '.' || grid[x, y] == 'E';
        }
    }
}
