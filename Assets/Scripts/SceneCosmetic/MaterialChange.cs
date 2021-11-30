using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MaterialChange : MonoBehaviour
{
    private MeshRenderer mr;
    int materialIndex = 0;
    void Start()
    {
        mr = GetComponent<MeshRenderer>();
    }

    void NextMaterial()
    {
        materialIndex = (materialIndex + 1) % mr.materials.Length;
        mr.material = mr.materials[materialIndex];
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
