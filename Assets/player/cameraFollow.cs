using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class cameraFollow : MonoBehaviour
{
    public GameObject player1;
    public GameObject player2;
    
    
    
    void Update()
    {
        
        transform.position = new Vector3((player1.transform.position.x + player2.transform.position.x)/2,0,-10) ;
    }
}
