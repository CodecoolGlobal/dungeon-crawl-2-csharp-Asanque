using NUnit.Framework;
using DungeonCrawl.Actors.Characters;
using DungeonCrawl.Actors.Static;

public class HiddenFloorTest
{
    private Player player;
    private Demon demon;
    private FloorHidden floor;

    [SetUp]
    public void Init()
    {
        player = new Player();
        demon = new Demon();
        floor = new FloorHidden();
    }

    [Test]
    public void PlayerStepsOnFloor()
    {
        Assert.IsTrue(floor.OnCollision(player));
    }

    [Test]
    public void NonPlayerStepsOnFloor()
    {
        Assert.IsFalse(floor.OnCollision(demon));
    }
}