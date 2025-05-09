namespace TaskSystem.Core
{
    using System;
    using UnityEngine;

    /// <summary>
    /// Задание для выполнения
    /// </summary>
    [CreateAssetMenu(fileName = "TaskSO", menuName = "TaskSystem/Core/TaskSO")]
    public class TaskSO : ScriptableObject
    {
        /// <summary>
        /// Изменилось значение прогресса задания
        /// </summary>
        public event Action OnProgressChanged = delegate { };

        /// <summary>
        /// Изменилось значение выполненно ли задание или нет
        /// </summary>
        public event Action OnDoneChanged = delegate { };

        /// <summary>
        /// Выполенно ли задание
        /// </summary>
        public bool IsDone
        {
            get => isDone;

            protected set
            {
                isDone = value;
                OnDoneChanged();
            }
        }

        /// <summary>
        /// Прогресс задания
        /// </summary>
        public float Progress
        {
            get => progress;

            protected set
            {
                progress = value;
                OnProgressChanged();
            }
        }

        /// <summary>
        /// Название задания
        /// </summary>
        public string Title => title;

        /// <summary>
        /// Описание задания
        /// </summary>
        public string Description => description;

        /// <summary>
        /// Значение цели в текстовом формате
        /// </summary>
        public string TargetValue => targetValue;

        /// <summary>
        /// Текущее значение в текстовом формате
        /// </summary>
        public string CurrentValue => currentValue;

        protected const float MAX_PROGRESS = 1f;

        [SerializeField]
        protected string title;
        [SerializeField, Multiline]
        protected string description;

        protected bool isDone = false;
        protected float progress = 0f;
        protected string targetValue;
        protected string currentValue;

        public virtual void Init(string currentTextVal, string targetTextVal)
        {
            targetValue = targetTextVal;
            currentValue = currentTextVal;
            IsDone = false;
            Progress = 0f;
        }

        public virtual void UpdateProgress(float progressVal, string currentTextVal)
        {
            currentValue = currentTextVal;
            Progress = progressVal;

            if (Progress >= MAX_PROGRESS)
            {
                Progress = MAX_PROGRESS;
                IsDone = true;
            }
        }
    }
}