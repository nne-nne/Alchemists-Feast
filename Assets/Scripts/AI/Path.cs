using System.Collections.Generic;
using UnityEngine;

namespace AI
{
    /// <summary>
    /// Path is a series of points.
    /// </summary>
    public class Path : MonoBehaviour
    {
        public List<GameObject> path;

        public GameObject TargetAt(int index)
        {
            return index >= path.Count ? null : path[index];
        }
    }
}