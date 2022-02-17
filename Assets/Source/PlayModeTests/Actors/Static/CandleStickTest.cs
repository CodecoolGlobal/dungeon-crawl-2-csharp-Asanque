using NUnit.Framework;
using DungeonCrawl.Actors.Characters;
using DungeonCrawl.Actors.Items;

public class CandleStickTest
{
    private Brute brute;
    private Player player;
    private Demon demon;
    private Candlesticks candlestick;

    [SetUp]
    public void Init()
    {
        brute = new Brute();
        player = new Player();
        demon = new Demon();
        candlestick = new Candlesticks();
    }

    [Test]
    public void CollideWithNonDemonCharacter()
    {
        Assert.IsFalse(candlestick.OnCollision(player));
    }

    [Test]
    public void CollideWithDemonCharacter()
    {
        Assert.IsTrue(candlestick.OnCollision(demon));
    }
}