using UnityEngine;
using UnityEngine.UI;
using System.Collections;

/// <summary>
/// Not using this class, might go back to it later though
/// </summary>
public class Feedback : MonoBehaviour {
    public Text feedbackString;

    private static Feedback instance;
    private void Awake() {
        instance = this;
    }

    public static void setFeedback(string str) {
        instance.feedbackString.text = "*" + str + "*";
    }

    public static string getFeedback() {
        return instance.feedbackString.text;
    }
}
