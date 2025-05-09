namespace TaskSystem.View
{
    using System.Collections.Generic;
    using TaskSystem.Core;
    using UnityEngine;

    /// <summary>
    /// Инициализирует отображения для задания
    /// </summary>
    public class TaskViewIniter : MonoBehaviour
    {
        [SerializeField]
        protected TaskSO task = null;
        [SerializeField]
        protected List<AbstractTaskView> taskViews = new List<AbstractTaskView>();

        protected virtual void Start()
        {
            taskViews.ForEach(x=>x.InitTask(task));
        }
    }
}