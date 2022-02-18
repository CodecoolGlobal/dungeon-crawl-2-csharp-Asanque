using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using DungeonCrawl.Actors;
using DungeonCrawl.Actors.Characters;

namespace DungeonCrawl.Actors.Items
{
    public abstract class Item : Actor
    {
        public override int Z => -1;

        public override bool OnCollision(Actor anotherActor)
        {
            //Player.PrintAddedItem(this.name);
            return CheckCollision(anotherActor);
        }

        public abstract bool CheckCollision(Actor anotherActor);
    }
}
