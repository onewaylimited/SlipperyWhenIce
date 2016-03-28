using UnityEngine;
using UnityEngine.UI;
using System.Collections;

/*
 * Holds user account information so we
 * know who's logged indexer.
 */
public class UserAccount : MonoBehaviour {
	private bool loggedIn = false;

	private int uID;
	private string username;

    /// <summary>
    /// This string gets changed on each successful login and is
    /// used to validate the player.
    /// </summary>
    private string sessionCode;

    /// <summary>
    /// Records the instance of UserAccount that gets created.
    /// This is so we can access non-static variables that are
    /// used to save scene objects (Like InputField and Text objects)
    /// </summary>
    public static UserAccount instance;
    private void Awake() {
        instance = this;
    }

    public static UserAccount getInstance() {
        return instance;
    }

	public int getUID() {
		return uID;
	}

	public string getUsername() {
		return username;
	}

	public string getSessionCode() {
		return sessionCode;
	}

	public bool isLoggedIn() {
		return loggedIn;
	}

	GameObject LogIn;
	GameObject LogOut;
	private void Start() {
		LogIn = transform.GetChild(0).gameObject;
		LogOut = transform.GetChild(1).gameObject;
	}

	public void logIn() {
        LogIn.SetActive(false);
        LogOut.SetActive(true);
	}

    public void logOut() {
        LogIn.SetActive(true);
        LogOut.SetActive(false);
    }
}
