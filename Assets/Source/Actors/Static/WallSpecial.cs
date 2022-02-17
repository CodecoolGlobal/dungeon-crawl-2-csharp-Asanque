using Assets.Source.Core;
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
            if (this != null) { UserInterface.Singleton.SetText(string.Empty, UserInterface.TextPosition.MiddleCenter); }
            return true;
        }
    }
}
