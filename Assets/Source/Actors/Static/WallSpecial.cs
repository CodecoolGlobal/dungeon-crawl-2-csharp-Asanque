using DungeonCrawl.Actors.Characters;

namespace DungeonCrawl.Actors.Static
{
    public class WallSpecial : Wall
    {
        public override bool OnCollision(Actor anotherActor)
        {
            if (anotherActor is Skeleton)
            {
                return false;
            }
            return true;
        }
    }
}
