﻿using UnityEngine;

namespace DungeonCrawl.Actors.Characters
{
    public class Brute : Character
    {
        public Brute()
        {
            Health = 50;
            Strength = 10;
        }
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
            Debug.Log("Aaaaaaaaaaaa...");
        }

        public override int DefaultSpriteId => 317;
        public override string DefaultName => "Brute";
    }
}
