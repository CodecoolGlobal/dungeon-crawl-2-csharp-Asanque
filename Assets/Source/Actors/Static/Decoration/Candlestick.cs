using DungeonCrawl.Actors.Characters;
using DungeonCrawl.Core;

namespace DungeonCrawl.Actors.Static.Decoration
{
    internal class Candlesticks : Actor
    {
        public override int Z => -1;
        public override int DefaultSpriteId => ActorManager.RandomNumber() % 2 == 0 ? 723 : 724;
        public override string DefaultName => "Candlestick";
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
