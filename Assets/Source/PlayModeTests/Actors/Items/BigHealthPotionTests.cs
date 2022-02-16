using NUnit.Framework;
using DungeonCrawl.Actors.Characters;
using DungeonCrawl.Actors.Items;

public class BigHealthPotionTests
{
    private Player player;
    private BigHealth potion;
    private Brute brute;
    private Demon demon;

    [SetUp]
    public void Init()
    {
        player = new Player();
        potion = new BigHealth();
        brute = new Brute();
        demon = new Demon();
    }

    [Test]
    public void PickedUpByPlayerWithAnyHealth()
    {
        int expectedHealth = 100;
        player.Health = 17;
        potion.OnCollision(player);
        Assert.AreEqual(expectedHealth, player.Health);
    }

    [Test]
    public void PickedUpByPlayerWithMaxHealth()
    {
        int expectedHealth = 100;
        player.Health = 100;
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