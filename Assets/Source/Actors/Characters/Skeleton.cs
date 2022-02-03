using System;
using UnityEngine;

namespace DungeonCrawl.Actors.Characters
{
    public class Skeleton : Character
    {
        protected int count = 0;
        public Skeleton()
        {
            Health = 25 * Utilities.countMultiplier();
            Strength = 10 * Utilities.countMultiplier();
        }
        protected float lastFrame = 0f;

        public override bool OnCollision(Actor anotherActor)
        {
            if (anotherActor is Player || anotherActor is Skeleton || anotherActor is Demon)
            {
                return false;
            }
            return true;
        }

        protected override void OnDeath()
        {
            Debug.Log("Bye!");
        }

        protected override void OnUpdate(float deltaTime)
        {
            if (lastFrame > 1)
            {
                if (count == 2)
                {
                    count = 0;
                }
                DemonMorph(count);
                int possibleDirections = 4;
                int randomDirection = UnityEngine.Random.Range(0, possibleDirections);
                Direction direction = (Direction)randomDirection;
                TryMove(direction);
                lastFrame = 0;
                TryAttack();
                count++;
            }
            else
            {
                lastFrame += deltaTime;
            }
        }

        public override int DefaultSpriteId => 609;
        public override string DefaultName => "Skeleton";

        private void DemonMorph(int count)
        {
            switch (count)
            {
                case 0:
                    SetSprite(565);
                    break;
                case 1:
                    SetSprite(609);
                    break;
                default:
                    throw new ArgumentOutOfRangeException();
            }
        }
    }
}
