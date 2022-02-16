using System.Collections;
using System.Collections.Generic;
using NUnit.Framework;
using UnityEngine;
using UnityEngine.TestTools;
using DungeonCrawl.Actors.Characters;
using DungeonCrawl;
using DungeonCrawl.Core;
using DungeonCrawl.Actors;
using DungeonCrawl.Actors.Static;
using Assets.Source.Actors;

public class NewTestScript
{
    private Player player;
    private Brute brute;
    [SetUp]
    // A Test behaves as an ordinary method
    public void Setup()
    {
    }

    [Test]
    public void NewTestScriptSimplePasses()
    {
        player = new GameObject().AddComponent<Player>();
        
        // Use the Assert class to test conditions
    }

    // A UnityTest behaves like a coroutine in Play Mode. In Edit Mode you can use
    // `yield return null;` to skip a frame.
    [UnityTest]
    public IEnumerator NewTestScriptWithEnumeratorPasses()
    {
        // Use the Assert class to test conditions.
        // Use yield to skip a frame.
        yield return null;
    }
}
