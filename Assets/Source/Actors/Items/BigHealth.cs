using DungeonCrawl.Actors.Characters;
using DungeonCrawl.Core;
using Assets.Source.Actors;

namespace DungeonCrawl.Actors.Items
{
    internal class BigHealth : Item
    {
        public override int DefaultSpriteId => 521;
        public override string DefaultName => "BigHealth";
        public override bool CheckCollision(Actor anotherActor)
        {
            if (anotherActor is Player player)
            {
                player.Health = player.MaxHealth;
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
