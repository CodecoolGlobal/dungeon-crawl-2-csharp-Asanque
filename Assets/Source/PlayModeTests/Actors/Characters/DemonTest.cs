using NUnit.Framework;
using DungeonCrawl.Actors.Characters;
using DungeonCrawl.Actors.Static;

public class DemonTest
{
    private Player player;
    private Demon demon;
    private Wall wall;

    [SetUp]
    public void init()
    {
        player = new Player();
        demon = new Demon();
        wall = new Wall();
    }

    [Test]
    public void DemonCannotCollideWithPlayerTest()
    {
        bool expected = false;
        bool result = demon.OnCollision(player);
        Assert.AreEqual(expected, result);
    }

    [Test]
    public void DemonCannotCollideWithItselfTest()
    {
        bool expected = false;
        bool result = demon.OnCollision(demon);
        Assert.AreEqual(expected, result);
    }

    [Test]
    public void DemonCanCollideWithWallTest()
    {
        bool expected = true;
        bool result = demon.OnCollision(wall);
        Assert.AreEqual(expected, result);
    }
}
