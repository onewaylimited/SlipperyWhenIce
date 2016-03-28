using UnityEngine;
using System.Collections;

public class Goalie_Script : MonoBehaviour
{

	

    public GameObject ball = null;
    private GameObject player = null;
    private bool dangerZone = false;
    public int moveSpeed = 7;
    // Use this for initialization
    void Start()
    {
        player = this.gameObject;
    }

    // Update is called once per frame
    void Update()
    {
        if (dangerZone)
        {
            Block();
        }

        if( player.transform.position.y > 1 || player.transform.position.y < -1)
        {
            player.transform.position = new Vector3(player.transform.position.x, -.7F, player.transform.position.z);
        }

        if(player.transform.position.x < 8.8 || player.transform.position.x > 8.7)
        {
            player.transform.position = new Vector3( -8.75F, -.7F, player.transform.position.z);
        }
    }

    void OnTriggerEnter2D(Collider2D coll)
    {

        if (coll.gameObject.tag == "ball")
        {
            //ball is nearby
            ball = coll.gameObject;
            dangerZone = true;
        }
    }


    void OnTriggerExit2D(Collider2D coll)
    {
        if (coll.gameObject.tag == "ball")
        {
            ball = null;
            dangerZone = false;
        }
    }
    void Block()
    {
        if (ball.GetComponent<Transform>().position.y > player.GetComponent<Transform>().position.y)
        {
            player.GetComponent<Rigidbody2D>().AddForce(new Vector3(0, moveSpeed, 0));
        }
        else if (ball.GetComponent<Transform>().position.y < player.GetComponent<Transform>().position.y)
        {
            player.GetComponent<Rigidbody2D>().AddForce(new Vector3(0, -moveSpeed, 0));
        }
    }
}
