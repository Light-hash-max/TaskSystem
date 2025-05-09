namespace TweenAnimation
{
    using DG.Tweening;
    using UnityEngine;

    public class TweenTransform : AbstractTween
    {
        [SerializeField]
        protected Transform endValue;
        [SerializeField]
        protected Transform startValue;
        [SerializeField]
        protected bool isLocal = true;
        [SerializeField]
        protected bool isResetStartValue = true;

        public override void Tween()
        {
            if (isLocal)
            {
                transform.localPosition = startValue.localPosition;
                TweenAnimation = transform.DOLocalMove(endValue.localPosition, Duration).SetDelay(delay).SetLoops(loops, loopType).OnComplete(CallCompete).SetEase(animationCurve);
            }
            else
            {
                transform.position = startValue.position;
                TweenAnimation = transform.DOMove(endValue.position, Duration).SetDelay(delay).SetLoops(loops, loopType).OnComplete(CallCompete).SetEase(animationCurve);
            }
        }

        public override void StopAnimation()
        {
            base.StopAnimation();

            if (isResetStartValue)
            {
                if (isLocal)
                {
                    transform.localPosition = startValue.localPosition;
                }
                else
                {
                    transform.position = startValue.position;
                }
            }
        }

        public override void Revert()
        {
            if (isLocal)
            {
                transform.localPosition = endValue.localPosition;
                TweenAnimation = transform.DOLocalMove(startValue.localPosition, Duration).SetDelay(delay).SetLoops(loops, loopType).OnComplete(CallCompete).SetEase(animationCurve);
            }
            else
            {
                transform.position = endValue.position;
                TweenAnimation = transform.DOMove(startValue.position, Duration).SetDelay(delay).SetLoops(loops, loopType).OnComplete(CallCompete).SetEase(animationCurve);
            }
        }
    }
}