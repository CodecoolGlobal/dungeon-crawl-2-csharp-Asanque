using DungeonCrawl.Actors.Characters;
using DungeonCrawl.Core;

namespace DungeonCrawl.Actors.Items
{
    internal class SmallHealth : Actor
    {
        public override int DefaultSpriteId => 518;
        public override string DefaultName => "SmallHealth";
        public override bool OnCollision(Actor anotherActor)
        {
            if (anotherActor is Player)
            {
                Player player = (Player)anotherActor;
                if (player.Health >= 91)
                {
                    player.Health = 100;
                }
                else { player.AddToStat(Stats.Health, 10); }
                ActorManager.Singleton.DestroyActor(this);
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
