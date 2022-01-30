using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ifHitTrap : MonoBehaviour
{
    
    void Update()
    {
        
    }
    public void OnTriggerEnter(Collider collision)
    {
        if (collision.CompareTag("player1"))
        {
            //disabele movement
            //play death anim
            //menu pops up, restart level, menu and quit

        }
        if (collision.CompareTag("player2"))
        {
            //disabele movement
            //play death anim
            //menu pops up, restart level, menu and quit

        }
        
    }
}
