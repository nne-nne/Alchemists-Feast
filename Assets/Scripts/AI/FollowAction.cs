using Characters;
using UnityEngine;

namespace AI
{
    public class FollowAction : ActionBase
    {
        public FollowAction(CharacterBase character) : base(character) { }

        public override void Begin()
        {
            base.Begin();
            character.Agent.stoppingDistance = 3f;
            MoveToTarget();
        }

        public void MoveToTarget()
        {
            var agent = character.Agent;
            agent.destination = Target.transform.position;
        }
    }
}