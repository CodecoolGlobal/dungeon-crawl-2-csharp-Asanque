using DungeonCrawl.Actors.Characters;
using UnityEngine;

namespace DungeonCrawl.Actors.Static
{
    public class FloorHidden : Actor
    {
        public override bool OnCollision(Actor anotherActor)
        {
            if (anotherActor.GetType() == typeof(Player))
            {
                Debug.Log("Credits:");
            }
            return true;
        }
        public override int DefaultSpriteId => -1;
        public override string DefaultName => "Floor";
    }
}
