using UnityEngine;
using UnityEngine.UI;
using System.Collections;

public class Login : MonoBehaviour {
    private static string URL = "https://classdb.it.mtu.edu/~arfanten/SuperBroomball/login.php";

    public InputField usernameInput;
    public InputField passwordInput;

    public void pressed() {
        string name = usernameInput.text;
        string pass = passwordInput.text;

        if (name.Length == 0) {
            Feedback.setFeedback("Enter a username");
        } else if (pass.Length == 0) {
            Feedback.setFeedback("Enter a password");
        } else {
            StartCoroutine(loginAccount(name, pass));
        }
    }

    private static IEnumerator loginAccount(string name, string pass) {
        string hashedPass = MD5Hash.Md5Sum(pass);

        WWWForm form = new WWWForm();
        form.AddField("username", name);
        form.AddField("password", hashedPass);

        WWW download = new WWW(URL, form);
        yield return download;

        if (!string.IsNullOrEmpty(download.error)) {
            Debug.Log("Error: " + download.error);
            Feedback.setFeedback("Error"); // Don't want to attach download.error here, it's too long
        } else if (download.text == "Invalid username/password") {
            Debug.Log(download.text);
            Feedback.setFeedback(download.text);
        } else if (download.text.StartsWith("Success:")) {
            Debug.Log(download.text);

            UserAccount.getInstance().logIn(name, download.text.Substring(9));
        } else {
            Debug.Log(download.text);
            Debug.Log("Couldn't log in");
        }
    }
}
