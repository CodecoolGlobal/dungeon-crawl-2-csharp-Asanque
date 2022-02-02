using System;
using DungeonCrawl;
using DungeonCrawl.Actors;
using DungeonCrawl.Actors.Characters;
using UnityEngine;

namespace Assets.Source.Actors.Characters
{
    internal class Demon : Character
    {
        private float lastFrame = 0f;

        private int count = 0;


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
            Debug.Log("sjasSNÉKnkébsnBÉC...");
        }

        protected override void OnUpdate(float deltaTime)
        {
            if (lastFrame > 1)
            {
                if (count == 5)
                {
                    count = 0;
                }

                DemonMorph(count);
                int possibleDirections = 4;
                int randomDirection = UnityEngine.Random.Range(0, possibleDirections);
                Direction direction = (Direction)randomDirection;
                TryMove(direction);
                lastFrame = 0;
                count++;
            }
            else
            {
                lastFrame += deltaTime;
            }
        }

        public void DemonMorph(int count)
        {
            switch (count)
            {
                case 0:
                    SetSprite(401);
                    break;
                case 1:
                    SetSprite(402);
                    break;
                case 2:
                    SetSprite(403);
                    break;
                case 3:
                    SetSprite(404);
                    break;
                case 4:
                    SetSprite(405);
                    break;
                default:
                    throw new ArgumentOutOfRangeException();
            }
        }

        public override int DefaultSpriteId => 401;

        public override string DefaultName => "Demon";
    }
}
