using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MusicManager : MonoBehaviour
{
    public static MusicManager instance { private set; get; }

    private void Awake()
    {
        instance = this;
    }
    public void SetChaseParemeter(int value) {
        GetComponent<FMODUnity.StudioEventEmitter>().SetParameter("ChaseLevel", value);
    }

    public void Stop()
    {
        Destroy(this);

    }

}
