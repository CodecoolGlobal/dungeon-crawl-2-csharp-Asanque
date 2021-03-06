using DungeonCrawl.Core;
using System.Collections.Generic;

namespace DungeonCrawl.Actors.Characters
{
    public abstract class Character : Actor
    {
        public int Health { get; set; }
        public int MaxHealth { get; set; } = 100;
        public int Shield { get; set; } = 0;
        public int Strength { get; set; }
        public int ExpCount { get; set; }
        public int ExpNeeded { get; set; } = 70;
        public override void ApplyDamage(int damage)
        {
            int incomingDamage = damage - Shield;
            if (incomingDamage < 0)
            {
                incomingDamage = 0;
            }
            Health -= incomingDamage;

            if (Shield > 0)
            {
                Shield -= damage / 4;
                if (Shield < 0)
                {
                    Shield = 0;
                }
            }
            if (Health <= 0)
            {
                // Die
                OnDeath();
                ActorManager.Singleton.DestroyActor(this);
            }
        }

        public Dictionary<string, int> GetStats()
        {
            Dictionary<string, int> characterStats = new Dictionary<string, int> 
            {{ "Health", Health }, { "Strength", Strength }, { "Shield", Shield },
            { "ExpCount", ExpCount}, { "ExpNeeded", ExpNeeded } , { "MaxHealth", MaxHealth }};
            return characterStats;
    }

        protected virtual void OnDeath()
        {
            (int x, int y) playerPosition = ActorManager.Singleton.GetPlayerPosition();
            Player player = (Player)ActorManager.Singleton.GetActorAt(playerPosition);
            player.ExpCount += ExpCount;
        }

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
                    if (actorAtTargetPosition.Attackable(this))
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

        public override bool Attackable(Actor anotherActor)
        {
            if (anotherActor is Player)
            {
                return true;
            }
            return false;
        }
    }
}


