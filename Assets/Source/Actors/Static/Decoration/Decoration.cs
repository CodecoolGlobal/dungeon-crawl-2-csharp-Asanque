using DungeonCrawl.Actors.Characters;

namespace DungeonCrawl.Actors.Static.Decoration
{
    internal class Decoration : Actor
    {
        public override int Z => -1;
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
