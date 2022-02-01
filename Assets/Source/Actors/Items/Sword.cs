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
                if (anotherActor.inventory.ContainsKey("sword"))
                {
                    anotherActor.inventory["sword"] += 1;
                }
                else
                {
                    anotherActor.inventory.Add("sword", 1);
                }
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
