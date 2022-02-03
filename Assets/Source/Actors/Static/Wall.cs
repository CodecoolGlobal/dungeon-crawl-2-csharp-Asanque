using DungeonCrawl.Actors.Characters;

namespace DungeonCrawl.Actors.Static
{
    public class Wall : Actor
    {
        public override bool OnCollision(Actor anotherActor)
        {
            if (anotherActor is Player || anotherActor is Skeleton)
            {
                return false;
            }
            return true;
        }
        public override int DefaultSpriteId => 825;
        public override string DefaultName => "Wall";

    }
}
