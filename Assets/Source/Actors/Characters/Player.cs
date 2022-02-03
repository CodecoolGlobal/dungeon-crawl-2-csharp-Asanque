using Assets.Source.Core;
using DungeonCrawl.Core;
using System.Collections.Generic;
using UnityEngine;
using Assets.Source.Sounds;

namespace DungeonCrawl.Actors.Characters
{
    public class Player : Character
    {
        public Player()
        {
            Health = 100;
            Strength = 10;
            Shield = 5;
        }
        protected override void OnUpdate(float deltaTime)
        {
            UserInterface.Singleton.PrintInterface(inventory, Health, Strength, Shield);
            if (Input.GetKeyDown(KeyCode.W))
            {
                // Move up
                TryMove(Direction.Up);
                FindObjectOfType<AudioManager>().Play("StepOne");
            }

            if (Input.GetKeyDown(KeyCode.S))
            {
                // Move down
                TryMove(Direction.Down);
                FindObjectOfType<AudioManager>().Play("StepOne");
            }

            if (Input.GetKeyDown(KeyCode.A))
            {
                // Move left
                TryMove(Direction.Left);
                FindObjectOfType<AudioManager>().Play("StepOne");
            }

            if (Input.GetKeyDown(KeyCode.D))
            {
                // Move right
                TryMove(Direction.Right);
                FindObjectOfType<AudioManager>().Play("StepOne");
            }
            if (Input.GetKeyDown(KeyCode.Space))
            {
                TryAttack();
            }
            if (Input.GetKeyDown(KeyCode.LeftShift))
            {
                ActorManager.Singleton.SavePlayerInventory();
                ActorManager.Singleton.DestroyAllActors();
                MapLoader.LoadMap(2);
                ActorManager.Singleton.LoadPlayerInventory();
            }
            CameraController.Singleton.Position = Position;
        }

        public override bool IsPlayer()
        {
            return true;
        }

        public override bool AttackAble(Actor anotherActor)
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
            Debug.Log("Oh no, I'm dead!");
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

        public bool HasKey()
        {
            if (inventory.ContainsKey("key") && inventory["key"] > 0 )
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
