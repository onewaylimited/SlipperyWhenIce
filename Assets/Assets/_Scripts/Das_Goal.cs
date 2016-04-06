using UnityEngine;
using System.Collections;

public class Das_Goal : MonoBehaviour
{

    GameObject parent;
    BoxCollider2D box;

    // Use this for initialization
    void Start()
    {
        parent = this.transform.parent.gameObject;
        box = GetComponentInParent<BoxCollider2D>();
        this.transform.position = new Vector3(parent.transform.position.x + box.offset.x, parent.transform.position.y + box.offset.y, parent.transform.position.z);
    }

    // Update is called once per frame
    void Update()
    {

    }
}
