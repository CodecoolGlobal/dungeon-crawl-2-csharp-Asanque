using UnityEngine;

namespace DungeonCrawl.Actors.Characters
{
    public class Skeleton : Character
    {

        public new int Health = 50;
        public new int Strength = 5;
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
                Debug.Log("Im getting attacked by a player");
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
