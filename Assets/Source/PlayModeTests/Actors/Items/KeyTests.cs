using NUnit.Framework;
using DungeonCrawl.Actors.Characters;
using DungeonCrawl.Actors.Items;

public class KeyTests
{
    private Player player;
    private Key key;
    private Brute brute;
    private Demon demon;

    [SetUp]
    public void Init()
    {
        player = new Player();
        key = new Key();
        brute = new Brute();
        demon = new Demon();
    }

    [Test]
    public void PickedUpKeyIncrementsInventory()
    {
        player.inventory["key"] = 3;
        int expectedKeyAMount = 4;
        key.OnCollision(player);
        Assert.AreEqual(expectedKeyAMount, player.inventory["key"]);
    }

    [Test]
    public void CollideWithDemon()
    {
        Assert.IsTrue(key.OnCollision(demon));
    }

    [Test]
    public void CollideWithNonDemonOrPlayer()
    {
        Assert.IsFalse(key.OnCollision(brute));
    }
}