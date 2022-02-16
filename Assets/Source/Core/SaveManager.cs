using System;
using System.Collections.Generic;
using Newtonsoft.Json;
using DungeonCrawl.Core;
using DungeonCrawl.Actors.Characters;
using System.IO;
using DungeonCrawl.Actors.Items;
using DungeonCrawl.Actors.Static;

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
            foreach (var actor in ActorManager.Singleton.AllActors)
            {
                if (actor is Character || actor is Door || actor is Item)
                {
                    Dictionary<string, string> currentActor = new Dictionary<string, string>();
                    if (actor is Player player)
                    {
                        currentActor["inventory"] = JsonConvert.SerializeObject(player.inventory);
                        currentActor["maxHealth"] = player.MaxHealth.ToString();
                        currentActor["expNeeded"] = player.ExpNeeded.ToString();
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


    }
}
