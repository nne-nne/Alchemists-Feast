using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DialogScript : MonoBehaviour
{
    public GameObject dialogPanel;
    public GameObject dialog1;
    public GameObject dialog2;
    public GameObject dialog3;
    public GameObject dialogChange;

    public void Reset()
    {
        dialog1.gameObject.SetActive(false);
        dialog2.gameObject.SetActive(false);
        dialog3.gameObject.SetActive(false);
        dialogChange.gameObject.SetActive(false);
        dialogPanel.gameObject.SetActive(false);
    }

    void Start()
    {
        Reset();
    }

    public void DisplayFirstDialog()
    {
        dialog1.gameObject.SetActive(true);
        dialogPanel.gameObject.SetActive(true);
    }

    public void DisplaySecondDialog()
    {
        dialog2.gameObject.SetActive(true);
        dialogPanel.gameObject.SetActive(true);
    }

    public void DisplayThirdDialog()
    {
        dialog3.gameObject.SetActive(true);
        dialogPanel.gameObject.SetActive(true);
    }

    public void DisplayChangeDialog()
    {
        dialogChange.gameObject.SetActive(true);
        dialogPanel.gameObject.SetActive(true);
    }

    void Update()
    {
        if (Input.GetKey(KeyCode.LeftArrow))
            DisplayFirstDialog();
        else if (Input.GetKey(KeyCode.DownArrow))
            DisplaySecondDialog();
        else if (Input.GetKey(KeyCode.RightArrow))
            DisplayThirdDialog();
        else if (Input.GetKey(KeyCode.AltGr))
            DisplayChangeDialog();

        if (Input.GetKey(KeyCode.Space))
            Reset();
    }

}
