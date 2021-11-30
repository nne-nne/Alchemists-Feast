using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DoorOpeningTester : MonoBehaviour
{
    public bool PlayerIn = false;

    private void OnTriggerEnter(Collider other)
    {
        if(other.CompareTag("Player"))
        {
            PlayerIn = true;
        }
    }

    private void OnTriggerExit(Collider other)
    {
        if (other.CompareTag("Player"))
        {
            PlayerIn = false;
        }
    }
}
