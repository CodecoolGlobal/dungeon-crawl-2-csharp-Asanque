using NUnit.Framework;
using DungeonCrawl.Actors.Characters;
using DungeonCrawl.Actors.Items;

public class ShieldTests
{
    private Player player;
    private Shield shield;
    private Brute brute;
    private Demon demon;

    [SetUp]
    public void Init()
    {
        player = new Player();
        shield = new Shield();
        brute = new Brute();
        demon = new Demon();
    }

    [Test]
    public void AddToPlayersShieldStat()
    {
        int expectedResult = 10;
        shield.OnCollision(player);
        Assert.AreEqual(expectedResult, player.Shield);
    }

    [Test]
    public void AddToPlayersInventory()
    {
        int expectedResult = 1;
        shield.OnCollision(player);
        Assert.AreEqual(expectedResult, player.inventory["shield"]);
    }

    [Test]
    public void ShieldGetsSteppedOnByDemon()
    {
        Assert.IsTrue(shield.OnCollision(demon));
    }

    [Test]
    public void ShieldGetsSteppedOnByNonDemonOrPlayer()
    {
        Assert.IsFalse(shield.OnCollision(brute));
    }
}