using NUnit.Framework;
using DungeonCrawl.Actors.Characters;

public class DemonTest
{
    private Player player;
    private Demon demon;

    [SetUp]
    public void init()
    {
        player = new Player();
        demon = new Demon();
    }

    [Test]
    public void DemonCanCollideWithPlayerTest()
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
}
