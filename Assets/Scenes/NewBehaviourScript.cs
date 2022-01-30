using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class NewBehaviourScript : MonoBehaviour
{
    public Rigidbody rbody;
    public float moveX;
    public float movespeed = 10f;
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        moveX = (Input.GetAxis("Horizontal"));

        rbody.velocity = new Vector2(moveX * movespeed, rbody.velocity.y);
    }
}
