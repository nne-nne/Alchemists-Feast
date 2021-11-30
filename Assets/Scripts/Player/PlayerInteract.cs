using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerInteract : MonoBehaviour
{
    [SerializeField] private KeyCode interactKey;
    [SerializeField] private Transform handPivot;
    [SerializeField] private GameObject player;
    private GameObject curItem;
    private List<GameObject> interactiblesInRange;


    private void Awake()
    {
        player = FindObjectOfType<PlayerController>().gameObject;
        interactiblesInRange = new List<GameObject>();
    }
    void Update()
    {
        if (Input.GetKeyDown(interactKey))
        {
            if (curItem == null)
            {
                TryInteraction();
            }
            else
            {
                Drop();
            }
        }
        if (Input.GetMouseButton(0))
        {
            if (curItem != null)
            {
                IUsable usable = curItem.GetComponent<IUsable>();
                if (usable != null)
                {
                    usable.Use();
                }
            }
        }
    }

    private GameObject FindClosestInteractible()
    {
        float minRange = float.MaxValue;
        GameObject closest = null;
        foreach(GameObject interactible in interactiblesInRange)
        {
            float dist = Vector3.Distance(player.transform.position, interactible.transform.position);
            if (dist < minRange)
            {
                minRange = dist;
                closest = interactible;
            }
        }
        return closest;
    }    

    private void TryInteraction()
    {
        GameObject interactible = FindClosestInteractible();
        if(interactible != null)
        {
            Debug.Log(interactible.name);
            ITakeable takeable = interactible.GetComponent<ITakeable>();
            if (takeable != null)
            {
                 takeable.Take();
                 PlaceItemInHand(interactible.transform);
                 curItem = interactible;
            }
            else
            {
                IInteractible interact = interactible.GetComponent<IInteractible>();
                if (interact != null)
                {
                    Debug.Log("interactible");
                    interact.Interact();
                }
            }
        }
    }

    void Drop()
    {
        if (curItem != null)
        {
            Rigidbody itemRb = curItem.GetComponent<Rigidbody>();
            if (itemRb != null)
            {
                itemRb.isKinematic = false;
            }
            curItem.transform.parent = null;
            curItem = null;
        }
    }

    void PlaceItemInHand(Transform item)
    {
        item.parent = handPivot;
        item.transform.position = handPivot.position;
        item.transform.localPosition = Vector3.zero;
        item.transform.rotation = Quaternion.identity;


        Rigidbody itemRb = item.gameObject.GetComponent<Rigidbody>();
        if (itemRb != null)
        {
            itemRb.isKinematic = true;
        }
    }

    private void OnTriggerEnter(Collider other)
    {
        if(other.gameObject.CompareTag("Interactible"))
        {
            interactiblesInRange.Add(other.gameObject);
        }
    }

    private void OnTriggerExit(Collider other)
    {
        if (other.gameObject.CompareTag("Interactible") && interactiblesInRange.Contains(other.gameObject))
        {
            interactiblesInRange.Remove(other.gameObject);
        }
    }
}
