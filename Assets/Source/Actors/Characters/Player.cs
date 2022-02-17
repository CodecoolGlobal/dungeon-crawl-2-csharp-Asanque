using Assets.Source.Core;
using DungeonCrawl.Core;
using UnityEngine;
using Assets.Source.Sounds;

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
            ExpCount = 0;
        }
        protected override void OnUpdate(float deltaTime)
        {
            if (lastFrame > 0.1)
            {
                UserInterface.Singleton.PrintInterface(Inventory, MaxHealth ,Health, Strength, Shield);
                UserInterface.Singleton.PrintExp(ExpCount, ExpNeeded);
                if (Input.GetKeyDown(KeyCode.W) || Input.GetKey(KeyCode.W))
                {
                    // Move up
                    TryMove(Direction.Up);
                    FindObjectOfType<AudioManager>().Play("StepOne");
                }

                if (Input.GetKeyDown(KeyCode.S) || Input.GetKey(KeyCode.S))
                {
                    // Move down
                    TryMove(Direction.Down);
                    FindObjectOfType<AudioManager>().Play("StepOne");
                }

                if (Input.GetKeyDown(KeyCode.A) || Input.GetKey(KeyCode.A))
                {
                    // Move left
                    TryMove(Direction.Left);
                    FindObjectOfType<AudioManager>().Play("StepOne");
                }

                if (Input.GetKeyDown(KeyCode.D) || Input.GetKey(KeyCode.D))
                {
                    // Move right
                    TryMove(Direction.Right);
                    FindObjectOfType<AudioManager>().Play("StepOne");
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

            if (Input.GetKeyDown(KeyCode.F5))
            {
                SaveManager.Save();
            }

            CheckExp();
            CameraController.Singleton.Position = Position;
        }

        public void CheckExp()
        {
            if (ExpCount >= ExpNeeded)
            {
                ExpCount -= ExpNeeded;
                ExpNeeded = (int)(ExpNeeded * Utilities.ExpMultiplier());
                MaxHealth = (int)(MaxHealth * Utilities.ExpMultiplier());
            }
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
            if (Inventory[key] > 0 )
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
