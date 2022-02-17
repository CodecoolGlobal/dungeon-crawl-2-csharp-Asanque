using NUnit.Framework;
using DungeonCrawl.Actors.Characters;
using DungeonCrawl.Actors.Static;

public class SpecialWallTest
{
    private Player player;
    private Demon demon;
    private WallSpecial wall;
    private Skeleton skeleton;

    [SetUp]
    public void Init()
    {
        player = new Player();
        demon = new Demon();
        wall = new WallSpecial();
        skeleton = new Skeleton();
    }

    [Test]
    public void PlayerCollidesWithWall()
    {
        Assert.IsTrue(wall.OnCollision(player));
    }

    [Test]
    public void NonPlayerAndNonDemonCollidesWithWall()
    {
        Assert.IsFalse(wall.OnCollision(skeleton));
    }

    [Test]
    public void DemonCollidesWithWall()
    {
        Assert.IsTrue(wall.OnCollision(demon));
    }
}