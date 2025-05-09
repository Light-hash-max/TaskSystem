namespace TaskSystem.View
{
    using TaskSystem.Core;
    using UnityEngine;
    using UnityEngine.UI;

    /// <summary>
    /// Слайдер прогресса задания
    /// </summary>
    [RequireComponent(typeof(Slider))]
    public class ProgressSliderView : AbstractTaskView
    {
        protected Slider slider = null;

        protected override void InitView()
        {
            if (slider == null)
            {
                slider = GetComponent<Slider>();
            }
        }

        public override void InitTask(TaskSO taskSO)
        {
            base.InitTask(taskSO);
            task.OnProgressChanged += UpdateView;
        }

        protected override void UpdateView()
        {
            slider.value = task.Progress;
        }

        protected override void UnSubscribe()
        {
            base.UnSubscribe();

            if (task.IsDone)
            {
                task.OnProgressChanged -= UpdateView;
            }
        }
    }
}