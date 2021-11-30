using AI;
using UnityEngine;
using UnityEngine.AI;
using UnityEngine.Events;

namespace Characters
{
    /// <summary>
    /// Base class for all characters.
    /// </summary>
    public class CharacterBase : MonoBehaviour
    {
        private float interactionRange = 3f;
        
        public float InteractionRange
        {
            get => interactionRange;
            set { interactionRange = value; sphereCollider.radius = interactionRange; }
        }

        public Path path;

        private SphereCollider sphereCollider;
        
        private SkinnedMeshRenderer mesh;

        private NavMeshAgent agent;

        public NavMeshAgent Agent => agent;

        public float Speed => agent.velocity.magnitude;

        public BehaviourBase Behaviour { get; set; }

        public UnityEvent OnDestinationReached = new UnityEvent();

        private Animator animator;

        public bool isHiding = false;
        
        public bool isDead = false;

        public void Die()
        {
            if (!isDead)
            {
                GameObject.FindGameObjectWithTag("GameMode").GetComponent<GameMode.GameMode>().OnCharacterKilled();
            }
            Behaviour.Die();
        }

        protected virtual void Awake()
        {
            gameObject.AddComponent<SphereCollider>();
            sphereCollider = GetComponent<SphereCollider>();
            path = GetComponent<Path>();
            
            Behaviour = new BehaviourBase(this);
        }

        private void Start()
        {
            mesh = GetComponent<SkinnedMeshRenderer>();
            agent = GetComponent<NavMeshAgent>();
            animator = GetComponent<Animator>();

            agent.radius = 1f;
            agent.stoppingDistance = 1f;

            Behaviour.SetupBehaviour();
        }

        private void Update()
        {
            animator.SetFloat("Speed", agent.velocity.magnitude);
            animator.SetBool("IsHiding", isHiding);
            animator.SetBool("IsDead", isDead);
            
            if (!agent.pathPending)
            {
                if (agent.remainingDistance <= agent.stoppingDistance)
                {
                    if (!agent.hasPath || agent.velocity.sqrMagnitude == 0f)
                    {
                        OnDestinationReached.Invoke();
                    }
                }
            }
        }
    }
}