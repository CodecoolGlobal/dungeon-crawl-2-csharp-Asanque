using System;
using UnityEngine;

namespace DungeonCrawl.Actors.Characters
{
    public class Pig : Skeleton
    {
        public override int DefaultSpriteId => 609;
        public override string DefaultName => "Skeleton";

        protected override void OnUpdate(float deltaTime)
        {
            if (lastFrame > 1)
            {
                if (count == 3)
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

        private void DemonMorph(int count)
        {
            switch (count)
            {
                case 0:
                    SetSprite(364);
                    break;
                case 1:
                    SetSprite(363);
                    break;
                case 2:
                    SetSprite(362);
                    break;
                default:
                    throw new ArgumentOutOfRangeException();
            }
        }
    }
}
