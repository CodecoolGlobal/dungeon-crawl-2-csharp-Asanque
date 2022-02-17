using DungeonCrawl.Actors.Characters;

namespace DungeonCrawl.Actors.Static.Decoration
{
    internal class PassableDecoration : Decoration
    {
        public override int Z => -1;
        public override bool OnCollision(Actor anotherActor)
        {
            return true;
        }
    }
}
