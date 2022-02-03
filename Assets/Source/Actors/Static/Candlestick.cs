using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using UnityEngine;
using DungeonCrawl.Actors.Characters;
using DungeonCrawl.Core;
using Random = UnityEngine.Random;


namespace DungeonCrawl.Actors.Items
{
    internal class Candlesticks : Actor
    {
        public override int DefaultSpriteId => ActorManager.RandomNumber() % 2 == 0 ? 723 : 724;
        public override string DefaultName => "Candlestick";
        public override bool OnCollision(Actor anotherActor)
        {
            if (anotherActor.GetType() == typeof(Demon))
            {
                return true;
            }
            return false;
        }
    }
}
