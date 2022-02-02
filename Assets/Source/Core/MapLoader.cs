using DungeonCrawl.Actors.Characters;
using DungeonCrawl.Actors.Items;
using DungeonCrawl.Actors.Static;
using System;
using System.Text.RegularExpressions;
using UnityEngine;

namespace DungeonCrawl.Core
{
    /// <summary>
    ///     MapLoader is used for constructing maps from txt files
    /// </summary>
    public static class MapLoader
    {
        public static GameManager GameManager
        {
            get => default;
            set
            {
            }
        }

        public static CameraController CameraController
        {
            get => default;
            set
            {
            }
        }

        public static ActorManager ActorManager
        {
            get => default;
            set
            {
            }
        }

        /// <summary>
        ///     Constructs map from txt file and spawns actors at appropriate positions
        /// </summary>
        /// <param name="id"></param>
        public static void LoadMap(int id)
        {
            var lines = Regex.Split(Resources.Load<TextAsset>($"map_{id}").text, "\r\n|\r|\n");

            // Read map size from the first line
            var split = lines[0].Split(' ');
            var width = int.Parse(split[0]);
            var height = int.Parse(split[1]);

            // Create actors
            for (var y = 0; y < height; y++)
            {
                var line = lines[y + 1];
                for (var x = 0; x < width; x++)
                {
                    var character = line[x];

                    SpawnActor(character, (x, -y));
                }
            }

            // Set default camera size and position
            CameraController.Singleton.Size = 10;
            CameraController.Singleton.Position = (width / 2, -height / 2);
        }

        private static void SpawnActor(char c, (int x, int y) position)
        {
            switch (c)
            {
                case '#':
                    ActorManager.Singleton.Spawn<Wall>(position);
                    break;
                case '.':
                    ActorManager.Singleton.Spawn<Floor>(position);
                    break;
                case 'p':
                    ActorManager.Singleton.Spawn<Player>(position);
                    ActorManager.Singleton.Spawn<Floor>(position);
                    break;
                case 's':
                    ActorManager.Singleton.Spawn<Skeleton>(position);
                    ActorManager.Singleton.Spawn<Floor>(position);
                    break;
                case 'D':
                    ActorManager.Singleton.Spawn<Door>(position);
                    break;
                case 'b':
                    ActorManager.Singleton.Spawn<Brute>(position);
                    ActorManager.Singleton.Spawn<Floor>(position);
                    break;
                case ' ':
                    break;
                case 'k':
                    ActorManager.Singleton.Spawn<Floor>(position);
                    ActorManager.Singleton.Spawn<Key>(position);
                    break;
                case 'w':
                    ActorManager.Singleton.Spawn<Floor>(position);
                    ActorManager.Singleton.Spawn<Sword>(position);
                    break;
                case 'H':
                    ActorManager.Singleton.Spawn<WallSpecialHidden>(position);
                    break;
                case 'E':
                    ActorManager.Singleton.Spawn<FloorHidden>(position);
                    break;
                case 'Z':
                    ActorManager.Singleton.Spawn<WallSpecial>(position);
                    break;
                case 'S':
                    ActorManager.Singleton.Spawn<Floor>(position);
                    ActorManager.Singleton.Spawn<Shield>(position);
                    break;
                case 't':
                    ActorManager.Singleton.Spawn<Floor>(position);
                    ActorManager.Singleton.Spawn<Candlesticks>(position);
                    break;
                case '+':
                    ActorManager.Singleton.Spawn<SmallHealth>(position);
                    break;
                case 'B':
                    ActorManager.Singleton.Spawn<BigHealth>(position);
                    break;
                default:
                    throw new ArgumentOutOfRangeException();
            }
        }
    }
}
