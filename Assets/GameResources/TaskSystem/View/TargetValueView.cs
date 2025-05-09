namespace TaskSystem.View
{
    using UnityEngine;

    /// <summary>
    /// Отображает текстовое целевое значение задания
    /// </summary>
    public class TargetValueView : TextTaskVIew
    {
        protected override void UpdateView()
        {
            textValue.text = task.TargetValue;
        }
    }
}