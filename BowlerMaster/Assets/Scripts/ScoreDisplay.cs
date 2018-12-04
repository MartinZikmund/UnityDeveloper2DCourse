using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using UnityEngine;
using UnityEngine.UI;

public class ScoreDisplay : MonoBehaviour
{

    private Text[] _bowlTexts;
    private Text[] _scoreTexts;

    // Use this for initialization
    void Start()
    {
        FindAllFrames();
    }

    private void FindAllFrames()
    {
        var allTexts = gameObject.GetComponentsInChildren<Text>();
        _bowlTexts = allTexts.Where(c => c.gameObject.name.StartsWith("Bowl")).ToArray();
        _scoreTexts = allTexts.Where(c => c.gameObject.name.StartsWith("Score")).ToArray();
        foreach (var text in allTexts)
        {
            text.text = "";
        }
    }

    // Update is called once per frame
    void Update()
    {

    }

    public void FillRollCard(List<int> rolls)
    {
        for (int i = 0; i < rolls.Count; i++)
        {
            _bowlTexts[i].text = rolls[i].ToString();
        }
    }

    public void FillFrames(List<int> frames)
    {
        for (int i = 0; i < frames.Count; i++)
        {
            _scoreTexts[i].text = frames[i].ToString();
        }
    }

    public static string FormatRolls(List<int> rolls)
    {
        string output = "";
        for (int i = 0; i < rolls.Count; i++)
        {
            int box = output.Length + 1;
            if (rolls[i] == 0)
            {
                output += "-";
            }
            else if (box >= 19 && rolls[i] == 10)
            {
                output += "X";
            } else if (rolls[i] == 10)
            {
                output += "X ";
            }
            else if ((box % 2 == 0 || box == 21 ) && rolls[i - 1] + rolls[i] == 10)
            {
                output += "/";
            }
            else
            {
                output += rolls[i].ToString();
            }
        }
        return output;
    }
}
