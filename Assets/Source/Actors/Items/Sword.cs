using DungeonCrawl.Actors.Characters;
using DungeonCrawl.Core;


namespace DungeonCrawl.Actors.Items
{
    public class Sword : Actor
    {
        public override int DefaultSpriteId => 464;
        public override string DefaultName => "Sword";
        public override bool OnCollision(Actor anotherActor)
        {
            if (anotherActor is Player)
            {
                anotherActor.inventory["sword"] += 1;
                anotherActor.AddToStat(Stats.Strength, 5 * Utilities.countMultiplier());
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
            else { return true; }
            
            return true;
        }
    }
}
