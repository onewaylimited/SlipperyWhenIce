using UnityEngine;
using System.Collections;

public class TestCalling : MonoBehaviour {

	private string URL = "https://classdb.it.mtu.edu/~arfanten/SuperBroomball/test.php";

	// Use this for initialization
	void Start () {
		StartCoroutine (GetStats ());
	}
		
	IEnumerator GetStats () {
		Debug.Log ("GetStats");

		//WWWForm form = new WWWForm ();

		//WWW call = new WWW(URL , form);

		WWW www = new WWW (URL);
		yield return www;

		//yield return call;
	}
}