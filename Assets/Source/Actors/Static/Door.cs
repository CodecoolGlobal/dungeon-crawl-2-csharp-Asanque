using DungeonCrawl.Actors.Characters;

namespace DungeonCrawl.Actors.Static
{
    public class Door : Actor
    {
        private bool isOpen = false;
        public override bool OnCollision(Actor anotherActor)
        {
            if (anotherActor is Skeleton)
            {
                return false;
            }
            if (!isOpen)
            {
                Player player = (Player)anotherActor;
                if (player.HasKey())
                {
                    isOpen = true;
                    player.inventory["key"] -= 1;
                    SetSprite(487);
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
