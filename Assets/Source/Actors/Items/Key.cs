using DungeonCrawl.Actors.Characters;
using DungeonCrawl.Core;


namespace DungeonCrawl.Actors.Items
{
    public class Key : Actor
    {
        public override int DefaultSpriteId => 560;
        public override string DefaultName => "Key";
        public override bool OnCollision(Actor anotherActor)
        {
            if (anotherActor is Player)
            {
                anotherActor.inventory["key"] += 1;
            }
            else if (anotherActor is Demon)
            {
                return true;
            }
            else
            {
                return false;
            }

            if (this != null)
            {
                ActorManager.Singleton.DestroyActor(this);
            }
            
            return true;
        }
    }
}
