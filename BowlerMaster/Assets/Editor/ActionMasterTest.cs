using System.Collections;
using System.Collections.Generic;
using System.Linq;
using NUnit.Framework;
using UnityEngine;

[TestFixture]
public class ActionMasterTest
{
    private ActionMaster _actionMaster;

    [SetUp]
    public void Setup()
    {
        _actionMaster = new ActionMaster();
    }

    [Test]
    public void OneStrikeReturnsEndTurn()
    {
        Assert.AreEqual(ActionMaster.Action.EndTurn, _actionMaster.Bowl(10));
    }

    [Test]
    public void Bowl8ReturnsTidy()
    {
        Assert.AreEqual(ActionMaster.Action.Tidy, _actionMaster.Bowl(8));
    }

    [Test]
    public void Bowl28ReturnsEndTurn()
    {
        _actionMaster.Bowl(2);
        Assert.AreEqual(ActionMaster.Action.EndTurn, _actionMaster.Bowl(8));
    }

    [Test]
    public void CheckResetAtStrikeInLastFrame()
    {
        int[] rolls = Enumerable.Repeat(1, 18).ToArray();
        foreach (var roll in rolls)
        {
            _actionMaster.Bowl(roll);
        }
        Assert.AreEqual(ActionMaster.Action.Reset, _actionMaster.Bowl(10));
    }

    [Test]
    public void CheckResetAtSpareInLastFrame()
    {
        int[] rolls = Enumerable.Repeat(1, 18).ToArray();
        foreach (var roll in rolls)
        {
            _actionMaster.Bowl(roll);
        }
        _actionMaster.Bowl(1);
        Assert.AreEqual(ActionMaster.Action.Reset, _actionMaster.Bowl(9));
    }

    [Test]
    public void Turkey()
    {
        int[] rolls = Enumerable.Repeat(1, 18).ToArray();
        foreach (var roll in rolls)
        {
            _actionMaster.Bowl(roll);
        }
        Assert.AreEqual(ActionMaster.Action.Reset, _actionMaster.Bowl(10));
        Assert.AreEqual(ActionMaster.Action.Reset, _actionMaster.Bowl(10));
        Assert.AreEqual(ActionMaster.Action.EndGame, _actionMaster.Bowl(10));
    }

    [Test]
    public void YouTubeRollsEndInEndGame()
    {
        int[] rolls = { 8, 2, 7, 3, 3, 4, 10, 2, 8, 10, 10, 8, 0, 10, 8, 2 };
        foreach (var roll in rolls)
        {
            _actionMaster.Bowl(roll);
        }
        Assert.AreEqual(ActionMaster.Action.EndGame, _actionMaster.Bowl(9));
    }

    [Test]
    public void GameEndsAtBowl20()
    {
        int[] rolls = Enumerable.Repeat(1, 19).ToArray();
        foreach (var roll in rolls)
        {
            _actionMaster.Bowl(roll);
        }
        Assert.AreEqual(ActionMaster.Action.EndGame, _actionMaster.Bowl(1));
    }

    [Test]
    public void DarylBowl20Test()
    {
        int[] rolls = Enumerable.Repeat(1, 18).ToArray();
        foreach (var roll in rolls)
        {
            _actionMaster.Bowl(roll);
        }

        _actionMaster.Bowl(10);
        Assert.AreEqual(ActionMaster.Action.Tidy, _actionMaster.Bowl(5));
    }

    [Test]
    public void BenBowl20Test()
    {
        int[] rolls = Enumerable.Repeat(1, 18).ToArray();
        foreach (var roll in rolls)
        {
            _actionMaster.Bowl(roll);
        }

        _actionMaster.Bowl(10);
        Assert.AreEqual(ActionMaster.Action.Tidy, _actionMaster.Bowl(0));
    }

    [Test]
    public void NathanBowlTest()
    {
        int[] rolls = {0, 10, 5};
        foreach (var roll in rolls)
        {
            _actionMaster.Bowl(roll);
        }
        Assert.AreEqual(ActionMaster.Action.EndTurn, _actionMaster.Bowl(1));
    }
}
