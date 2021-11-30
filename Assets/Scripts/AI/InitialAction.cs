using Characters;
using UnityEngine;

namespace AI
{
    public class InitialAction : ActionBase
    {
        public InitialAction(CharacterBase character) : base(character) {}

        public override void Begin()
        {
            base.Begin();
            var gameMode = GameObject.FindGameObjectWithTag("GameMode").GetComponent<GameMode.GameMode>();
            gameMode.OnPhaseOneBegin.AddListener(OnPhaseOneBegin);
        }

        public void OnPhaseOneBegin()
        {
            OnActionEnd.Invoke();
        }
    }
}