namespace TaskSystem.View
{
    using TaskSystem.Core;
    using UnityEngine;

    /// <summary>
    /// Отображает текстовое текущее значение задания
    /// </summary>
    public class CurrentValueView : TextTaskVIew
    {
        public override void InitTask(TaskSO taskSO)
        {
            base.InitTask(taskSO);
            task.OnProgressChanged += UpdateView;
        }

        protected override void UpdateView()
        {
            textValue.text = task.CurrentValue;
        }

        protected override void UnSubscribe()
        {
            base.UnSubscribe();

            if(task.IsDone)
            {
                task.OnProgressChanged -= UpdateView;
            }
        }
    }
}