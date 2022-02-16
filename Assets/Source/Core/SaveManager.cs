using System.Collections.Generic;
using Newtonsoft.Json;
using DungeonCrawl.Core;
using DungeonCrawl.Actors.Characters;
using System.IO;
using DungeonCrawl.Actors.Static;

namespace Assets.Source.Core
{
    public static class SaveManager
    {
        public static void WriteToJson()
        {
            JsonSerializer serializer = new JsonSerializer();
            Dictionary<string, List<Dictionary<string,string>>> savedActor = new Dictionary<string, List<Dictionary<string, string>>>();
            savedActor["Characters"] = new List<Dictionary<string, string>>();
            foreach (var actor in ActorManager.Singleton.AllActors)
            {
                if (actor is Character || actor is Door)
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
                    savedActor["Characters"].Add(currentActor);
                }
                

            }
            using (StreamWriter sw = new StreamWriter(@"C:\Users\kisge\Desktop\Codecool\OOP\Week 4\dungeon-crawl-2-csharp-Asanque\json.txt"))
            using(JsonWriter writer = new JsonTextWriter(sw))
            {
                serializer.Serialize(writer, savedActor);
            }
        }
    }
}
