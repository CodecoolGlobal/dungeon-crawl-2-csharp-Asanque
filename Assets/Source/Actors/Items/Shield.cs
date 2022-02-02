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
    internal class Shield : Actor
    {
        public override int DefaultSpriteId => 230;
        public override string DefaultName => "Shield";
        public override bool OnCollision(Actor anotherActor)
        {
            if (anotherActor.GetType() == typeof(Player))
            {
                if (anotherActor.inventory.ContainsKey("shield"))
                {
                    anotherActor.inventory["shield"] += 1;
                }
                else
                {
                    anotherActor.inventory.Add("shield", 1);
                }
                anotherActor.AddToStat(Stats.Shield, 5);
            }
            else
            {
                return false;
            }
            ActorManager.Singleton.DestroyActor(this);
            return true;
        }
    }
}
