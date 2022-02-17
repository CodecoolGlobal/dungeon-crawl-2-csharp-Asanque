using NUnit.Framework;
using DungeonCrawl.Actors.Characters;

public class SkeletonTest
{
    private Player player;
    private Demon demon;
    private Skeleton skeleton;

    [SetUp]
    public void init()
    {
        player = new Player();
        demon = new Demon();
        skeleton = new Skeleton();
    }

    [Test]
    public void SkeletonCannotCollideWithPlayerTest()
    {
        bool expected = false;
        bool result = skeleton.OnCollision(player);
        Assert.AreEqual(expected, result);
    }

    [Test]
    public void SkeletonCannotCollideWithDemonTest()
    {
        bool expected = false;
        bool result = skeleton.OnCollision(demon);
        Assert.AreEqual(expected, result);
    }

    [Test]
    public void SkeletonCannotCollideWithItselfTest()
    {
        bool expected = false;
        bool result = skeleton.OnCollision(skeleton);
        Assert.AreEqual(expected, result);
    }
}
