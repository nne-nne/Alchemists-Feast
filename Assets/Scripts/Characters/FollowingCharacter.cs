using AI;
using UnityEngine;

namespace Characters
{
    public class FollowingCharacter : CharacterBase
    {
        protected override void Awake()
        {
            base.Awake();
            Behaviour = new FollowingBehaviour(this);
        }
    }
}