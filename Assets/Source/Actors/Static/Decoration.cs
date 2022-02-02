using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using UnityEngine;
using DungeonCrawl.Actors.Characters;
using DungeonCrawl.Core;


namespace DungeonCrawl.Actors.Items
{
    internal class Decoration : Actor
    {
        public override int DefaultSpriteId => 1;
        public override string DefaultName => "Decor";
        public override bool OnCollision(Actor anotherActor)
        {
            return false;
        }
    }
}
