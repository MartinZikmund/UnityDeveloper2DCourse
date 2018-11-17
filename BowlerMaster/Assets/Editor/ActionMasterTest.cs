using System.Collections;
using System.Collections.Generic;
using System.Linq;
using NUnit.Framework;
using UnityEditorInternal;
using UnityEngine;

[TestFixture]
public class ActionMasterTest
{
    private List<int> _pinFalls;
    [SetUp]
    public void Setup()
    {
        _pinFalls = new List<int>();
    }

    [Test]
    public void OneStrikeReturnsEndTurn()
    {
        _pinFalls.Add(10);
        Assert.AreEqual(ActionMaster.Action.EndTurn, ActionMaster.NextAction(_pinFalls));
    }

    [Test]
    public void Bowl8ReturnsTidy()
    {
        _pinFalls.Add(8);
        Assert.AreEqual(ActionMaster.Action.Tidy, ActionMaster.NextAction(_pinFalls));
    }

    [Test]
    public void Bowl28ReturnsEndTurn()
    {
        _pinFalls.AddRange(new[] { 2, 8 });
        Assert.AreEqual(ActionMaster.Action.EndTurn, ActionMaster.NextAction(_pinFalls));
    }

    [Test]
    public void CheckResetAtStrikeInLastFrame()
    {
        int[] rolls = Enumerable.Repeat(1, 18).ToArray();
        _pinFalls.AddRange(rolls);
        _pinFalls.Add(10);
        Assert.AreEqual(ActionMaster.Action.Reset, ActionMaster.NextAction(_pinFalls));
    }

    [Test]
    public void CheckResetAtSpareInLastFrame()
    {
        int[] rolls = Enumerable.Repeat(1, 18).ToArray();
        _pinFalls.AddRange(rolls);
        _pinFalls.Add(1);
        _pinFalls.Add(9);
        Assert.AreEqual(ActionMaster.Action.Reset, ActionMaster.NextAction(_pinFalls));
    }

    [Test]
    public void Turkey()
    {
        int[] rolls = Enumerable.Repeat(1, 18).ToArray();
        _pinFalls.AddRange(rolls);
        _pinFalls.Add(10);
        Assert.AreEqual(ActionMaster.Action.Reset, ActionMaster.NextAction(_pinFalls));
        _pinFalls.Add(10);
        Assert.AreEqual(ActionMaster.Action.Reset, ActionMaster.NextAction(_pinFalls));
        _pinFalls.Add(10);
        Assert.AreEqual(ActionMaster.Action.EndGame, ActionMaster.NextAction(_pinFalls));
    }

    [Test]
    public void YouTubeRollsEndInEndGame()
    {
        int[] rolls = { 8, 2, 7, 3, 3, 4, 10, 2, 8, 10, 10, 8, 0, 10, 8, 2 };
        _pinFalls.AddRange(rolls);
        _pinFalls.Add(9);
        Assert.AreEqual(ActionMaster.Action.EndGame, ActionMaster.NextAction(_pinFalls));
    }

    [Test]
    public void GameEndsAtBowl20()
    {
        int[] rolls = Enumerable.Repeat(1, 19).ToArray();
        _pinFalls.AddRange(rolls);
        _pinFalls.Add(1);
        Assert.AreEqual(ActionMaster.Action.EndGame, ActionMaster.NextAction(_pinFalls));
    }

    [Test]
    public void DarylBowl20Test()
    {
        int[] rolls = Enumerable.Repeat(1, 18).ToArray();
        _pinFalls.AddRange(rolls);
        _pinFalls.Add(10);
        _pinFalls.Add(5);
        Assert.AreEqual(ActionMaster.Action.Tidy, ActionMaster.NextAction(_pinFalls));
    }

    [Test]
    public void BenBowl20Test()
    {
        int[] rolls = Enumerable.Repeat(1, 18).ToArray();
        _pinFalls.AddRange(rolls);
        _pinFalls.Add(10);
        _pinFalls.Add(0);
        Assert.AreEqual(ActionMaster.Action.Tidy, ActionMaster.NextAction(_pinFalls));
    }

    [Test]
    public void NathanBowlTest()
    {
        int[] rolls = { 0, 10, 5 };
        _pinFalls.AddRange(rolls);
        _pinFalls.Add(1);
        Assert.AreEqual(ActionMaster.Action.EndTurn, ActionMaster.NextAction(_pinFalls));
    }
}
