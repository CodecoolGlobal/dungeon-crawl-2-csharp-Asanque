using DungeonCrawl.Actors.Characters;
using DungeonCrawl.Actors.Items;
using DungeonCrawl.Actors.Static;
using System;
using System.Text.RegularExpressions;
using UnityEngine;
using Assets.Source.Actors;

namespace DungeonCrawl.Core
{
    /// <summary>
    ///     MapLoader is used for constructing maps from txt files
    /// </summary>
    public static class MapLoader
    {
        private const int DefId = -5;
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
            Sprites.SetSprites(id);

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
                    ActorManager.Singleton.Spawn<Wall>(position, Sprites.wallId);
                    break;
                case '.':
                    ActorManager.Singleton.Spawn<Floor>(position, Sprites.floorId);
                    break;
                case 'p':
                    ActorManager.Singleton.Spawn<Player>(position);
                    ActorManager.Singleton.Spawn<Floor>(position, Sprites.floorId);
                    break;
                case 's':
                    ActorManager.Singleton.Spawn<Skeleton>(position);
                    ActorManager.Singleton.Spawn<Floor>(position, Sprites.floorId);
                    break;
                case 'D':
                    ActorManager.Singleton.Spawn<Door>(position, Sprites.doorId);
                    break;
                case 'b':
                    ActorManager.Singleton.Spawn<Brute>(position);
                    ActorManager.Singleton.Spawn<Floor>(position, Sprites.floorId);
                    break;
                case ' ':
                    break;
                case 'k':
                    ActorManager.Singleton.Spawn<Floor>(position, Sprites.floorId);
                    ActorManager.Singleton.Spawn<Key>(position);
                    break;
                case 'w':
                    ActorManager.Singleton.Spawn<Floor>(position, Sprites.floorId);
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
                    ActorManager.Singleton.Spawn<Floor>(position, Sprites.floorId);
                    ActorManager.Singleton.Spawn<Shield>(position);
                    break;
                case 't':
                    ActorManager.Singleton.Spawn<Floor>(position, Sprites.floorId);
                    ActorManager.Singleton.Spawn<Candlesticks>(position);
                    break;
                case 'l':
                    ActorManager.Singleton.Spawn<Floor>(position, Sprites.floorId);
                    ActorManager.Singleton.Spawn<Floor>(position, Sprites.logId);
                    break;
                case 'L':
                    ActorManager.Singleton.Spawn<Wall>(position, Sprites.lakeId);
                    break;
                case 'I':
                    ActorManager.Singleton.Spawn<Wall>(position, Sprites.treeTrunkId);
                    ActorManager.Singleton.Spawn<Floor>(position, Sprites.floorId);
                    break;
                case 'T':
                    ActorManager.Singleton.Spawn<Floor>(position, Sprites.floorId);
                    ActorManager.Singleton.Spawn<Wall>(position, Sprites.treeLeavesId);
                    break;
                case 'P':
                    ActorManager.Singleton.Spawn<Floor>(position, Sprites.lakeId);
                    ActorManager.Singleton.Spawn<Door>(position, Sprites.boatId);
                    break;
                case 'c':
                    ActorManager.Singleton.Spawn<Floor>(position, Sprites.floorId);
                    ActorManager.Singleton.Spawn<Decoration>(position, Sprites.campfireId);
                    break;
                case '+':
                    ActorManager.Singleton.Spawn<Floor>(position, Sprites.floorId);
                    ActorManager.Singleton.Spawn<SmallHealth>(position);
                    break;
                case 'B':
                    ActorManager.Singleton.Spawn<Floor>(position, Sprites.floorId);
                    ActorManager.Singleton.Spawn<BigHealth>(position);
                    break;
                case 'g':
                    ActorManager.Singleton.Spawn<Floor>(position, Sprites.floorId);
                    ActorManager.Singleton.Spawn<Demon>(position);
                    break;
                default:
                    throw new ArgumentOutOfRangeException();
            }
        }
    }
}
