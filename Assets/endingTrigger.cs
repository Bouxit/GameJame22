using UnityEngine;
using System.Collections;

public class endingTrigger : MonoBehaviour
{

 public GameObject Ending;
 public GameObject Level;

  void OnCollisionEnter(Collision other)
  {
    Debug.Log("Player collided hit");
    Ending.SetActive(true);
  }

  void OnTriggerEnter(Collider other)
  {
    Debug.Log("Player collided trigger");
    Ending.SetActive(true);
    Level.SetActive(false);
  }
}