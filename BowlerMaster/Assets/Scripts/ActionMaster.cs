using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.EventSystems;

public class ActionMaster
{

    public enum Action
    {
        Tidy,
        Reset,
        EndTurn,
        EndGame
    }

    private int[] _bowls = new int[21];
    private int _bowlId = 1;

    public Action Bowl(int pins)
    {
        if (pins < 0 || pins > 10) throw new ArgumentOutOfRangeException("pins");

        _bowls[_bowlId - 1] = pins;

        if (_bowlId == 21) return Action.EndGame;

        if (_bowlId >= 19 && pins == 10)
        {
            _bowlId++;
            return Action.Reset;
        }
        else if (_bowlId == 20)
        {
            _bowlId++;
            if (_bowls[18] == 10 && _bowls[19] == 0)
            {
                return Action.Tidy;
            }
            else if (_bowls[18] + _bowls[19] == 10)
            {
                return Action.Reset;
            }
            else if (_bowls[18] + _bowls[19] >= 10)
            {  // Roll 21 awarded
                return Action.Tidy;
            }
            else
            {
                return Action.EndGame;
            }
        }


        
        if (_bowlId % 2 != 0)
        {
            if (pins == 10)
            {
                _bowlId += 2;
                return Action.EndTurn;
            }
            else
            {
                _bowlId += 1;
                return Action.Tidy;
            }
        }
        else
        {
            _bowlId += 1;
            return Action.EndTurn;
        }

        throw new NotImplementedException();
    }

    private bool TwoStrikesLastFrame()
    {
        return (_bowls[19 - 1] + _bowls[20 - 1] ) % 10 == 0;
    }

    private bool Bowl21Awarded()
    {
        return _bowls[19 - 1] + _bowls[20 - 1] == 10;
    }
}
