using UnityEngine;
using UnityEngine.UI;
using System.Collections;

public class Register : MonoBehaviour {
    private static string URL = "https://classdb.it.mtu.edu/~arfanten/SuperBroomball/register.php";

    public InputField usernameInput;
    public InputField passwordInput;
    public Button loginButton;

    public void pressed() {
        string name = usernameInput.text;
        string pass = passwordInput.text;

        if(name.Length == 0) {
            Feedback.setFeedback("Enter a username");
        } else if(pass.Length == 0) {
            Feedback.setFeedback("Enter a password");
        } else {
            StartCoroutine(registerAccount(name, pass));
        }
    }

    private static IEnumerator registerAccount(string name, string pass) {
        string hashedPass = MD5Hash.Md5Sum(pass);

        WWWForm form = new WWWForm();
        form.AddField("username", name);
        form.AddField("password", hashedPass);

        WWW download = new WWW(URL, form);
        yield return download;

        if (!string.IsNullOrEmpty(download.error)) {
            Debug.Log("Error: " + download.error);
            Feedback.setFeedback("Error"); // Don't want to attach download.error here, it's too long
        } else {
            Debug.Log(download.text);
            Feedback.setFeedback(download.text);

            if(download.text == "Account created") {
                Debug.Log("Created account successfully");
                // Uncomment this after i actually implement the login button
                //loginButton.onClick.Invoke();
            }
        }
    }
}
