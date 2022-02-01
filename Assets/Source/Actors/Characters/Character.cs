using DungeonCrawl.Core;
using System.Collections.Generic;
using UnityEngine;

namespace DungeonCrawl.Actors.Characters
{
    public abstract class Character : Actor
    {
        public int Health { get; set; }
        public int Shield { get; set; }
        public int Strength { get; set; }
        public override void ApplyDamage(int damage)
        {
            Health -= damage - Shield;

            if (Health <= 0)
            {
                if (Shield > 0)
                {
                    Shield -= damage / 2;
                }
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
                    List<Actor> enemiesNearMe = CollectEnemiesNearMe();
                    AttackEnemiesNearMe(enemiesNearMe);

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
                if (actorAtTargetPosition != null)
                {
                    return true;
                }
            }
            return false;
        }

        public List<Actor> CollectEnemiesNearMe()
        {
            List<Actor> enemies = new List<Actor>();
            foreach (var direction in Utilities.Directions)
            {
                (int x, int y) targetPosition = (Position.x + direction[0], Position.y + direction[1]);
                var actorAtTargetPosition = ActorManager.Singleton.GetActorAt(targetPosition);
                if (actorAtTargetPosition != null)
                {
                    if (actorAtTargetPosition.AttackAble(this))
                    {
                        enemies.Add(actorAtTargetPosition);
                    }
                }
            }
            return enemies;
        }

        public void AttackEnemiesNearMe(List<Actor> enemies)
        {
            foreach (var enemy in enemies)
            {
                enemy.ApplyDamage(this.Strength);
            }
        }    
    }
}


