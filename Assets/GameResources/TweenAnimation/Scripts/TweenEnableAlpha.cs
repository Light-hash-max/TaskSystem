namespace TweenAnimation
{
    using UnityEngine;

    /// <summary>
    /// Твин прозрачности на OnEnable
    /// </summary>
    [RequireComponent(typeof(CanvasGroup))]
    public class TweenEnableAlpha : TweenAlpha
    {
        protected override void OnEnable()
        {
            base.OnEnable();
            Tween();
        }
    }
}