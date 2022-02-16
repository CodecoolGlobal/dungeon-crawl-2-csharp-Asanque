using NUnit.Framework;
using DungeonCrawl.Actors.Characters;
using DungeonCrawl.Actors.Items;

public class SpecialKeyTests
{
    private Player player;
    private KeySpecial key;
    private Brute brute;
    private Demon demon;

    [SetUp]
    public void Init()
    {
        player = new Player();
        key = new KeySpecial();
        brute = new Brute();
        demon = new Demon();
    }

    [Test]
    public void PickedUpKeyIncrementsInventory()
    {
        player.inventory["specialKey"] = 1987;
        int expectedKeyAMount = 1988;
        key.OnCollision(player);
        Assert.AreEqual(expectedKeyAMount, player.inventory["specialKey"]);
    }

    [Test]
    public void CollideWithDemon()
    {
        Assert.IsFalse(key.OnCollision(demon));
    }

    [Test]
    public void CollideWithNonDemonOrPlayer()
    {
        Assert.IsFalse(key.OnCollision(brute));
    }
}