using DungeonCrawl.Actors.Characters;
using DungeonCrawl.Core;

namespace DungeonCrawl.Actors.Static
{
    public class DoorSpecial : Door
    {
        public override bool CheckKeys(Player player)
        {
            if (player.HasKey("specialKey"))
            {
                UseKey(player);
                return true;
            };
            return false;
        }

        public override void UseKey(Player player)
        {
            isOpen = true;
            player.inventory["specialKey"] -= 1;
            SetSprite(487);
            ActorManager.Singleton.DestroyAllActors();
            MapLoader.LoadMap(2);
        }
    }
}
