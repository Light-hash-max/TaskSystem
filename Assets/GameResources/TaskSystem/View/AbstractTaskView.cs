namespace TaskSystem.View
{
    using TaskSystem.Core;
    using UnityEngine;

    /// <summary>
    /// Абстрактный класс для обновления вьюшки задания
    /// </summary>
    public abstract class AbstractTaskView : MonoBehaviour
    {
        protected TaskSO task = null;

        public virtual void InitTask(TaskSO taskSO)
        {
            InitView();
            task = taskSO;
            UpdateView();
            task.OnDoneChanged += UpdateView;
            task.OnDoneChanged += UnSubscribe;
        }

        protected abstract void InitView();

        protected abstract void UpdateView();

        protected virtual void UnSubscribe()
        {
            if (task.IsDone)
            {
                task.OnDoneChanged -= UpdateView;
                task.OnDoneChanged -= UnSubscribe;
            }
        }
    }
}