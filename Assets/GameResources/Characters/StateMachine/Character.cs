namespace TaskSystem.Characters.StateMachine
{
    using TaskSystem.Core;
    using UnityEngine;

    /// <summary>
    /// Персонаж с состояниями
    /// </summary>
    [RequireComponent(typeof(Rigidbody), typeof(Animator))]
    public class Character : MonoBehaviour
    {
        [SerializeField]
        protected TapCount tapCount;
        [Header("Settings")]
        public float MoveSpeed = 3f;

        [Header("Components")]
        public Rigidbody Rigidbody;
        public Animator Animator;

        private CharacterState currentState;

        private void Awake()
        {
            Rigidbody = GetComponent<Rigidbody>();
            Animator = GetComponent<Animator>();
        }

        private void OnEnable()
        {
            tapCount.OnClicked += Die;
        }

        private void OnDisable()
        {
            tapCount.OnClicked -= Die;
        }

        private void Start() => ChangeState(new IdleState(this));

        private void Update() => currentState?.Update();
        private void FixedUpdate() => currentState?.FixedUpdate();

        public void ChangeState(CharacterState newState)
        {
            currentState?.Exit();
            currentState = newState;
            currentState.Enter();
        }

        protected virtual void Die()
        {
            ChangeState(new DeathState(this));
        }
    }
}