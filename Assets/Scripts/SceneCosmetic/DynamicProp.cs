using System;
using UnityEngine;
using UnityEngine.Events;

namespace SceneCosmetic
{
    /// <summary>
    /// Any object that changes during gameplay.
    /// </summary>
    public class DynamicProp : MonoBehaviour
    {
        private Collider attackCollider;
        
        private void Start()
        {
            attackCollider = GetComponent<Collider>();
        }

        private void OnCollisionEnter(Collision other)
        {
            if (other.gameObject.CompareTag("Player"))
            {
                OnDynamicPropBeginAction.Invoke();
                OnDynamicPropBeginAction.RemoveAllListeners();
            }
        }

        private void OnCollisionExit(Collision other)
        {
            if (other.gameObject.CompareTag("Player"))
            {
                OnDynamicPropEndAction.Invoke();
                OnDynamicPropEndAction.RemoveAllListeners();
            }
        }

        public UnityEvent OnDynamicPropBeginAction;
        
        public UnityEvent OnDynamicPropEndAction;
    }
}