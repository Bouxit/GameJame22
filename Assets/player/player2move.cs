using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class player2move : MonoBehaviour
{
    public movement _movementScript;

    public Rigidbody rb2;
    bool grounded2;
    float groundCheck2 = 1.03f;
    float rayOrigin2 = 1.03f;
    public LayerMask ground2;
    float jumpForce2 = 300;
    float DjumpForce2 = 170;
    float LrayAngle = 0.4f;
    Vector3 DjumpAngle2;
    bool dJump;
    //double jump
    bool lookRight;
    //grounded?
    [SerializeField] float fJumpPressedRemember = 0;
    [SerializeField] float fJumpPressedRememberTime = 0.5f;
    void Start()
    {
        rb2 = GetComponent<Rigidbody>();
    }

    // Update is called once per frame
    void Update()
    {
        float hor = Input.GetAxis("Horizontal");
        rb2.AddForce( new Vector3(0,5f,0) );
        
        //RAYCAST
        grounded2 = Physics.Raycast(transform.position, transform.up * rayOrigin2, groundCheck2, ground2) ||
        Physics.Raycast(transform.position, transform.up * rayOrigin2 + transform.right * -LrayAngle, groundCheck2, ground2) ||
        Physics.Raycast(transform.position, transform.up * rayOrigin2 + transform.right * LrayAngle, groundCheck2, ground2);
        Debug.DrawRay(transform.position, transform.up * rayOrigin2, Color.red, groundCheck2);
        Debug.DrawRay(transform.position, transform.up * rayOrigin2 + transform.right * -LrayAngle, Color.red, groundCheck2);
        Debug.DrawRay(transform.position, transform.up * rayOrigin2 + transform.right * LrayAngle, Color.red, groundCheck2);

        if (grounded2)
        {
            dJump = true;
        }
        //jumps when you land if you pressed earlier
        fJumpPressedRemember -= Time.deltaTime;

        if ((fJumpPressedRemember > 0) && grounded2)
        {
            fJumpPressedRemember = 0;
            rb2.AddForce(Vector3.up * -jumpForce2);
        }
        if (Input.GetKeyDown(KeyCode.Space) && grounded2)
        {
            fJumpPressedRemember = fJumpPressedRememberTime;
            Debug.Log("jump");
        }
        if (Input.GetKeyDown(KeyCode.Space) && !grounded2 && dJump == true)
        {
            rb2.AddForce(Vector3.up * -DjumpForce2 + DjumpAngle2);
            dJump = false;
        }
        if (!grounded2)
        {
            _movementScript.inAir = true; ;
        }
        else { _movementScript.inAir = false; }
        //walk
        _movementScript.moving();
        //look and checks angle
        if (hor < 0)
        {
            //sr.flipX = true;
            lookRight = false;
        }
        if (hor > 0)
        {
            lookRight = true;
            //sr.flipX = false;
        }
        if (lookRight == true)
        {
            DjumpAngle2 = Vector3.right * 150;
            Debug.Log(DjumpAngle2);
        }
        else { DjumpAngle2 = Vector3.right * -150; }

    }

}
