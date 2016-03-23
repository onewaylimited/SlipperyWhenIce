using UnityEngine;
using System.Collections;

public class BallScript : MonoBehaviour {

    private bool followPlayer = false;
    public GameObject player;
    Rigidbody2D rb;
    public bool inPossession;
    public float followSpeed = 4;
    public PlayerScript play;
    private AudioSource source;


	// Use this for initialization
	void Start () {
        source = GetComponent<AudioSource>();
	}
	
	// Update is called once per frame
	void Update () {
        if (player != null && followPlayer)
        {
            
           follow();
        }
	}

    // Set if the ball should follow player anymore
    public void setFollow(bool followPlayer) {
        this.followPlayer = followPlayer;
    }

    void OnTriggerEnter2D(Collider2D coll)
    {
       
        if (coll.gameObject.tag == "player" && coll.isTrigger)
        {
            inPossession = true;
            player = coll.gameObject;
            play = (PlayerScript)player.GetComponent(typeof(PlayerScript));
            Physics2D.IgnoreCollision(GetComponent<Collider2D>(), play.boxCollider);  // Dont allow collisions with player box
            GetComponent<Rigidbody2D>().velocity = Vector2.zero;  // Set velocity to zero once entered trigger
            followPlayer = true;
        }
    }

    void OnTriggerExit2D(Collider2D coll)
    {
        if (coll.gameObject.tag == "player" && coll.isTrigger)
        {
            inPossession = false;
            player = null;
            play = null;
            followPlayer = false;
        }
    }

    void follow()
    {
        if (play.getBool()) {
            transform.position = new Vector3(player.GetComponent<Transform>().position.x + .5F, player.GetComponent<Transform>().position.y - .4F, player.GetComponent<Transform>().position.z);
        }
        else
            transform.position = new Vector3(player.GetComponent<Transform>().position.x - .5F, player.GetComponent<Transform>().position.y - .4F, player.GetComponent<Transform>().position.z);
    }
}
