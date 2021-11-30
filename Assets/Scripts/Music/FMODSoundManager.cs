using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[RequireComponent(typeof(FMODUnity.StudioEventEmitter))]
public class FMODSoundManager : MonoBehaviour
{
    public void Play() {
        GetComponent<FMODUnity.StudioEventEmitter>().Play();
    }

    public void Stop() {
        GetComponent<FMODUnity.StudioEventEmitter>().Stop();
    }
}
