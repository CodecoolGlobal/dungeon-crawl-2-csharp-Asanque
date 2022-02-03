using DungeonCrawl.Actors.Characters;
using DungeonCrawl.Actors.Items;
using DungeonCrawl.Actors.Static;
using System;
using System.Text.RegularExpressions;
using UnityEngine;
using Assets.Source.Actors;
using Assets.Source.Core;

namespace DungeonCrawl.Core
{
    /// <summary>
    ///     MapLoader is used for constructing maps from txt files
    /// </summary>
    public static class MapLoader
    {
        private static int NewGameCount = -1;
        private static int MapId = 1;
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
        public static void LoadMap()
        {
            if (MapId == 1)
            {
                NewGameCount++;
            }

            var lines = Regex.Split(Resources.Load<TextAsset>($"map_{MapId}").text, "\r\n|\r|\n");
            Sprites.SetSprites(MapId);

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
            MapId++;
            if (MapId is 4)
            {
                MapId = 1;
            }
            if (NewGameCount > 0)
            {
                UserInterface.Singleton.PrintNewGameText(NewGameCount);
            }
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
                case 'r':
                    ActorManager.Singleton.Spawn<Floor>(position, Sprites.road);
                    break;
                case '@':
                    ActorManager.Singleton.Spawn<Floor>(position, Sprites.bridgeUp);
                    break;
                case '!':
                    ActorManager.Singleton.Spawn<Floor>(position, Sprites.river);
                    ActorManager.Singleton.Spawn<Floor>(position, Sprites.bridgeStraight);
                    break;
                case '$':
                    ActorManager.Singleton.Spawn<Floor>(position, Sprites.bridgeDown);
                    break;
                case '_':
                    ActorManager.Singleton.Spawn<Wall>(position, Sprites.smallHouse);
                    break;
                case '%':
                    ActorManager.Singleton.Spawn<Wall>(position, Sprites.houseRoofUp);
                    break;
                case '^':
                    ActorManager.Singleton.Spawn<Wall>(position, Sprites.houseRoofStraight);
                    break;
                case '&':
                    ActorManager.Singleton.Spawn<Wall>(position, Sprites.houseRoofDown);
                    break;
                case '*':
                    ActorManager.Singleton.Spawn<Wall>(position, Sprites.houseWall);
                    break;
                case '~':
                    ActorManager.Singleton.Spawn<Wall>(position, Sprites.houseDoor);
                    break;
                case 'F':
                    ActorManager.Singleton.Spawn<Wall>(position, Sprites.flag);
                    break;
                case 'p':
                    ActorManager.Singleton.Spawn<Player>(position);
                    ActorManager.Singleton.Spawn<Floor>(position, Sprites.floorId);
                    break;
                case 's':
                    ActorManager.Singleton.Spawn<Skeleton>(position);
                    ActorManager.Singleton.Spawn<Floor>(position, Sprites.floorId);
                    break;
                case 'd':
                    ActorManager.Singleton.Spawn<Door>(position, Sprites.doorId);
                    break;
                case 'D':
                    ActorManager.Singleton.Spawn<DoorSpecial>(position, Sprites.doorId);
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
                case 'K':
                    ActorManager.Singleton.Spawn<Floor>(position, Sprites.floorId);
                    ActorManager.Singleton.Spawn<KeySpecial>(position);
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
                case 'R':
                    ActorManager.Singleton.Spawn<Wall>(position, Sprites.river);
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
                    ActorManager.Singleton.Spawn<DoorSpecial>(position, Sprites.boatId);
                    ActorManager.Singleton.Spawn<Floor>(position, Sprites.lakeId);
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
