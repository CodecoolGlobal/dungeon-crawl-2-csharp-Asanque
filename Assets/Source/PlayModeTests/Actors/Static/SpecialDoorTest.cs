using NUnit.Framework;
using DungeonCrawl.Actors.Characters;
using DungeonCrawl.Actors.Static;

public class SpecialDoorTest
{
    private Player player;
    private Demon demon;
    private DoorSpecial door;
    private Skeleton skeleton;

    [SetUp]
    public void Init()
    {
        player = new Player();
        demon = new Demon();
        door = new DoorSpecial();
        skeleton = new Skeleton();
    }

    [Test]
    public void CollideWithPlayerWithSpecialKey()
    {
        player.inventory["specialKey"] = 12;
        Assert.IsTrue(door.OnCollision(player));
    }

    [Test]
    public void CollideWithPlayerWithKeyAndDecrementKeyAmount()
    {
        player.inventory["specialKey"] = 12;
        int expectedAmount = 11;
        door.OnCollision(player);
        Assert.AreEqual(expectedAmount, player.inventory["specialKey"]);
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