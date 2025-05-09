namespace TweenAnimation
{
    using DG.Tweening;
    using UnityEngine;

    /// <summary>
    /// Твин прозрачности
    /// </summary>
    [RequireComponent(typeof(CanvasGroup))]
    public class TweenAlpha : AbstractTween
    {
        [SerializeField]
        protected float endValue = 1f;
        [SerializeField]
        protected float startValue = 1f;

        public bool isUseReverse = true;

        public CanvasGroup canvasGroup = default;

        private void Reset()
        {
            canvasGroup = GetComponent<CanvasGroup>();
        }

        public override void StopAnimation()
        {
            base.StopAnimation();
            canvasGroup.alpha = startValue;
        }

        public override void Tween()
        {
            canvasGroup.alpha = startValue;
            TweenAnimation = canvasGroup.DOFade(endValue, Duration).SetDelay(delay).SetLoops(loops, loopType).OnComplete(CallCompete).SetEase(animationCurve);
        }

        public override void Revert()
        {
            if (isUseReverse)
            {
                canvasGroup.alpha = endValue;
                TweenAnimation = canvasGroup.DOFade(startValue, Duration).SetDelay(delay).SetLoops(loops, loopType).OnComplete(CallCompete).SetEase(animationCurve);
            }
        }
    }
}