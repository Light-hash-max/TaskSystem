namespace TaskSystem.Characters.StateMachine
{
    using Unity.VisualScripting;
    using UnityEngine;
    using UnityEngine.TextCore.Text;

    public class MovingState : CharacterState
    {
        private Vector3 moveDirection;
        private float moveDuration;
        private float timer;

        public MovingState(Character character, Vector3 direction) : base(character)
        {
            moveDirection = direction;
        }

        public override void Enter()
        {
            moveDuration = Random.Range(2f, 5f);
            timer = 0f;
            character.Animator.SetTrigger("Walk");
        }

        public override void FixedUpdate()
        {
            if (Quaternion.Angle(character.transform.rotation, Quaternion.LookRotation(moveDirection)) > 0.01)
            {
                character.transform.rotation = Quaternion.RotateTowards(character.transform.rotation, Quaternion.LookRotation(moveDirection), Time.fixedDeltaTime * 200f);
            }

            Vector3 newVelocity = moveDirection * character.MoveSpeed;
            newVelocity.y = character.Rigidbody.linearVelocity.y; 
            character.Rigidbody.linearVelocity = newVelocity;

            timer += Time.fixedDeltaTime;
            if (timer >= moveDuration)
            {
                character.ChangeState(new IdleState(character));
            }
        }

        public override void Exit()
        {
            character.Rigidbody.linearVelocity = Vector3.zero;
        }
    }
}