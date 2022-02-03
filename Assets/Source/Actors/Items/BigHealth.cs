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
    internal class BigHealth : Actor
    {
        public override int DefaultSpriteId => 521;
        public override string DefaultName => "BigHealth";
        public override bool OnCollision(Actor anotherActor)
        {
            if (anotherActor is Player player)
            {
                player.Health = 100;
                ActorManager.Singleton.DestroyActor(this);
                return true;
            }
            else if (anotherActor.GetType() == typeof(Demon))
            {
                return true;
            }
            else { return false; }
        }
    }
}
