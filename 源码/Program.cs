using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace _2048Consolo
{
    class Program
    {
        static void Main(string[] args)
        {
            GameCore gc = new GameCore();
            int[,] map = gc.Map;
            gc.RandomCreatNumber();
            gc.RandomCreatNumber();
            while (true)
            {
                DrawMap(map);
                int key = (int)Console.ReadKey().Key;
                Move(gc,key);
                if (CheckIsWin(map))
                {
                    Console.WriteLine("游戏胜利！");
                    break;
                }
                if (CheckIsLose(map))
                {
                    Console.WriteLine("败北！");
                    break;
                }
                Console.Clear();
            }

        }
        private static void DrawMap(int[,]map)
        {
            for (int i = 0; i < map.GetLength(0); i++)
            {
                for (int j = 0; j < map.GetLength(1); j++)
                {
                    Console.Write(map[i, j] + "\t");
                }
                Console.WriteLine();
            }
        }
        private static bool CheckIsWin(int[,]map)
        {
            for (int i = 0; i < map.GetLength(0); i++)
            {
                for (int j = 0; j < map.GetLength(1); j++)
                {
                    if (map[i, j] == 2048)
                    {
                        return true;
                    }
                    else
                    {
                        return false;
                    }
                }
            }
            return false;
        }
        private static bool CheckIsLose(int[,]map)
        {
            bool isLose = true;
            for (int r = 0; r < map.GetLength(0); r++)
            {
                for (int c = 0; c < map.GetLength(1); c++)
                {
                    if (map[r, c] == 0)
                    {
                        isLose = false;
                        return isLose;
                    }
                }
            }
            return isLose;
        }
        private static void Move(GameCore gc,int key)
        {
            if (key == (int)ConsoleKey.UpArrow)
            {
                gc.Move(MoveDirection.Up);
            }
            else if (key == (int)ConsoleKey.DownArrow)
            {
                gc.Move(MoveDirection.Down);
            }
            else if (key == (int)ConsoleKey.LeftArrow)
            {
                gc.Move(MoveDirection.Left);
            }
            else if (key == (int)ConsoleKey.RightArrow)
            {
                gc.Move(MoveDirection.Right);
            }
        }
    }
}
