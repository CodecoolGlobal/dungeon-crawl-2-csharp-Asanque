using UnityEngine;

namespace DungeonCrawl.Actors.Characters
{
    public class Brute : Character
    {
        private float lastFrame = 0f;
        public Brute()
        {
            Health = 50;
            Strength = 10;
        }

        protected override void OnUpdate(float deltaTime)
        {
            if (lastFrame > 1)
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
