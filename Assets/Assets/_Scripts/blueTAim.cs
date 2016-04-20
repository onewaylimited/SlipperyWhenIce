using UnityEngine;
using System.Collections;

public class blueTAim : MonoBehaviour
{
    public string rxAxis = "P2SX";
    public string ryAxis = "P2SY";
    public string xaxis = "P2X";
    public string yaxis = "P2Y";
    public Sprite sprite;
    GameObject px;
    public float dirX;
    public float dirY;
    public PlayerScript psript;
    void Start()
    {

        GetComponent<SpriteRenderer>().enabled = false;
        px = GameObject.Find("Blue_2");

    }

    void Update()
    {
        psript = px.GetComponent<PlayerScript>();



        dirX = Input.GetAxis(rxAxis);
        dirY = Input.GetAxis(ryAxis);
        float pDirX = px.transform.position.x;


        float pDirY = px.transform.position.y;
        if (dirX > .3 || dirY > .3 || dirX < -.3 || dirY < -.3)
        {
            if (psript.controlling == true && psript.hasPossession == true)
            {
                dirX += pDirX;
                dirY += pDirY;
                Vector2 direction = new Vector2(dirX, dirY);
                GetComponent<SpriteRenderer>().enabled = true;
                transform.position = direction;
            }
        }
        else
        {
            dirX = 0;
            dirY = 0;
            GetComponent<SpriteRenderer>().enabled = false;
        }



    }
}
