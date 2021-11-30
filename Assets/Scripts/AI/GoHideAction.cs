using Characters;

namespace AI
{
    /// <summary>
    /// Makes character go hide.
    /// </summary>
    public class GoHideAction : ActionBase
    {
        public GoHideAction(CharacterBase character) : base(character) {}

        public override void Begin()
        {
            base.Begin();
            character.OnDestinationReached.AddListener(ContinueAlongPath);
            ContinueAlongPath();
        }

        private void MoveToTarget()
        {
            var agent = character.Agent;
            agent.destination = Target.transform.position;
        }

        private void ContinueAlongPath()
        {
            var target = character.path.TargetAt(nextPoint);
            ++nextPoint;
            if (target != null)
            {
                Target = target;
                MoveToTarget();
            }
            else
            {
                character.OnDestinationReached.RemoveListener(ContinueAlongPath);
                OnActionEnd.Invoke();
            }
        }
        
        private int nextPoint = 0;
    }
}
