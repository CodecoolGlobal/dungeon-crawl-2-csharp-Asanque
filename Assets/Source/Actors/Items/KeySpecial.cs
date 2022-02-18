using DungeonCrawl.Actors.Characters;
using DungeonCrawl.Core;


namespace DungeonCrawl.Actors.Items
{
    internal class KeySpecial : Key
    {
        public override bool CheckCollision(Actor anotherActor)
        {
            if (anotherActor is Player)
            {
                anotherActor.Inventory["specialKey"] += 1;
            }
            else
            {
                return false;
            }
            ActorManager.Singleton.DestroyActor(this);
            return true;
        }
        public override int DefaultSpriteId => 559;
    }
}
