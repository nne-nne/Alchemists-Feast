using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EventBroker
{

    public static event Action PlayerKilled;
    public static event Action PlayerChanged;
    public static event Action<GameObject> NPCKilled;
    public static event Action<GameObject> NotesCollected;
    public static event Action<GameObject> PotionCollected;
    public static event Action<GameObject> ShelterFound;

    public static void CallPlayerKilled()
    {
        PlayerKilled?.Invoke();
    }

    public static void CallPlayerChanged()
    {
        PlayerChanged?.Invoke();
    }

    public static void CallNPCKilled(GameObject npc)
    {
        NPCKilled?.Invoke(npc);
    }

    public static void CallPotionCollected(GameObject potion)
    {
        PotionCollected?.Invoke(potion);
    }

    public static void CallShelterFound(GameObject shelter)
    {
        ShelterFound?.Invoke(shelter);
    }

}
