using NUnit.Framework;
using DungeonCrawl.Actors.Characters;

public class BruteTest
{
    private Brute brute;
    private Player player;
    private Demon demon;
    private Skeleton skeleton;
    private Pig pig;

    [SetUp]
    public void init()
    {
        brute = new Brute();
        player = new Player();
        demon = new Demon();
        skeleton = new Skeleton();
        pig = new Pig();
    }

    [Test]
    public void DemonCanCollideWithBruteTest()
    {
        bool expected = true;
        bool result = brute.OnCollision(demon);
        Assert.AreEqual(expected, result);
    }

    [Test]
    public void PlayerCannotCollideWithBruteTest()
    {
        bool expected = false;
        bool result = brute.OnCollision(player);
        Assert.AreEqual(expected, result);
    }

    [Test]
    public void SkeletonCannotCollideWithBruteTest()
    {
        bool expected = false;
        bool result = brute.OnCollision(skeleton);
        Assert.AreEqual(expected, result);
    }
}
