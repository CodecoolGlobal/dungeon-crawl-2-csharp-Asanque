using System;
using UnityEngine;
using DungeonCrawl.Core;

namespace DungeonCrawl.Actors.Characters
{
    internal class Demon : Character
    {
        private float lastFrame = 0f;

        private int count = 0;

        public Demon()
        {
            Health = 20 * Utilities.countMultiplier();
            Strength = 5 * Utilities.countMultiplier();
            ExpCount = (int)(5 * Utilities.expMultiplier());
        }
        public override bool OnCollision(Actor anotherActor)
        {
            if (anotherActor.GetType() == typeof(Player))
            {
                return false;
            }
            return true;
        }

        protected override void OnUpdate(float deltaTime)
        {
            if (lastFrame > 0.3)
            {
                if (count == 5)
                {
                    count = 0;
                }
                DemonMorph(count);
                FollowPlayer();
                TryAttack();
                lastFrame = 0;
                count++;
        }
            else
            {
                lastFrame += deltaTime;
            }
}

        private void FollowPlayer()
        {
            (int row, int col) playerPosition = ActorManager.Singleton.GetPlayerPosition();
            int rowDifference = this.Position.x - playerPosition.row;
            int colDifference = this.Position.y - playerPosition.col;
            if (Math.Abs(rowDifference) > Math.Abs(colDifference))
            {
                if (rowDifference > 0)
                {
                    TryMove(Direction.Left);
                }
                else
                {
                    TryMove(Direction.Right);
                }
            }
            else
            {
                if (colDifference > 0)
                {
                    TryMove(Direction.Down);
                }
                else
                {
                    TryMove(Direction.Up);
                }
            }
        }

        private void DemonMorph(int count)
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
