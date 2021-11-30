using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerHover : MonoBehaviour
{
    [SerializeField] private float maxDistance;
    private IHoverable curHover;
    private RaycastHit hit;

    void Start()
    {
        
    }

    void Update()
    {
        Ray ray = Camera.main.ScreenPointToRay(new Vector2(0,0));
        if (Physics.Raycast(ray, out hit))
        {
            if (hit.distance < maxDistance)
            {
                IHoverable hoverable = hit.collider.GetComponent<IHoverable>();
                if (hoverable != null)
                {
                    if(curHover != null)
                    {
                        if (hoverable != curHover)
                        {
                            curHover.OnMouseLeave();
                            curHover = hoverable;
                            curHover.OnMouseHover();
                        }
                    }
                    else
                    {
                        curHover = hoverable;
                        curHover.OnMouseHover();
                    }
                }
                else if (curHover != null)
                {
                    curHover.OnMouseLeave();
                    curHover = null;
                }
            }
            else if(curHover != null)
            {
                curHover.OnMouseLeave();
                curHover = null;
            }
        }
        else if (curHover != null)
        {
            curHover.OnMouseLeave();
            curHover = null;
        }
    }
}
