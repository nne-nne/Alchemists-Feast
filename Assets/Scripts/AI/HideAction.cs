using Characters;
using UnityEngine;

namespace AI
{
    /// <summary>
    /// Basic hiding action.
    /// </summary>
    public class HideAction : ActionBase
    {
        public HideAction(CharacterBase character) : base(character) {}

        public override void Begin()
        {
            base.Begin();
            character.isHiding = true;
            
            OnActionEnd.Invoke();
        }
    }
}