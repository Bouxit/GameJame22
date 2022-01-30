using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class PlayerDeath : MonoBehaviour
{
    public int Respawn;

    private void OnTriggerEnter(Collider other)
    {
        if(other.CompareTag("player1"))

                {
            SceneManager.LoadScene(Respawn);

        }
        if (other.CompareTag("player2"))
        {
            SceneManager.LoadScene(Respawn);

        }
    }
}
