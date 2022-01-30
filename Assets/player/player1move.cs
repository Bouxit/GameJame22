using UnityEngine;

public class player1move : MonoBehaviour
{
    public movement _movementScript;

    public Rigidbody rb1;
    bool grounded1;
    float groundCheck1 = 1.03f;
    float rayOrigin1 = 1.03f;
    public LayerMask ground1;
    float jumpForce1 = 300;
    float DjumpForce1 = 170;
    Vector3 DjumpAngle1;
    float LrayAngle = 0.4f;
    bool lookRight;
    //double jump
    bool dJump;
    //grounded?
    [SerializeField] float fJumpPressedRemember = 0;
    [SerializeField] float fJumpPressedRememberTime = 0.5f;


    void Start()
    {
        rb1 = GetComponent<Rigidbody>();
    }

    // Update is called once per frame
    void Update()
    {
        float hor = Input.GetAxis("Horizontal");
        rb1.AddForce(new Vector3(0,- 5.3f, 0));
        //RAYCAST

        grounded1 = Physics.Raycast(transform.position, transform.up * -rayOrigin1, groundCheck1, ground1) ||
        Physics.Raycast(transform.position, transform.up * -rayOrigin1 + transform.right * -LrayAngle, groundCheck1, ground1) ||
        Physics.Raycast(transform.position, transform.up * -rayOrigin1 + transform.right * LrayAngle, groundCheck1, ground1);
        Debug.DrawRay(transform.position, transform.up * -rayOrigin1, Color.red, groundCheck1);
        Debug.DrawRay(transform.position, transform.up * -rayOrigin1 + transform.right * -LrayAngle, Color.red, groundCheck1);
        Debug.DrawRay(transform.position, transform.up * -rayOrigin1 + transform.right * LrayAngle, Color.red, groundCheck1);
        
        if (grounded1)
        {
            dJump = true;
        }
        //jumps when you land if you pressed earlier
        fJumpPressedRemember -= Time.deltaTime;

        if ((fJumpPressedRemember >= 0) && grounded1)
        {
            fJumpPressedRemember = 0;
            rb1.AddForce(Vector3.up * jumpForce1);
        }
        if (Input.GetKeyDown(KeyCode.Space) && grounded1)
        {
            fJumpPressedRemember = fJumpPressedRememberTime;
        }
        if (Input.GetKeyDown(KeyCode.Space) && !grounded1 && dJump == true)
        {
            rb1.AddForce(Vector3.up * DjumpForce1 + DjumpAngle1);
            dJump = false;
            Debug.Log(DjumpAngle1);
        }
        if (!grounded1)
        {
            _movementScript.inAir = true;
        }
        else { _movementScript.inAir = false; }
        //walk
        _movementScript.moving();
        //look and check angle
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
            DjumpAngle1 = Vector3.right * 10;
            Debug.Log(DjumpAngle1);
        }
        else { DjumpAngle1 = Vector3.right * -150; 
        }
    }
}


