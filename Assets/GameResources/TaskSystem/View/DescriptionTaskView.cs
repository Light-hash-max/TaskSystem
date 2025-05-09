namespace TaskSystem.View
{
    using UnityEngine;

    /// <summary>
    /// Описание задания
    /// </summary>
    public class DescriptionTaskView : TextTaskVIew
    {
        protected override void UpdateView()
        {
            textValue.text = task.Description;
        }
    }
}