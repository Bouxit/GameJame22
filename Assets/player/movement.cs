using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
public class movement : MonoBehaviour
{
    public Rigidbody rb2;
    public float speed;
    public bool inAir;
    float hor;
    void Start()
    {
        rb2 = GetComponent<Rigidbody>();
    }

    void Update()
    {
        hor = Input.GetAxis("Horizontal");
    }
    public void moving()
    {
        if (inAir == false)
        {
            rb2.velocity = new Vector3(hor * speed, rb2.velocity.y, rb2.velocity.z);
        }
        if (inAir == true)
        {
            rb2.velocity = new Vector3(hor * 4.5f, rb2.velocity.y, rb2.velocity.z);
        }
    }
}
