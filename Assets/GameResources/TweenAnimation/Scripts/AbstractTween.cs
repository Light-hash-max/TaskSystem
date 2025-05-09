namespace TweenAnimation
{
    using DG.Tweening;
    using System;
    using System.Collections.Generic;
    using UnityEngine;
    using UnityEngine.Events;

    /// <summary>
    /// Твин анимация
    /// </summary>
    public abstract class AbstractTween: MonoBehaviour
    {
        /// <summary>
        /// Закончилась анимация
        /// </summary>
        public event Action OnComplete = delegate { };

        /// <summary>
        /// Твин анимация
        /// </summary>
        public Tween TweenAnimation { get; protected set; } = default;

        public float Duration = 1f;
        [SerializeField, Min(0f)]
        protected float delay = 0f;
        [SerializeField]
        protected int loops = 1;
        [SerializeField]
        protected LoopType loopType = default;
        [SerializeField]
        protected List<UnityEvent> unityEvents = new List<UnityEvent>();
        [SerializeField]
        protected AnimationCurve animationCurve;

        protected virtual void CallCompete()
        {
            unityEvents.ForEach(x => x.Invoke());
            OnComplete();
        }

        protected virtual void OnEnable() => StopAnimation();

        protected virtual void OnDisable() => StopAnimation();

        /// <summary>
        /// Остановить анимацию
        /// </summary>
        public virtual void StopAnimation()
        {
            if (TweenAnimation != null)
            {
                TweenAnimation.Kill();
            }
        }

        /// <summary>
        /// Затвинить
        /// </summary>
        public abstract void Tween();

        /// <summary>
        /// Обравтный твин
        /// </summary>
        public abstract void Revert();
    }
}