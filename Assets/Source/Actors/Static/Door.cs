using DungeonCrawl.Actors.Characters;

namespace DungeonCrawl.Actors.Static
{
    public class Door : Actor
    {
        private bool isOpen = false;
        public override bool OnCollision(Actor anotherActor)
        {
            if (anotherActor.GetType() == typeof(Skeleton))
            {
                return false;
            }
            if (!isOpen)
            {
                if (anotherActor.HasKey())
                {
                    isOpen = true;
                    return true;
                };
                return false;
            }
            return true;
        }
        public override int DefaultSpriteId => 485;
        public override string DefaultName => "Door";
    }
}
