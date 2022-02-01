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
        private float lastFrame = 0f;

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
            Debug.Log("Oink Oink...");
        }

        protected override void OnUpdate(float deltaTime)
        {
            if (lastFrame > 1)
            {
                int possibleDirections = 4;
                int randomDirection = UnityEngine.Random.Range(0, possibleDirections);
                Direction direction = (Direction)randomDirection;
                TryMove(direction);
                lastFrame = 0;
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
