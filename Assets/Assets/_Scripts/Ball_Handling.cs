using UnityEngine;
using System.Collections;

public class Ball_Handling : MonoBehaviour {

    Rigidbody2D player;
    Rigidbody2D ball;
	// Use this for initialization
	void Start () {
        player = GetComponent<Rigidbody2D>();
	}
	
	// Update is called once per frame
	void Update () {
	
	}

    void OnCollisionEnter(Collision col)
    {
        print("Collider is active");
        if(col.gameObject.name == "Ball_Sprite")
        {
            print("Ball found");
            Destroy(col.gameObject);
        }
    }
}
