namespace TweenAnimation
{
    using DG.Tweening;
    using UnityEngine;

    /// <summary>
    /// Твин скейла
    /// </summary>
    public class TweenScale : AbstractTween
    {
        [SerializeField]
        protected Vector3 endValue = Vector3.one;
        [SerializeField]
        protected Vector3 startValue = Vector3.one;

        public override void StopAnimation()
        {
            base.StopAnimation();
            transform.localScale = startValue;
        }

        public override void Revert()
        {
            transform.localScale = endValue;
            TweenAnimation = transform.DOScale(startValue, Duration).SetDelay(delay).SetLoops(loops, loopType).OnComplete(CallCompete).SetEase(animationCurve);
        }

        public override void Tween()
        {
            transform.localScale = startValue;
            TweenAnimation = transform.DOScale(endValue, Duration).SetDelay(delay).SetLoops(loops, loopType).OnComplete(CallCompete).SetEase(animationCurve);
        }
    }
}