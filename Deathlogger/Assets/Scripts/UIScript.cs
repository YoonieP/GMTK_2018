using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class UIScript : MonoBehaviour {
    private int points = 0;
    public Text text;

    public void increasePoints(int plusPoints)
    {
        points += plusPoints;
        text.text = ""+points;
    }
}
