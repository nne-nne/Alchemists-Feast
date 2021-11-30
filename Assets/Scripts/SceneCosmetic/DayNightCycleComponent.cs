using UnityEngine;

/// <summary>
/// Component responsible for day-night cycle.
/// </summary>
public class DayNightCycleComponent : MonoBehaviour
{
    public float sunRotationSpeed = 10f;
    
    void Start()
    {
        
    }

    void Update()
    {
        transform.RotateAround(Vector3.zero, Vector3.right, 10f * Time.deltaTime);
        transform.LookAt(Vector3.zero);
    }
}
