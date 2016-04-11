using UnityEngine;
using System.Collections;
using UnityEngine.UI;
public class RinkScript : MonoBehaviour {
    public Text Away=null;
    public Text Home=null;
    public bool leftTeam;
    public int hScore;
    public int aScore;
    private AudioSource audio;
    public GameObject[] entities;
	// Use this for initialization
	void Start () {
        string[] inputs = Input.GetJoystickNames();
        for(int i = 0; i < inputs.Length; i++) {
            print(inputs[i]);
        }
        Away = GameObject.FindGameObjectWithTag("Away").GetComponent<Text>(); 
        Home = GameObject.FindGameObjectWithTag("Home").GetComponent<Text>();
        audio = GetComponent<AudioSource>();
	}
	
	// Update is called once per frame
	void Update () {
	
	}

    void OnTriggerEnter2D(Collider2D coll) {
        if (coll.gameObject.tag == "ball")
        {
            print(leftTeam ? "Right team scored!" : "Left team scored!");
            if (leftTeam==false)
            {
                hScore += 1;
                Home.text = " " + hScore;

            }
            else
            {
                aScore += 1;
                Away.text = " " + aScore;
            }
            for(int i = 0; i < entities.Length; i++) {
                if(entities[i].GetComponent<PlayerScript>() != null) {
                    entities[i].transform.position = entities[i].GetComponent<PlayerScript>().startPos;
                    entities[i].GetComponent<Rigidbody2D>().velocity = Vector2.zero;
                }
                else {
                    entities[i].transform.position = entities[i].GetComponent<BallScript>().startPos;
                    entities[i].GetComponent<Rigidbody2D>().velocity = Vector2.zero;
                }
            }
        }
    }

    void OnCollisionEnter2D(Collision2D coll) {
        if(coll.gameObject.tag == "ball") {
            audio.Play();
        }
    }
}
