using Characters;
using UnityEngine;
using UnityEngine.Events;

namespace AI
{
    /// <summary>
    /// Base class for all actions.
    /// </summary>
    public class ActionBase
    {
        public ActionBase(CharacterBase character)
        {
            this.character = character;
        }

        public virtual void Begin()
        {
            OnActionBegin.Invoke();
        }

        public UnityEvent OnActionBegin = new UnityEvent();

        public UnityEvent OnActionEnd = new UnityEvent();

        public UnityEvent OnActionInterrupt = new UnityEvent();

        public GameObject Target { get; set; } = null;

        protected CharacterBase character;
    }
}