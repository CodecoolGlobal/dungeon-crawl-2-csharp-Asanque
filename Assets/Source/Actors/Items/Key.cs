﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using UnityEngine;
using DungeonCrawl.Actors.Characters;
using DungeonCrawl.Core;


namespace DungeonCrawl.Actors.Items
{
    internal class Key : Actor
    {
        public override int DefaultSpriteId => 559;
        public override string DefaultName => "Key";
        public override bool OnCollision(Actor anotherActor)
        {
            if (anotherActor.GetType() == typeof(Player))
            {
                if (anotherActor.inventory.ContainsKey("key"))
                {
                    anotherActor.inventory["key"] += 1;
                }
                else
                {
                    anotherActor.inventory.Add("key", 1);
                }
            }
            ActorManager.Singleton.DestroyActor(this);
            return true;
        }
    }
}
