using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class HoverSetBool : MonoBehaviour, IHoverable
{
    public bool hover = false;
    public void OnMouseHover()
    {
        hover = true;
        Debug.Log("Hover, hi");
    }

    public void OnMouseLeave()
    {
        hover = false;
        Debug.Log("Hover, bye");
    }
}
