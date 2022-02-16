using DungeonCrawl.Actors.Characters;
using DungeonCrawl.Core;


namespace DungeonCrawl.Actors.Items
{
    internal class Shield : Actor
    {
        public override int Z => -1;
        public override int DefaultSpriteId => 230;
        public override string DefaultName => "Shield";
        public override bool OnCollision(Actor anotherActor)
        {
            if (anotherActor is Player)
            {
                anotherActor.inventory["shield"] += 1;
                int statToAdd = 5 * Utilities.countMultiplier();
                anotherActor.AddToStat(Stats.Shield, statToAdd);
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
