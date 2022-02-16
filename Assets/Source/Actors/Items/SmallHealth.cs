using DungeonCrawl.Actors.Characters;
using DungeonCrawl.Core;

namespace DungeonCrawl.Actors.Items
{
    public class SmallHealth : Actor
    {
        public override int DefaultSpriteId => 518;
        public override string DefaultName => "SmallHealth";
        public override bool OnCollision(Actor anotherActor)
        {
            if (anotherActor is Player player)
            {
                if (player.Health >= 91)
                {
                    player.Health = 100;
                }
                else { player.AddToStat(Stats.Health, 10); }
                if (this != null)
                {
                    ActorManager.Singleton.DestroyActor(this);
                }
                else { return true; }

                return true;
            }
            else if (anotherActor is Demon)
            {
                return true;
            }
            else { return false; }
        }
    }
}
