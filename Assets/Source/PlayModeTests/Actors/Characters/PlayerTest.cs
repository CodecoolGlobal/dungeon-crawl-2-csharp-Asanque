using NUnit.Framework;
using DungeonCrawl.Actors.Characters;
using DungeonCrawl.Actors;

public class PlayerTest
{
    private Player player;
    private Actor actor;

    [SetUp]
    public void init()
    {
        player = new Player();
    }

    [Test]
    public void PlayerIsPlayerTest()
    {
        bool expected = true;
        bool result = player.IsPlayer();
        Assert.AreEqual(expected, result);
    }

    [Test]
    public void PlayerHasKeyTest()
    {
        player.inventory["key"] = 1;
        bool expected = true;
        bool result = player.HasKey("key");
        Assert.AreEqual(expected, result);

        player.inventory["key"] = 0;
        expected = false;
        result = player.HasKey("key");
        Assert.AreEqual(expected, result);
    }

    [Test]
    public void BruteIsAttackableTest()
    {
        actor = new Brute();
        bool expected = true;
        bool result = player.Attackable(actor);
        Assert.AreEqual(expected, result);
    }
    
    [Test]
    public void SkeletonIsAttackableTest()
    {
        actor = new Skeleton();
        bool expected = true;
        bool result = player.Attackable(actor);
        Assert.AreEqual(expected, result);
    }

    [Test]
    public void DemontIsAttackableTest()
    {
        actor = new Demon();
        bool expected = true;
        bool result = player.Attackable(actor);
        Assert.AreEqual(expected, result);
    }

    [Test]
    public void HealthAddedToPlayerStatTest()
    {
        int expected = 100;
        player.Health = 0;
        player.AddToStat(Stats.Health, 100);
        int result = player.Health;
        Assert.AreEqual(expected, result);
    }

    [Test]
    public void StrengthAddedToPlayerStatTest()
    {
        int expected = 50;
        player.Strength = 0;
        player.AddToStat(Stats.Strength, 50);
        int result = player.Strength;
        Assert.AreEqual(expected, result);
    }
    
    [Test]
    public void ShieldAddedToPlayerStatTest()
    {
        int expected = 5;
        player.Shield = 0;
        player.AddToStat(Stats.Shield, 5);
        int result = player.Shield;
        Assert.AreEqual(expected, result);
    }
}
