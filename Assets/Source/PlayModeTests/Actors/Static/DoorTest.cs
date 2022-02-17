using NUnit.Framework;
using DungeonCrawl.Actors.Characters;
using DungeonCrawl.Actors.Static;

public class DoorTest
{
    private Player player;
    private Demon demon;
    private Door door;
    private Skeleton skeleton;

    [SetUp]
    public void Init()
    {
        player = new Player();
        demon = new Demon();
        door = new Door();
        skeleton = new Skeleton();
    }

    [Test]
    public void CollideWithPlayerWithKey()
    {
        player.inventory["key"] = 12;
        Assert.IsTrue(door.OnCollision(player));
    }

    [Test]
    public void CollideWithPlayerWithKeyAndDecrementKeyAmount()
    {
        player.inventory["key"] = 12;
        int expectedAmount = 11;
        door.OnCollision(player);
        Assert.AreEqual(expectedAmount, player.inventory["key"]);
    }

    [Test]
    public void CollideWithPlayerWithoutKey()
    {
        Assert.IsFalse(door.OnCollision(player));
    }

    [Test]
    public void CollideWithDemon()
    {
        Assert.IsTrue(door.OnCollision(demon));
    }

    [Test]
    public void CollideWithSkeleton()
    {
        Assert.IsFalse(door.OnCollision(skeleton));
    }

    //Brutes can't walk. No test for them. Hashtag sadface.
}