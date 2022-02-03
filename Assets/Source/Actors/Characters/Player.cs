using Assets.Source.Core;
using DungeonCrawl.Core;
using UnityEngine;

namespace DungeonCrawl.Actors.Characters
{
    public class Player : Character
    {
        private float lastFrame = 0f;
        public Player()
        {
            Health = 100;
            Strength = 10;
            Shield = 5;
        }
        protected override void OnUpdate(float deltaTime)
        {
            if (lastFrame > 0.1)
            {
                UserInterface.Singleton.PrintInterface(inventory, Health, Strength, Shield);
                if (Input.GetKeyDown(KeyCode.W) || Input.GetKey(KeyCode.W))
                {
                    // Move up
                    TryMove(Direction.Up);
                }

                if (Input.GetKeyDown(KeyCode.S) || Input.GetKey(KeyCode.S))
                {
                    // Move down
                    TryMove(Direction.Down);
                }

                if (Input.GetKeyDown(KeyCode.A) || Input.GetKey(KeyCode.A))
                {
                    // Move left
                    TryMove(Direction.Left);
                }

                if (Input.GetKeyDown(KeyCode.D) || Input.GetKey(KeyCode.D))
                {
                    // Move right
                    TryMove(Direction.Right);
                }
                lastFrame = 0;
            }
            else
            {
                lastFrame += deltaTime;
            }

            if (Input.GetKeyDown(KeyCode.LeftShift))
            {
                ActorManager.Singleton.SavePlayerInventory();
                ActorManager.Singleton.DestroyAllActors();
                MapLoader.LoadMap();
                ActorManager.Singleton.LoadPlayerInventory();
            }

            if (Input.GetKeyDown(KeyCode.Space))
            {
                TryAttack();
            }
            CameraController.Singleton.Position = Position;
        }

        public override bool IsPlayer()
        {
            return true;
        }

        public override bool Attackable(Actor anotherActor)
        {
            if (Utilities.EnemyTypes.Contains(anotherActor.GetType()))
            {
                return true;
            }
            return false;
        }

        public override bool OnCollision(Actor anotherActor)
        {
            return false;
        }

        protected override void OnDeath()
        {
            UserInterface.Singleton.ClearUi();
            UserInterface.Singleton.PrintGameOverText();
        }

        public override int DefaultSpriteId => 24;
        public override string DefaultName => "Player";

        public Direction Direction
        {
            get => default;
            set
            {
            }
        }

        public bool HasKey(string key)
        {
            if (inventory[key] > 0 )
            {
                return true;
            }
            return false;
        }

        public override void AddToStat(Stats stat, int toAdd)
        {
            switch (stat)
            {
                case Stats.Health:
                    Health += toAdd;
                    break;

                case Stats.Strength:
                    Strength += toAdd;
                    break;

                case Stats.Shield:
                    Shield += toAdd;
                    break;
            }
        }
    }
}
