using Assets.Source.Core;
using DungeonCrawl.Actors.Characters;
using UnityEngine;

namespace DungeonCrawl.Actors.Static
{
    public class FloorHidden : Actor
    {
        public override bool OnCollision(Actor anotherActor)
        {
            if (anotherActor is Player)
            {
                UserInterface.Singleton.SetText("Creators: Peti, Nati, Marci, Asanque", UserInterface.TextPosition.MiddleCenter);
            }
            return true;
        }
        public override int DefaultSpriteId => -1;
        public override string DefaultName => "Floor";
    }
}
