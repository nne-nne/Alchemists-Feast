using Characters;

namespace AI
{
    /// <summary>
    /// Base class for all behaviours.
    /// </summary>
    public class BehaviourBase
    {
        protected CharacterBase character;
        
        public BehaviourBase(CharacterBase character)
        {
            this.character = character;
        }
        
        virtual public void SetupBehaviour()
        {
            initialAction = new InitialAction(character);
            goHideAction = new GoHideAction(character);
            hideAction = new HideAction(character);
            dieAndStayDeadAction = new DieAndStayDeadAction(character);

            initialAction.OnActionEnd.AddListener(goHideAction.Begin);
            goHideAction.OnActionEnd.AddListener(hideAction.Begin);

            initialAction.Begin();
        }

        public virtual void Die()
        {
            dieAndStayDeadAction.Begin();
        }

        public ActionBase initialAction;
        
        public ActionBase goHideAction;

        public ActionBase hideAction;

        public ActionBase dieAndStayDeadAction;
    }
}