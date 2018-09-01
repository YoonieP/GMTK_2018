using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class UIScript : MonoBehaviour {
    private int points = 0;
    public TextMesh text;

    public void increasePoints(int plusPoints)
    {
        points += plusPoints;
        text.text = ""+points;
    }

    public void disableText()
    {
        enabled = false;
    }

    public int getPoints()
    {
        return points;
    }
}
