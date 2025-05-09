namespace TaskSystem.Core
{
    using System;
    using System.Collections.Generic;
    using System.Linq;
    using TaskSystem.BaseComponents;
    using UnityEngine;
    using Zenject;

    /// <summary>
    /// Задачка по сборку опреденного количества
    /// </summary>
    public class IntValueTask : AbstractTackChecker
    {
        [SerializeField]
        protected int targetValue = 3;
        [SerializeField]
        protected List<IntValueSO> valueList = new List<IntValueSO>();

        protected int collectedVal => valueList.Sum(x => x.ContainerVal.Value);

        protected virtual void OnEnable()
        {
            InitTask();
        }

        protected virtual void OnDisable()
        {
            valueList.ForEach(x => x.ContainerVal.OnValueChanged -= UpdateTaskProgress);
        }

        protected override void InitTask()
        {

            taskSO.Init("0", targetValue.ToString());
            valueList.ForEach(x => x.ContainerVal.OnValueChanged += UpdateTaskProgress);
        }

        protected override void UpdateTaskProgress()
        {
            taskSO.UpdateProgress(collectedVal/ targetValue, collectedVal.ToString());
        }
    }
}