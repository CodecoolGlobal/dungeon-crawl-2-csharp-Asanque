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
    internal class SmallHealth : Actor
    {
        public override int DefaultSpriteId => 518;
        public override string DefaultName => "SmallHealth";
        public override bool OnCollision(Actor anotherActor)
        {
            if (anotherActor is Player player)
            {
                if (player.Health >= 91)
                {
                    player.Health = 100;
                }
                else if (anotherActor.GetType() == typeof(Demon))
                {
                    return true;
                }
                else { player.AddToStat(Stats.Health, 10); }
                ActorManager.Singleton.DestroyActor(this);
                return true;
            }
            else { return false; }
        }
    }
}
