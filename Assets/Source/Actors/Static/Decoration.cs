using DungeonCrawl.Actors.Characters;

namespace DungeonCrawl.Actors.Items
{
    internal class Decoration : Actor
    {
        public override int DefaultSpriteId => 1;
        public override string DefaultName => "Decor";
        public override bool OnCollision(Actor anotherActor)
        {
            if (anotherActor is Demon)
            {
                return true;
            }
            return false;
        }
    }
}
