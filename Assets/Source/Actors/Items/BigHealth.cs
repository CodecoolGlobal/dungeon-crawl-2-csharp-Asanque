using DungeonCrawl.Actors.Characters;
using DungeonCrawl.Core;

namespace DungeonCrawl.Actors.Items
{
    public class BigHealth : Actor
    {
        public override int DefaultSpriteId => 521;
        public override string DefaultName => "BigHealth";
        public override bool OnCollision(Actor anotherActor)
        {
            if (anotherActor is Player player)
            {
                player.Health = 100;
                if (this != null)
                {
                    ActorManager.Singleton.DestroyActor(this);
                }
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
