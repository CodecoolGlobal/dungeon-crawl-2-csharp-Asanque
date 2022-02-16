using DungeonCrawl.Actors.Characters;
using DungeonCrawl.Core;


namespace DungeonCrawl.Actors.Items
{
    public class KeySpecial : Key
    {
        public override bool OnCollision(Actor anotherActor)
        {
            if (anotherActor is Player)
            {
                anotherActor.inventory["specialKey"] += 1;
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
        public override int DefaultSpriteId => 559;
    }
}
