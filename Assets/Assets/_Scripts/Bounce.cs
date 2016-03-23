using UnityEngine;
using System.Collections;

public class Bounce : MonoBehaviour {
    protected new Rigidbody2D rb; 
    
	// Use this for initialization
	void Start () {
        rb = GetComponent<Rigidbody2D>();
	}
	
	// Update is called once per frame
	void Update () {
	
	}

    
}
