using System;
using System.Collections.Generic;
using Newtonsoft.Json;
using DungeonCrawl.Core;
using DungeonCrawl.Actors.Characters;
using System.IO;
using DungeonCrawl.Actors.Items;
using DungeonCrawl.Actors.Static;
using System.Text;
using DungeonCrawl.Actors;

namespace Assets.Source.Core
{
    public static class SaveManager
    {
        public static void WriteToJson()
        {
            try
            {
                var savedActors = CollectActors();
                JsonSerializer serializer = new JsonSerializer();
                using StreamWriter saveLocation = new StreamWriter(@"SaveFile.json");
                using JsonWriter writer = new JsonTextWriter(saveLocation);
                serializer.Formatting = Formatting.Indented;
                serializer.Serialize(writer, savedActors);
            }
            catch (Exception ex)
            {
                UserInterface.Singleton.PrintException(ex);
            }
        }

        private static List<Dictionary<string, string>> CollectActors()
        {
            List<Dictionary<string, string>> savedActors = new List<Dictionary<string, string>>();
            Dictionary<string, string> gameInfo = new Dictionary<string, string>()
            { {"newGameCount", MapLoader.NewGameCount.ToString()},  {"mapId", GetMapId().ToString()}, {"type", "gameInfo"} };
            savedActors.Add(gameInfo);
            foreach (var actor in ActorManager.Singleton.AllActors)
            {
                if (actor is Character || actor is Door || actor is Item)
                {
                    Dictionary<string, string> currentActor = new Dictionary<string, string>();
                    if (actor is Player player)
                    {
                        currentActor["inventory"] = JsonConvert.SerializeObject(player.Inventory);
                        currentActor["maxHealth"] = player.MaxHealth.ToString();
                        currentActor["expNeeded"] = player.ExpNeeded.ToString();
                        currentActor["shield"] = player.Shield.ToString();
                    }

                    if (actor is Character character)
                    {
                        currentActor["expCount"] = character.ExpCount.ToString();
                        currentActor["health"] = character.Health.ToString();
                        currentActor["strength"] = character.Strength.ToString();
                    }
                    else if (actor is Door door)
                    {
                        currentActor["isOpen"] = door.IsOpen.ToString();
                    }

                    currentActor["type"] = actor.GetType().ToString();
                    currentActor["coordX"] = actor.Position.x.ToString();
                    currentActor["coordY"] = actor.Position.y.ToString();
                    savedActors.Add(currentActor);
                }
            }
            return savedActors;
        }

        public static List<Dictionary<string, string>> ReadJson()
        {
            StringBuilder resultBuilder = new StringBuilder();
            StreamReader reader = new StreamReader(@"SaveFile.json");

            string strCurrentLine;
            while ((strCurrentLine = reader.ReadLine()) != null)
            {
                resultBuilder.Append($"{strCurrentLine}\n");
            }

            var readSave = JsonConvert.DeserializeObject<List<Dictionary<string, string>>>(resultBuilder.ToString());
            return readSave;
        }
        public static void Save()
        {
            WriteToJson();
        }

        public static void SpawnActors(List<Dictionary<string, string>> readSave)
        {
            foreach (var actor in readSave)
            {
                switch (actor["type"])
                {
                    case "DungeonCrawl.Actors.Characters.Skeleton":
                        ActorManager.Singleton.Spawn<Skeleton>((Convert.ToInt32(actor["coordX"]), Convert.ToInt32(actor["coordY"])));
                        break;
                    case "DungeonCrawl.Actors.Characters.Brute":
                        ActorManager.Singleton.Spawn<Brute>((Convert.ToInt32(actor["coordX"]), Convert.ToInt32(actor["coordY"])));
                        break;
                    case "DungeonCrawl.Actors.Characters.Demon":
                        ActorManager.Singleton.Spawn<Demon>((Convert.ToInt32(actor["coordX"]), Convert.ToInt32(actor["coordY"])));
                        break;
                    case "DungeonCrawl.Actors.Characters.Player":
                        ActorManager.Singleton.Spawn<Player>((Convert.ToInt32(actor["coordX"]), Convert.ToInt32(actor["coordY"])));
                        break;
                    case "DungeonCrawl.Actors.Characters.Pig":
                        ActorManager.Singleton.Spawn<Pig>((Convert.ToInt32(actor["coordX"]), Convert.ToInt32(actor["coordY"])));
                        break;

                    // Items

                    case "DungeonCrawl.Actors.Items.KeySpecial":
                        ActorManager.Singleton.Spawn<KeySpecial>((Convert.ToInt32(actor["coordX"]), Convert.ToInt32(actor["coordY"])));
                        break;
                    case "DungeonCrawl.Actors.Items.Key":
                        ActorManager.Singleton.Spawn<Key>((Convert.ToInt32(actor["coordX"]), Convert.ToInt32(actor["coordY"])));
                        break;
                    case "DungeonCrawl.Actors.Items.Sword":
                        ActorManager.Singleton.Spawn<Sword>((Convert.ToInt32(actor["coordX"]), Convert.ToInt32(actor["coordY"])));
                        break;
                    case "DungeonCrawl.Actors.Items.BigHealth":
                        ActorManager.Singleton.Spawn<BigHealth>((Convert.ToInt32(actor["coordX"]), Convert.ToInt32(actor["coordY"])));
                        break;
                    case "DungeonCrawl.Actors.Items.SmallHealth":
                        ActorManager.Singleton.Spawn<SmallHealth>((Convert.ToInt32(actor["coordX"]), Convert.ToInt32(actor["coordY"])));
                        break;
                    case "DungeonCrawl.Actors.Items.Shield":
                        ActorManager.Singleton.Spawn<Shield>((Convert.ToInt32(actor["coordX"]), Convert.ToInt32(actor["coordY"])));
                        break;

                    case "DungeonCrawl.Actors.Static.Door":
                        ActorManager.Singleton.Spawn<Door>((Convert.ToInt32(actor["coordX"]), Convert.ToInt32(actor["coordY"])));
                        break;
                    case "DungeonCrawl.Actors.Static.DoorSpecial":
                        ActorManager.Singleton.Spawn<DoorSpecial>((Convert.ToInt32(actor["coordX"]), Convert.ToInt32(actor["coordY"])));
                        break;

                    default:
                        break;

                }
                if (actor["type"]  != "gameInfo")
                {
                    var newActor = ActorManager.Singleton.GetActorAt((Convert.ToInt32(actor["coordX"]), Convert.ToInt32(actor["coordY"])));
                    ApplyStats(newActor, actor);
                }
            }
        }

        public static void ApplyStats(Actor newActor, Dictionary<string, string> actorStats)
        {
            if (newActor is Character character)
            {
                character.Strength = Convert.ToInt32(actorStats["strength"]);
                character.Health = Convert.ToInt32(actorStats["health"]);
                character.ExpCount = Convert.ToInt32(actorStats["expCount"]);
            }

            if (newActor is Door door)
            {
                door.IsOpen = bool.Parse(actorStats["isOpen"]);
            }

            if (newActor is Player player)
            {
                player.ExpNeeded = Convert.ToInt32(actorStats["expNeeded"]);
                player.Shield = Convert.ToInt32(actorStats["shield"]);
                player.MaxHealth = Convert.ToInt32(actorStats["maxHealth"]);
                player.Inventory = ParseInventory(actorStats["inventory"]);
            }
        }

        public static void Load()
        {
            ActorManager.Singleton.DestroyAllActors();
            var readSave = ReadJson();
            LoadGameSettings(readSave[0]);
            MapLoader.LoadMap(true);
            SpawnActors(readSave);
        }

        public static void LoadGameSettings(Dictionary<string, string> gameInfo)
        {
            MapLoader.MapId = Convert.ToInt32(gameInfo["mapId"]);
            MapLoader.NewGameCount = Convert.ToInt32(gameInfo["newGameCount"]);
        }

        public static int GetMapId()
        {
            int currentId = MapLoader.MapId;
            if (currentId == 1)
            {
                return 3;
            }
            return currentId - 1;

        }

        public static Dictionary<string, int> ParseInventory(string inventoryString)
        {
            var inventory = JsonConvert.DeserializeObject<Dictionary<string, int>>(inventoryString);
            return inventory;
        }
    }
}
