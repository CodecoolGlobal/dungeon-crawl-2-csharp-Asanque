using Assets.Source.Actors.Characters;
using UnityEngine;

namespace DungeonCrawl.Actors.Characters
{
    public class Brute : Character
    {
        public override bool OnCollision(Actor anotherActor)
        {
            if (anotherActor.GetType() == typeof(Player) || anotherActor.GetType() == typeof(Skeleton) || anotherActor.GetType() == typeof(Demon))
            {
                return false;
            }
            return true;
        }

        protected override void OnDeath()
        {
            Debug.Log("Aaaaaaaaaaaa...");
        }

        public override int DefaultSpriteId => 317;
        public override string DefaultName => "Brute";
    }
}
