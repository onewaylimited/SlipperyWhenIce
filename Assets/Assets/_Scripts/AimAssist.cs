using UnityEngine;
using System.Collections;

public class AimAssist : MonoBehaviour
{
    public string rxAxis = "P1SX";
    public string ryAxis = "P1SY";
    public string xaxis = "P1X";
    public string yaxis = "P1Y";
    public Sprite sprite;
    GameObject px;
    
    void Start()
    {
        GetComponent<SpriteRenderer>().enabled = false;
        px = GameObject.Find("Red_1");
    }

    void Update()
    {
        float dirX = Input.GetAxis(rxAxis);
        float dirY = Input.GetAxis(ryAxis);
        float pDirX = px.transform.position.x;
        
             
        float pDirY = px.transform.position.y;
        if (dirX > .3 || dirY > .3|| dirX<-.3||dirY<-.3)
        {

            dirX += pDirX;
            dirY += pDirY;
            Vector2 direction = new Vector2(dirX, dirY);
            GetComponent<SpriteRenderer>().enabled = true;
            transform.position = direction;
        }
        else
        {
            dirX = 0;
            dirY = 0;
            GetComponent<SpriteRenderer>().enabled = false;
        }
        }

}
