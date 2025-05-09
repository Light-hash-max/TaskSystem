namespace TweenAnimation
{
    using DG.Tweening;
    using UnityEditor;
    using UnityEngine;

    /// <summary>
    /// Твин поворота
    /// </summary>
    public class TweenRotation : AbstractTween
    {
        [SerializeField]
        protected Vector3 endValue = Vector3.one;
        [SerializeField]
        protected Vector3 startValue = Vector3.one;

        public override void Tween()
        {
            transform.eulerAngles = startValue;
            TweenAnimation = transform.DORotate(endValue, Duration).SetDelay(delay).SetLoops(loops, loopType).OnComplete(CallCompete).SetEase(animationCurve);
        }

        public override void StopAnimation()
        {
            base.StopAnimation();
            transform.eulerAngles = startValue;
        }

        public override void Revert()
        {
            transform.eulerAngles = endValue;
            TweenAnimation = transform.DORotate(startValue, Duration).SetDelay(delay).SetLoops(loops, loopType).OnComplete(CallCompete).SetEase(animationCurve);
        }
    }
}