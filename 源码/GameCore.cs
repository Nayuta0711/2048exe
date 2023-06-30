using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace _2048Consolo
{
    class GameCore
    {
        int[,] map;
        int[] tempArray;
        public int[,] Map
        {
            get
            {
                return map;
            }
        }
        List<Location> emptyLocations;
        Random rm;
        public GameCore()
        {
            map = new int[4, 4];
            tempArray = new int[4];
            emptyLocations = new List<Location>(16);
            rm = new Random();
        }
        public void Move(MoveDirection direction)
        {
            switch (direction)
            {
                case MoveDirection.Up:
                    UpMove();
                    break;
                case MoveDirection.Down:
                    DownMove();
                    break;
                case MoveDirection.Left:
                    LeftMove();
                    break;
                case MoveDirection.Right:
                    RightMove();
                    break;
            }
        }
        private void RightMove()
        {
            Array.Clear(tempArray, 0, 4);
            for (int c = 0; c < map.GetLength(1); c++)
            {
                for (int i = 0; i < map.GetLength(0); i++)
                {
                    tempArray[i] = map[c, map.GetLength(1) - 1 - i];
                }
                CombineData(tempArray);
                for (int i = 0; i < map.GetLength(0); i++)
                {
                    map[c, map.GetLength(1) - 1 - i] = tempArray[i];
                }
            }
            RandomCreatNumber();
        }
        private void LeftMove()
        {
            Array.Clear(tempArray, 0, 4);
            for (int c = 0; c < map.GetLength(1); c++)
            {
                for (int i = 0; i < map.GetLength(0); i++)
                {
                    tempArray[i] = map[c, i];
                }
                CombineData(tempArray);
                for (int i = 0; i < map.GetLength(0); i++)
                {
                    map[c, i] = tempArray[i];
                }
            }
            RandomCreatNumber();
        }
        private void DownMove()
        {
            Array.Clear(tempArray, 0, 4);
            for (int c = 0; c < map.GetLength(1); c++)
            {
                for (int i = 0; i < map.GetLength(0); i++)
                {
                    tempArray[i] = map[map.GetLength(0) - 1 - i, c];
                }         
                CombineData(tempArray);
                for (int i = 0; i < map.GetLength(0); i++)
                {
                    map[map.GetLength(0) - 1 - i, c] = tempArray[i];
                }
            }
            RandomCreatNumber();
        }

        private void UpMove()
        {
            Array.Clear(tempArray, 0, 4);
            for (int c = 0; c < map.GetLength(1); c++)
            {
                for (int i = 0; i < map.GetLength(0); i++)
                {
                    tempArray[i] = map[i, c];
                }
                CombineData(tempArray);
                for (int i = 0; i < map.GetLength(0); i++)
                {
                    map[i, c] = tempArray[i];
                }
            }
            RandomCreatNumber();
        }

        private void CombineData(int[] tempArray)
        {
            RemoveZero(tempArray);
            for (int i = 0; i < tempArray.Length - 1; i++)
            {
                if (tempArray[i] != 0 && tempArray[i] == tempArray[i + 1])
                {
                    tempArray[i] += tempArray[i + 1];
                    tempArray[i + 1] = 0;
                }
            }
            RemoveZero(tempArray);
        }

        private void RemoveZero(int[] tempArray)
        {
            for (int i = 0; i < tempArray.Length; i++)
            {
                if (tempArray[i] == 0 && i != tempArray.Length - 1)
                {
                    for (int j = i + 1; j < tempArray.Length; j++)
                    {
                        if (tempArray[j] != 0)
                        {
                            tempArray[i] = tempArray[j];
                            tempArray[j] = 0;
                            break;
                        }
                    }
                }
            }
        }
        private void CalculateEmpty()
        {
            emptyLocations.Clear();
            for (int r = 0; r < map.GetLength(0); r++)
            {
                for (int c = 0; c < map.GetLength(1); c++)
                {
                    if (map[r, c] == 0)
                    {
                        emptyLocations.Add(new Location(r, c));
                    }
                }
            }
        }
        public void RandomCreatNumber()
        {
            CalculateEmpty();
            if (emptyLocations.Count > 0)
            {
                int index = rm.Next(0, emptyLocations.Count);
                Location loc = emptyLocations[index];
                map[loc.Rindex, loc.Cindex] = rm.Next(0, 10) == 1 ? 4 : 2;
            }
        }
    }
}
