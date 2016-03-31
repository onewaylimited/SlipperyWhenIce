using UnityEngine;
using System.Collections;

public class Goalie_Script : MonoBehaviour
{

	

    public GameObject ball = null;
    private GameObject player = null;
    private bool dangerZone = false;
    public int moveSpeed = 7;
    public bool facingRight = true;
    Vector3 goaliePos1 = new Vector3(-8.75F, -.7F, -.16F);
    Vector3 goaliePos2 = new Vector3(9.6F, -.7F, -.16F);
    // Use this for initialization
    void Start()
    {
        player = this.gameObject;
        if (!facingRight)
        {
            Flip();
            facingRight = !facingRight;
        }
        //sets Goalie position
        if (facingRight)
        {
            player.transform.position = goaliePos1; 
        }
        else
        {
            player.transform.position = goaliePos2;
        }
    }

    // Update is called once per frame
    void Update()
    {
        if (dangerZone)
        {
            Block();
        }

        if( player.transform.position.y > 1 || player.transform.position.y < -1 && facingRight)
        {
            player.transform.position = goaliePos1;
        }
        else if (player.transform.position.y > 1 || player.transform.position.y < -1 && !facingRight)
        {
            player.transform.position = goaliePos2;
        }

        if (player.transform.position.x < 8.8 || player.transform.position.x > 8.7 && facingRight)
        {
            player.transform.position = goaliePos1;
        }
        else if(player.transform.position.x < 9.55 || player.transform.position.x > 9.65 && !facingRight)
        {
            player.transform.position = goaliePos2;
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
    void Flip()
    {
        // Change direction facing
        facingRight = !facingRight;

        // Flip the scale of the Character
        Vector3 charScale = player.transform.localScale;
        charScale.x *= -1;
        player.transform.localScale = charScale;
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
