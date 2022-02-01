using DungeonCrawl.Core;
using UnityEngine;

namespace DungeonCrawl.Actors.Characters
{
    public abstract class Character : Actor
    {
        public int Health { get; private set; }
        public int Strength { get; set; }

        public void ApplyDamage(int damage)
        {
            Debug.Log(this.Health);
            Health -= damage;

            if (Health <= 0)
            {
                // Die
                OnDeath();

                ActorManager.Singleton.DestroyActor(this);
            }
        }

        protected abstract void OnDeath();

        /// <summary>
        ///     All characters are drawn "above" floor etc
        /// </summary>
        public override int Z => -1;

        public void TryAttack()
        {
            switch (CheckAttack())
            {
                case true:
                    Debug.Log($"I {this.name} is attacking");
                    break;
                case false:
                    break;
            }
        }
        public bool CheckAttack()
        {
            foreach (var direction in Utilities.Directions)
            {
                (int x, int y) targetPosition = (Position.x + direction[0], Position.y + direction[1]);
                var actorAtTargetPosition = ActorManager.Singleton.GetActorAt(targetPosition);
                if (actorAtTargetPosition == null)
                {
                    continue;
                }
                else
                {
                    if (actorAtTargetPosition.AttackAble(this))
                    {
                        Character attackableActor = (Character)actorAtTargetPosition; 
                        attackableActor.ApplyDamage(this.Strength);
                        return true;
                    }
                }
            }
            return false;
        }
    }
}


