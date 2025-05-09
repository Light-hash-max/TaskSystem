namespace TaskSystem.Characters.StateMachine
{
    using UnityEngine;

    public class DeathState : CharacterState
    {
        public DeathState(Character character) : base(character) { }

        public override void Enter()
        {
            character.Rigidbody.isKinematic = true;
            character.Animator.SetTrigger("Die");
            character.GetComponent<Collider>().enabled = false;
            GameObject.Destroy(character.gameObject, 7f);
        }
    }
}