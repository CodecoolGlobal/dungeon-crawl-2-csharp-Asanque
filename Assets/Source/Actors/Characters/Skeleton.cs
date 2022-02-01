using UnityEngine;

namespace DungeonCrawl.Actors.Characters
{
    public class Skeleton : Character
    {
        public Skeleton()
        {
            Health = 25;
            Strength = 5;
        }
        private float lastFrame = 0f;

        public override bool OnCollision(Actor anotherActor)
        {
            if (anotherActor.GetType() == typeof(Player))
            {
                return false;
            }
            return true;
        }

        protected override void OnDeath()
        {
            Debug.Log("Oink Oink...");
        }

        protected override void OnUpdate(float deltaTime)
        {
            if (lastFrame > 1)
            {
                int possibleDirections = 4;
                int randomDirection = Random.Range(0, possibleDirections);
                Direction direction = (Direction)randomDirection;
                TryMove(direction);
                lastFrame = 0;
                TryAttack();
            }
            else 
            {
                lastFrame += deltaTime;
            }
        }

        public override int DefaultSpriteId => 364;
        public override string DefaultName => "Skeleton";
    }
}
