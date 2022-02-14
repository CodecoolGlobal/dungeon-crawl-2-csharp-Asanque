using System;
using System.Collections.Generic;
using DungeonCrawl.Actors.Characters;
using DungeonCrawl.Core;

namespace DungeonCrawl
{
    public enum Direction : byte
    {
        Up,
        Down,
        Left,
        Right
    }

    public static class Utilities
    {

        public static List<Type> EnemyTypes= new List<Type> { typeof(Brute), typeof(Skeleton), typeof(Demon)};
        
        public static List<int[]> Directions = new List<int[]> 
        { new int[] { 0, 1 }, new int[] {0, -1}, new int[] {-1, 0 }, new int[] {1, 0} };

        public static int countMultiplier()
        {
            if (MapLoader.NewGameCount > 1)
            {
                // return (int)((int)Math.Abs(MapLoader.NewGameCount) * 0.1 + 1);
                return (int)((int)MapLoader.NewGameCount * 1.1);
            }
            return 1;
    }
        public static Actors.Actor Actor
        {
            get => default;
            set
            {
            }
        }

        public static Direction Direction
        {
            get => default;
            set
            {
            }
        }

        public static (int x, int y) ToVector(this Direction dir)
        {
            switch (dir)
            {
                case Direction.Up:
                    return (0, 1);
                case Direction.Down:
                    return (0, -1);
                case Direction.Left:
                    return (-1, 0);
                case Direction.Right:
                    return (1, 0);
                default:
                    throw new ArgumentOutOfRangeException(nameof(dir), dir, null);
            }
        }
    }
}
