using DungeonCrawl.Actors.Characters;
using DungeonCrawl.Core;

namespace DungeonCrawl.Actors.Items
{
    internal class SmallHealth : Item
    {
        public override int DefaultSpriteId => 518;
        public override string DefaultName => "SmallHealth";
        public override bool OnCollision(Actor anotherActor)
        {
            if (anotherActor is Player player)
            {
                if (player.Health >= 91)
                {
                    player.Health = player.MaxHealth;
                }
                else { player.AddToStat(Stats.Health, 10 * (int)Utilities.ExpMultiplier()) ; }
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
