using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Doors : MonoBehaviour, IInteractible
{
    [SerializeField] private Transform bar;
    [SerializeField] private Vector3 barPosClosed;
    [SerializeField] private Vector3 barPosOpened;
    [SerializeField] private float closingTime;
    [SerializeField] private bool isOpened;
    [SerializeField] private DoorOpeningTester sideTester;
    private Quaternion closeRotation;
    private Rigidbody rb;

    public void Interact()
    {
        if(sideTester.PlayerIn)
        {
            if (isOpened)
            {
                StopAllCoroutines();
                StartCoroutine("RotateToClose");
            }
            else
            {
                StopAllCoroutines();
                Open();
            }
        }
    }

    private void Open()
    {
        bar.localPosition = barPosOpened;
        isOpened = true;
        rb.isKinematic = false;
        rb.angularVelocity = Vector3.zero;
    }

    private void Close()
    {
        bar.localPosition = barPosClosed;
        isOpened = false;
        rb.isKinematic = true;
        rb.angularVelocity = Vector3.zero;
    }

    private IEnumerator RotateToClose()
    {
        Quaternion originRotation = transform.rotation;
        float t = 0f;
        while(t < closingTime)
        {
            t += Time.deltaTime;
            yield return null;
            transform.rotation = Quaternion.Lerp(originRotation, closeRotation, t / closingTime);
        }
        Close();
    }

    void Start()
    {
        closeRotation = transform.rotation;
        rb = GetComponent<Rigidbody>();
    }

    void Update()
    {
        
    }
}
