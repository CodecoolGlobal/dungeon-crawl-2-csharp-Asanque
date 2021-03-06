using DungeonCrawl.Actors.Characters;

namespace DungeonCrawl.Actors.Static
{
    public class Door : Actor
    {
        public override int Z => -1;
        protected bool isOpen = false;
        public bool IsOpen { get { return isOpen; } set { isOpen = value; } }
        public override bool OnCollision(Actor anotherActor)
        {
            if (anotherActor is Skeleton)
            {
                return false;
            }
            if (!isOpen)
            {
                Player player = (Player)anotherActor;
                return CheckKeys(player);
            }
            return true;
        }
        public override int DefaultSpriteId => 485;
        public override string DefaultName => "Door";

        public virtual bool CheckKeys(Player player)
        {
            if (player.HasKey("key"))
            {
                UseKey(player);
                return true;
            };
            return false;
        }

        public virtual void UseKey(Player player)
        {
            isOpen = true;
            player.Inventory["key"] -= 1;
            SetSprite(487);
        }
    }
}
