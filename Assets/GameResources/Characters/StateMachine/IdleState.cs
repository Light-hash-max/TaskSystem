namespace TaskSystem.Characters.StateMachine
{
    using UnityEngine;

    public class IdleState : CharacterState
    {
        private float idleTime;
        private float timer;

        public IdleState(Character character) : base(character) { }

        public override void Enter()
        {
            character.Rigidbody.angularVelocity = Vector3.zero; // —брос вращательной скорости
            character.Rigidbody.linearVelocity = Vector3.zero;
            idleTime = Random.Range(1f, 3f);
            timer = 0f;
            character.Animator.SetTrigger("Idle");
        }

        public override void Update()
        {
            timer += Time.deltaTime;
            if (timer >= idleTime)
            {
                Vector3 randomDirection = new Vector3(
                    Random.Range(-1f, 1f),
                    0,
                    Random.Range(-1f, 1f)
                ).normalized;

                character.ChangeState(new MovingState(character, randomDirection));
            }
        }
    }
}