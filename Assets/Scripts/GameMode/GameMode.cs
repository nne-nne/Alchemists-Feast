using System;
using UnityEngine;
using UnityEngine.Events;
using Characters;

namespace GameMode
{
    public enum Phase
    {
        Beginning,
        PhaseOne,
        PhaseTwo
    }
    
    public class GameMode : MonoBehaviour
    {
        bool firstDialog = false;
        bool secondDialog = false;
        bool thirdDialog = false;
        bool fourthDialog = false;

        public float timeOfBeginning = 15f;
        public float firstDialogTime = 5f;
      
        public float timeOfPhaseOne = 90f;
        public float secondDialogTime = 30f;

        public float timeOfPhaseTwo = 180f;

        public Phase phase = Phase.Beginning;

        private void Start()
        {
            OnGameEnd.AddListener(DisplayGoodEnd);
        }

        private void Update()
        {
            switch (phase)
            {
                case Phase.Beginning:
                    BeginningProceed();
                    break;
                case Phase.PhaseOne:
                    PhaseOneProceed();
                    break;
                case Phase.PhaseTwo:
                    PhaseTwoProceed();
                    break;
                default:
                    break;
            }
        }

        
        private void BeginningProceed()
        {
            timeOfBeginning -= Time.deltaTime;
            firstDialogTime -= Time.deltaTime;

            if (firstDialogTime <= 0f && !firstDialog)
            {
                martha.GetComponent<DialogScript>().DisplayFirstDialog();
                firstDialog = true;
            }

            if (timeOfBeginning <= 0f)
            {
                phase = Phase.PhaseOne;
                OnPhaseOneBegin.Invoke();
                martha.GetComponent<DialogScript>().Reset();
                // martha.GetComponent<CharacterBase>().Behaviour
            }
        }
        
        private void PhaseOneProceed()
        {
            timeOfPhaseOne -= Time.deltaTime;
            secondDialogTime -= Time.deltaTime;

            if (secondDialogTime <= 0f && !secondDialog)
            {
                martha.GetComponent<DialogScript>().DisplaySecondDialog();
                secondDialog = true;
            }

            if (timeOfPhaseOne <= 0f)
            {
                phase = Phase.PhaseTwo;
                OnPhaseTwoBegin.Invoke();
                martha.GetComponent<DialogScript>().Reset();
                martha.GetComponent<DialogScript>().DisplayChangeDialog();
            }
        }

        public void OnFiolkaUse()
        {
            martha.GetComponent<DialogScript>().Reset();
            martha.GetComponent<DialogScript>().DisplayThirdDialog();
            OnPhaseTwoBegin.Invoke();
            phase = Phase.PhaseTwo;
        }

        private void PhaseTwoProceed()
        {
            timeOfPhaseTwo -= Time.deltaTime;
            if (timeOfPhaseTwo <= 0f)
            {
                DisplayBadEnd();
                //OnGameEnd.Invoke();
            }
        }
        
        public UnityEvent OnBeginningBegin = new UnityEvent();
        
        public UnityEvent OnPhaseOneBegin = new UnityEvent();
        
        public UnityEvent OnPhaseTwoBegin = new UnityEvent();

        public UnityEvent OnGameEnd = new UnityEvent();

        public GameObject martha;

        private void DisplayBadEnd()
        {
            martha.GetComponent<MenuScript>().WinGame(false);
            //martha.GetComponent<MenuScript>().EndGame();
        }

        private void DisplayGoodEnd()
        {
            martha.GetComponent<MenuScript>().WinGame(true);
            //martha.GetComponent<MenuScript>().EndGame();
        }

        public int charactersToKill = 4;

        public void OnCharacterKilled()
        {
            --charactersToKill;
            if (charactersToKill <= 0)
            {
                OnGameEnd.Invoke();
            }
        }
    }
}