using UnityEngine;
using UnityEngine.UI;
using System.Collections;

/*
 * Holds user account information so we
 * know who's logged in.
 */
public class UserAccount : MonoBehaviour {
    private static bool loggedIn = false;

    public Text usernameText;
    public GameObject userManager;
    public GameObject logInObject;
    public GameObject logOutObject;

    private static string username;
    private static string sessionCode;

    /// <summary>
    /// Records the instance of UserAccount that gets created.
    /// This is so we can access non-static variables that are
    /// used to save scene objects (Like InputField and Text objects)
    /// </summary>
    public static UserAccount instance;
    private void Awake() {
        instance = this;

        DontDestroyOnLoad(userManager);
    }

    public static UserAccount getInstance() {
        return instance;
    }

    public static string getUsername() {
        return username;
    }

    public static string getSessionCode() {
        return sessionCode;
    }

    public static bool isLoggedIn() {
        return loggedIn;
    }

    static GameObject LogInObject;
    static GameObject LogOutObject;
    private void Start() {
        //LogInObject = transform.GetChild(0).gameObject;
        //LogOutObject = transform.GetChild(1).gameObject;
    }

    public void logIn(string name, string code) {
        logInObject.SetActive(false);
        logOutObject.SetActive(true);

        username = name;
        sessionCode = code;

        loggedIn = true;

        usernameText.text = "Hello: " + username;

        //UpdateStats.goal();
        //UpdateStats.game_win();
        //UpdateStats.game_lost();
    }

    public void logOut() {
        logInObject.SetActive(true);
        logOutObject.SetActive(false);

        username = "";
        sessionCode = "";

        loggedIn = false;
    }
}
