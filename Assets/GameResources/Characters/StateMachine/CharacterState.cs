namespace TaskSystem.Characters.StateMachine
{
    using UnityEngine;

    /// <summary>
    /// Базовый класс состояния
    /// </summary>
    public abstract class CharacterState
    {
        protected Character character;

        public CharacterState(Character character) => this.character = character;

        public virtual void Enter() { }
        public virtual void Update() { }
        public virtual void FixedUpdate() { }
        public virtual void Exit() { }

    }
}