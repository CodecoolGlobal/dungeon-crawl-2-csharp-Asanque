﻿using System;
using System.Collections.Generic;
using DungeonCrawl.Actors.Characters;

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
        public static List<int[]> Directions = new List<int[]> 
        { new int[] { 0, 1 }, new int[] {0, -1}, new int[] {-1, 0 }, new int[] {1, 0} };

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
