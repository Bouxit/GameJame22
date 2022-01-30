using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DoorTrigger : MonoBehaviour
{
    [SerializeField]
    GameObject Door;

    void OnTriggerEnter(Collider other)
    {
         Door.transform.position += new Vector3(0, -40000, 0);
    }
}
