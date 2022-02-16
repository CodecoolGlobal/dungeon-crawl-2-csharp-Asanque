using NUnit.Framework;
using DungeonCrawl.Actors.Characters;
using DungeonCrawl.Actors.Items;

public class SmallHealthPotionTests
{
    private Player player;
    private SmallHealth potion;
    private Brute brute;
    private Demon demon;

    [SetUp]
    public void Init()
    {
        player = new Player();
        potion = new SmallHealth();
        brute = new Brute();
        demon = new Demon();
    }

    [Test]
    public void PickedUpByPlayerWithFiftyHealth()
    {
        int expectedHealth = 60;
        player.Health = 50;
        potion.OnCollision(player);
        Assert.AreEqual(expectedHealth, player.Health);
    }

    [Test]
    public void PickedUpByPlayerWithOverNinetyHealth()
    {
        int expectedHealth = 100;
        player.Health = 95;
        potion.OnCollision(player);
        Assert.AreEqual(expectedHealth, player.Health);
    }

    [Test]
    public void SteppedOnByDemon()
    {
        Assert.IsTrue(potion.OnCollision(demon));
    }

    [Test]
    public void SteppedOnByNonDemonOrPlayer()
    {
        Assert.IsFalse(potion.OnCollision(brute));
    }
}