using UnityEngine;
using System.Collections;

public class UpdateStats : MonoBehaviour {
    private static string URL = "https://classdb.it.mtu.edu/~arfanten/SuperBroomball/update.php";

    private static string getUsername() {
        return UserAccount.getUsername();
    }

    private static string getSessionCode() {
        return UserAccount.getSessionCode();
    }

    private static bool loggedIn() {
        return UserAccount.isLoggedIn();
    }

    public static void goal() {
        if (loggedIn()) {
            WWWForm form = new WWWForm();
            form.AddField("id", 1);
            form.AddField("username", getUsername());
            form.AddField("session", getSessionCode());

            UserAccount.getInstance().StartCoroutine(updateAccount(form));
        }
    }

    public static void game_win() {
        if (loggedIn()) {
            WWWForm form = new WWWForm();
            form.AddField("id", 2);
            form.AddField("username", getUsername());
            form.AddField("session", getSessionCode());

            UserAccount.getInstance().StartCoroutine(updateAccount(form));
        }
    }

    public static void game_lost() {
        if (loggedIn()) {
            WWWForm form = new WWWForm();
            form.AddField("id", 3);
            form.AddField("username", getUsername());
            form.AddField("session", getSessionCode());

            UserAccount.getInstance().StartCoroutine(updateAccount(form));
        }
    }

    private static IEnumerator updateAccount(WWWForm form) {
        if (UserAccount.isLoggedIn()) {
            WWW download = new WWW(URL, form);
            yield return download;

            if (!string.IsNullOrEmpty(download.error)) {
                Debug.Log("Error updating account: " + download.error);
            } else if (download.text == "Success") {
                Debug.Log("Successfully updated account");
            }
        }
    }
}
