namespace TaskSystem.View
{
    using UnityEngine;

    /// <summary>
    /// Заголовок задания
    /// </summary>
    public class TitleTaskView : TextTaskVIew
    {
        protected override void UpdateView()
        {
            textValue.text = task.Title;
        }
    }
}