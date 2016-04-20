using UnityEngine;
using UnityEngine.UI;
using System.Collections;

public class SimpleLeaderboard : MonoBehaviour {
    private static string URL = "https://classdb.it.mtu.edu/~arfanten/SuperBroomball/topfive.php";

    public Text[] leaders;
    
    /// <summary>
    /// Called when the scene is loaded.
    /// Set the leaderboards to be the top 5 players in games won
    /// </summary>
	void Awake () {
        StartCoroutine(UpdateBoard());
	}

    /// <summary>
    /// Actually gets the data from the database and updates the texts.
    /// 
    /// This isn't done perfectly, it could be improved on by checking
    /// for bad data being returned from the database.
    /// </summary>
    /// <returns></returns>
    private IEnumerator UpdateBoard() {
        WWWForm form = new WWWForm();
        form.AddField("limit", 5); // Doesn't actually work right now

        WWW download = new WWW(URL, form);
        yield return download;

        if (!string.IsNullOrEmpty(download.error)) {
            Debug.Log("Error: " + download.error);
        } else if (download.text.StartsWith("Start||")) {
            Debug.Log(download.text);

            string[] firstSeperator = new string[] { "||" };
            string[] secondSeperator = new string[] { "|:|" };

            string[] firstResult = download.text.Split(firstSeperator, System.StringSplitOptions.None);
            Debug.Log(firstResult.Length);
            if (firstResult.Length == 6) {
                for (int i = 1; i < 6; i++) {
                    string[] secondResult = firstResult[i].Split(secondSeperator, System.StringSplitOptions.None);
                    leaders[i - 1].text = secondResult[0] + "\t" + secondResult[1] + "\t" + secondResult[2] + "\t" + secondResult[3];
                    //Debug.Log(leaders[i - 1].text);
                }
            }


        } else {
            Debug.Log(download.text);
            Debug.Log("Couldn't get leaderboard");
        }
    }
}
