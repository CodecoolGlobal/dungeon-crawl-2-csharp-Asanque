using UnityEngine;

namespace DungeonCrawl.Actors.Characters
{
    public class Skeleton : Character
    {
        public Skeleton()
        {
            Health = 50;
            Strength = 5;
            Shield = 0;
        }
        public override bool OnCollision(Actor anotherActor)
        {
            if (anotherActor.GetType() == typeof(Player))
            {
                return false;
            }
            return true;
        }

        public override bool AttackAble(Actor anotherActor)
        {
            if (anotherActor.GetType() == typeof(Player))
            {
                return true;
            }
            return false;
        }

        protected override void OnDeath()
        {
            Debug.Log("Well, I was already dead anyway...");
        }

        public override int DefaultSpriteId => 316;
        public override string DefaultName => "Skeleton";
    }
}
