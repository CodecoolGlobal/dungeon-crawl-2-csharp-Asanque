using System.Collections;
using System.Collections.Generic;
using NUnit.Framework;
using UnityEngine;
using UnityEngine.TestTools;
using DungeonCrawl.Actors.Characters;
using DungeonCrawl;
using DungeonCrawl.Core;
using DungeonCrawl.Actors;
using DungeonCrawl.Actors.Static;
using DungeonCrawl.Actors.Items;
using Assets.Source.Actors;

public class SwordCollisionTest
{
    private Player player;
    private Sword sword;
    private Brute brute;
    [SetUp]
    // A Test behaves as an ordinary method
    public void Init()
    {
        player = new Player();
        sword = new Sword();
        brute = new Brute();
    }

    [Test]
    public void SwordIntoInventory()
    {
        
        int expectedSwordAmount = 1;
        bool collision = sword.OnCollision(player);
        int actualSwordAmount = player.inventory["sword"];
        Assert.AreEqual(expectedSwordAmount, actualSwordAmount);
    }

    [Test]
    public void SwordAddingToDamage()
    {
        int expectedAttack = 15;
        bool collision = sword.OnCollision(player);
        int actualAttack = player.Strength;
        Assert.AreEqual(expectedAttack, actualAttack);
    }

    [Test]
    public void SwordCollidingWithNonPlayer()
    {
        bool collision = sword.OnCollision(brute);
        Assert.IsFalse(collision);
    }
    
}
