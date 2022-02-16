using UnityEngine;

namespace DungeonCrawl.Actors.Characters
{
    public class Brute : Character
    {
        private float lastFrame = 0f;
        public Brute()
        {
            Health = 50 * Utilities.CountMultiplier();
            Strength = 25 * Utilities.CountMultiplier();
            ExpCount = (int)(10 * Utilities.ExpMultiplier());
        }

        protected override void OnUpdate(float deltaTime)
        {
            if (lastFrame > 0.25)
            {
                TryAttack();
                lastFrame = 0;
            }
            else
            {
                lastFrame += deltaTime;
            }

        }

        public override bool OnCollision(Actor anotherActor)
        {
            if (anotherActor is Player || anotherActor is Skeleton)
            {
                return false;
            }
            return true;
        }

        public override int DefaultSpriteId => 317;
        public override string DefaultName => "Brute";
    }
}
