using Characters;
using UnityEngine;

namespace AI
{
    public class DieAndStayDeadAction : ActionBase
    {
        public DieAndStayDeadAction(CharacterBase character) : base(character) {}

        public override void Begin()
        {
            base.Begin();
            character.Agent.destination = character.transform.position;
            character.Agent.updatePosition = false;
            character.Agent.updateRotation = false;
            character.isDead = true;
        }
    }
}