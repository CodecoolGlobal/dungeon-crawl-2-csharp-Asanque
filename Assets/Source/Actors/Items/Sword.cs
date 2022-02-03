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
    internal class Sword : Actor
    {
        public override int DefaultSpriteId => 464;
        public override string DefaultName => "Sword";
        public override bool OnCollision(Actor anotherActor)
        {
            if (anotherActor.GetType() == typeof(Player))
            {
                anotherActor.inventory["sword"] += 1;
                anotherActor.AddToStat(Stats.Strength, 5);
            }
            else if (anotherActor.GetType() == typeof(Demon))
            {
                return true;
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
