using UnityEngine;
using System.Collections;

public class Scoreboard : MonoBehaviour {
    public static int pointScore = 0;
    // Use this for initialization
    void onGUI()
    {
        GUI.Label(new Rect(10, 10, 100, 20), "Score: " + pointScore);

    }
}
