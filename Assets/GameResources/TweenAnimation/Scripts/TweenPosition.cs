namespace TweenAnimation
{
    using DG.Tweening;
    using UnityEngine;

    /// <summary>
    /// Твин позиции
    /// </summary>
    public class TweenPosition : AbstractTween
    {
        [SerializeField]
        protected Vector3 endValue = Vector3.one;
        [SerializeField]
        protected Vector3 startValue = Vector3.one;
        [SerializeField]
        protected bool isLocal = true;
        [SerializeField]
        protected bool isResetStartValue = true;

        public override void Tween()
        {
            if (isLocal )
            {
                transform.localPosition = startValue;
                TweenAnimation = transform.DOLocalMove(endValue, Duration).SetDelay(delay).SetLoops(loops, loopType).OnComplete(CallCompete).SetEase(animationCurve);
            }
            else
            {
                transform.position = startValue;
                TweenAnimation = transform.DOMove(endValue, Duration).SetDelay(delay).SetLoops(loops, loopType).OnComplete(CallCompete).SetEase(animationCurve);
            }
        }

        public override void StopAnimation()
        {
            base.StopAnimation();

            if (isResetStartValue)
            {
                if (isLocal)
                {
                    transform.localPosition = startValue;
                }
                else
                {
                    transform.position = startValue;
                }
            }
        }

        public override void Revert()
        {
            if (isLocal)
            {
                transform.localPosition = endValue;
                TweenAnimation = transform.DOLocalMove(startValue, Duration).SetDelay(delay).SetLoops(loops, loopType).OnComplete(CallCompete).SetEase(animationCurve);
            }
            else
            {
                transform.position = endValue;
                TweenAnimation = transform.DOMove(startValue, Duration).SetDelay(delay).SetLoops(loops, loopType).OnComplete(CallCompete).SetEase(animationCurve);
            }
        }
    }
}