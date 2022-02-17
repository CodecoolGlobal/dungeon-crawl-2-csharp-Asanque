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
                if (this != null)
                {
                    UserInterface.Singleton.SetText("Creators: Peti, Nati, Marci, Asanque", UserInterface.TextPosition.MiddleCenter);
                }
                return true;
            }
            return false;
        }
        public override int DefaultSpriteId => -1;
        public override string DefaultName => "Floor";
    }
}
