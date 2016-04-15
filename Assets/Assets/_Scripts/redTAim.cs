using UnityEngine;
using System.Collections;

public class redTAim : MonoBehaviour
{
    public string rxAxis = "P1SX";
    public string ryAxis = "P1SY";
    public string xaxis = "P1X";
    public string yaxis = "P1Y";
    public Sprite sprite;
    GameObject px;
    float mod = 2;
    public float dirX;
    public float dirY;
    public PlayerScript psript;
    void Start()
    {

        GetComponent<SpriteRenderer>().enabled = false;
        px = GameObject.Find("Red_2");

    }

    void Update()
    {
        psript = px.GetComponent<PlayerScript>();



        dirX = mod * Input.GetAxis(rxAxis);
        dirY = mod * Input.GetAxis(ryAxis);
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
