using System;
using Characters;
using UnityEngine;

namespace Player
{
    public class AttackCollision : MonoBehaviour
    {
        public bool isEnabled = false;
        
        private BoxCollider collider;

        private void Start()
        {
            collider = gameObject.AddComponent<BoxCollider>();
            collider.isTrigger = true;
            collider.size = new Vector3(10f, 5f, 10f);
        }

        private void OnCollisionEnter(Collision other)
        {
            if (!isEnabled) { return; }
            var character = other.gameObject.GetComponent<CharacterBase>();
            if (character != null)
            {
                character.Die();
            }
        }

        private void OnCollisionStay(Collision other)
        {
            if (!isEnabled) { return; }
            var character = other.gameObject.GetComponent<CharacterBase>();
            if (character != null)
            {
                character.Die();
            }
        }
    }
}