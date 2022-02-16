using System;
using System.Collections.Generic;
using Newtonsoft.Json;
using DungeonCrawl.Core;
using DungeonCrawl.Actors.Characters;
using System.IO;
using DungeonCrawl;
using DungeonCrawl.Actors;
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

                JsonSerializer serializer = new JsonSerializer();
                List<Dictionary<string, string>> savedActor = new List<Dictionary<string, string>>();
                foreach (var actor in ActorManager.Singleton.AllActors)
                {
                    if (actor is Character || actor is Door || actor is Item)
                    {
                        Dictionary<string, string> currentActor = new Dictionary<string, string>();
                        if (actor is Player player)
                        {
                            currentActor["inventory"] = JsonConvert.SerializeObject(player.inventory);

                        }

                        if (actor is Character character)
                        {
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
                        savedActor.Add(currentActor);
                    }


                }

                using (StreamWriter sw = new StreamWriter(@"Json.json"))
                using (JsonWriter writer = new JsonTextWriter(sw))
                {
                    serializer.Formatting = Formatting.Indented;
                    serializer.Serialize(writer, savedActor);
                }
            }
            catch (Exception ex)
            {
                UserInterface.Singleton.PrintException(ex);
            }
        }
    }
}
