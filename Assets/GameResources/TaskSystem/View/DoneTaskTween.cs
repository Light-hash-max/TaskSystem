namespace TaskSystem.View
{
    using System.Collections.Generic;
    using TweenAnimation;
    using UnityEngine;

    /// <summary>
    /// Твин при выполнении задания
    /// </summary>
    public class DoneTaskTween : AbstractTaskView
    {
        [SerializeField]
        protected List<AbstractTween> tweens = new List<AbstractTween> ();

        protected override void InitView()
        {
            tweens.ForEach(x => x.StopAnimation());
        }

        protected override void UpdateView()
        {
            if (task.IsDone)
            {
                tweens.ForEach(x => x.Tween());
            }
        }
    }
}