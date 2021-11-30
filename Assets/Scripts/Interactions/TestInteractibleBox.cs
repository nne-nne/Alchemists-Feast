using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TestInteractibleBox : MonoBehaviour, IInteractible
{
    public void Interact()
    {
        Debug.Log("yaay interaction!");
    }
}
