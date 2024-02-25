using System;
using System.IO;

namespace ex_7
{
    internal class Program
    {
        private static bool isGameContinues = true;

        private static int playerVert;
        private static int playerHorz;
        private static int playerHitPoint;
        static char[,] map;
        static char[,] map_path;
        static int[,] enemies;
        private static bool isPathShow = false;

        static char[,] ReadMap(string path)
        {
            playerVert = 0;
            playerHorz = 0;

            string[] newFile = File.ReadAllLines(path);
            char[,] newMap = new char[newFile.Length, newFile[0].Length];

            for (int i = 0; i < newMap.GetLength(0); i++)
            {
                for (int j = 0; j < newMap.GetLength(1); j++)
                {
                    newMap[i, j] = newFile[i][j];

                    if (newMap[i, j] == '■')
                    {
                        playerVert = i;
                        playerHorz = j;
                    }
                }
            }

            return newMap;
        }

        private static void DrawMap()
        {
            var mapToDraw = isPathShow ? map_path : map;
            for (var i = 0; i < mapToDraw.GetLength(0); i++)
            {
                for (var j = 0; j < mapToDraw.GetLength(1); j++)
                {
                    Console.Write(mapToDraw[i, j]);
                }
                Console.WriteLine();
            }
        }

        private static void MovePlayer()
        {
            Console.SetCursorPosition(40, 0);
            Console.WriteLine("Сделайте ход!");
            Console.SetCursorPosition(40, 1);
            Console.WriteLine(" 1. Для выбора стороны используйте WASD");
            Console.SetCursorPosition(40, 2);
            Console.WriteLine(" 2. Для просмотра карты решения используйте F1");
            var key = Console.ReadKey(true).Key;
            if (key == ConsoleKey.W && 
                map[playerVert - 1, playerHorz] == ' ')
            {
                map[playerVert, playerHorz] = ' ';
                map[--playerVert, playerHorz] = '■';
            }
            else if (key == ConsoleKey.A &&
                     map[playerVert, playerHorz - 1] == ' ')
            {
                map[playerVert, playerHorz] = ' ';
                map[playerVert, --playerHorz] = '■';
            }
            else if (key == ConsoleKey.S &&
                     map[playerVert + 1, playerHorz] == ' ')
            {
                map[playerVert, playerHorz] = ' ';
                map[++playerVert, playerHorz] = '■';
            }
            else if (key == ConsoleKey.D &&
                     map[playerVert, playerHorz + 1] == ' ')
            {
                map[playerVert, playerHorz] = ' ';
                map[playerVert, ++playerHorz] = '■';
            }
            else if (key == ConsoleKey.W && 
                     map[playerVert - 1, playerHorz] == '*')
            {
                map[playerVert, playerHorz] = ' ';
                map[--playerVert, playerHorz] = '■';
                playerHitPoint -= 1;
            }
            else if (key == ConsoleKey.A && 
                     map[playerVert, playerHorz - 1] == '*')
            {
                map[playerVert, playerHorz] = ' ';
                map[playerVert, --playerHorz] = '■';
                playerHitPoint -= 1;
            }
            else if (key == ConsoleKey.S &&
                     map[playerVert + 1, playerHorz] == '*')
            {
                map[playerVert, playerHorz] = ' ';
                map[++playerVert, playerHorz] = '■';
                playerHitPoint -= 1;
            }
            else if (key == ConsoleKey.D &&
                     map[playerVert, playerHorz + 1] == '*')
            {
                map[playerVert, playerHorz] = ' ';
                map[playerVert, ++playerHorz] = '■';
                playerHitPoint -= 1;
            }

            if (key == ConsoleKey.F1)
                isPathShow = !isPathShow;

            if (playerHitPoint <= 0)
            {
                isGameContinues = false;
            }
        }

        private static void MoveEnemies()
        {
            Random rnd = new Random();

            for (int i = 0; i < enemies.GetLength(0); i++)
            {
                int x = enemies[i, 0];
                int y = enemies[i, 1];

                int[,] dims = { { x - 1, y }, { x, y - 1 },
                                { x + 1, y }, { x, y + 1 } };

                int count = 4;
                int curr = rnd.Next(0, 4);
                while (map[dims[curr, 0], dims[curr, 1]] != ' '
                       && count > 0)
                {
                    curr = rnd.Next(0, 4);
                    count--;
                }

                if (count != 0)
                {
                    if (map[x, y] != '■')
                        map[x, y] = ' ';
                    map[dims[curr, 0], dims[curr, 1]] = '*';
                    enemies[i, 0] = dims[curr, 0];
                    enemies[i, 1] = dims[curr, 1];
                }
            }
        }

        private static void DrawBar()
        {
            Console.SetCursorPosition(40, 5);
            Console.WriteLine("Оставшееся хп игрока:");
            Console.SetCursorPosition(40, 6);
            Console.Write("  [");
            for (int i = 0; i < playerHitPoint; i++)
            {
                Console.Write("#");
            }

            for (int i = 10 - playerHitPoint; i > 0; i--)
            {
                Console.Write("_");
            }
            Console.Write("]");
        }

        private static void AddEnemies()
        {
            int enemiesCount = 20;
            enemies = new int[enemiesCount, 2];
            
            Random rnd = new Random();
            for (int i = 0; i < enemiesCount; i++)
            {
                int Horz = rnd.Next(2, map.GetLength(0) - 1);
                int Vert = rnd.Next(2, (map.GetLength(1) - 4));
                while (map[Vert, Horz] != ' ')
                {
                    Horz = rnd.Next(2, map.GetLength(0) - 1);
                    Vert = rnd.Next(2, (map.GetLength(1) - 4));
                }

                enemies[i, 0] = Vert;
                enemies[i, 1] = Horz;

                map[Vert, Horz] = '*';
            }
        }

        private static void init()
        {
            var mapName = "map";
            map_path = ReadMap($"maps/{mapName}_path.txt");
            map = ReadMap($"maps/{mapName}.txt");
            AddEnemies();
            playerHitPoint = 10;
        }

        private static void Main(string[] args)
        {
            init();

            Console.SetWindowPosition(0, 0);
            
            while (isGameContinues)
            {
                DrawMap();
                DrawBar();
                MovePlayer();
                MoveEnemies();
                Console.SetCursorPosition(0, 0);
            }
            Console.Clear();
            Console.WriteLine("Игра Завершилась!");
        }
    }
}
