using Assets.Source.Actors.Characters;
using DungeonCrawl.Actors.Characters;

namespace DungeonCrawl.Actors.Static
{
    public class Wall : Actor
    {
        public override bool OnCollision(Actor anotherActor)
        {
            if (anotherActor.GetType() == typeof(Player) || anotherActor.GetType() == typeof(Skeleton) || anotherActor.GetType() == typeof(Demon))
            {
                return false;
            }
            return true;
        }
        public override int DefaultSpriteId => 825;
        public override string DefaultName => "Wall";

    }
}
