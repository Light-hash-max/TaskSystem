namespace TaskSystem.View
{
    using UnityEngine;
    using UnityEngine.UI;

    /// <summary>
    /// Текстовое отображение задания
    /// </summary>
    [RequireComponent(typeof(Text))]
    public abstract class TextTaskVIew : AbstractTaskView
    {
        protected Text textValue = null;

        protected override void InitView()
        {
            if (textValue == null)
            {
                textValue = GetComponent<Text>();
            }
        }
    }
}