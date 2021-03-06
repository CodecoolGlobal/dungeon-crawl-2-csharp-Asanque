using DungeonCrawl.Actors.Characters;
using DungeonCrawl.Core;


namespace DungeonCrawl.Actors.Items
{
    internal class Sword : Item
    {
        public override int DefaultSpriteId => 464;
        public override string DefaultName => "Sword";
        public override bool OnCollision(Actor anotherActor)
        {
            if (anotherActor is Player)
            {
                anotherActor.Inventory["sword"] += 1;
                anotherActor.AddToStat(Stats.Strength, 5 * Utilities.CountMultiplier());
            }
            else if (anotherActor is Demon)
            {
                return true;
            }
            else
            {
                return false;
            }
            ActorManager.Singleton.DestroyActor(this);
            return true;
        }
    }
}
