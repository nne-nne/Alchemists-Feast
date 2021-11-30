using Characters;
using UnityEngine;

namespace AI
{
    public class FollowingBehaviour : BehaviourBase
    {
        public FollowingBehaviour(CharacterBase character) : base(character) {}

        public override void SetupBehaviour()
        {
            var newFollowAction = new FollowAction(character);
            
            var target = character.path.TargetAt(0);
            var playerController = target.GetComponent<PlayerController>();
            if (playerController != null)
            {
                newFollowAction.Target = target;
                playerController.OnPositionUpdate.AddListener(newFollowAction.MoveToTarget);
            }

            // GameObject.FindGameObjectWithTag("GameMode").GetComponent<GameMode.GameMode>().OnPhaseTwoBegin.AddListener(ChangeTarget);

            followAction = newFollowAction;
            followAction.Begin();
        }

        public override void Die()
        {
            
        }

        public ActionBase followAction;

        private void ChangeTarget()
        {
            character.path.path[0] = GameObject.FindGameObjectWithTag("Jozin");
            SetupBehaviour();
        }
    }
}