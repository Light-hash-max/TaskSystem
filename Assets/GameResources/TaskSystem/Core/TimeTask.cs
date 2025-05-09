namespace TaskSystem.Core
{
    using FunnyBaloons.Timer;
    using System;
    using UnityEngine;
    using Zenject;

    /// <summary>
    /// Задание - подождать определенное время
    /// </summary>
    public class TimeTask : AbstractTackChecker
    {
        [SerializeField]
        protected int seconds = 10;

        protected Timer timer = default;

        [Inject]
        protected virtual void Construct(Timer countdownTimer) => timer = countdownTimer;

        protected virtual void OnEnable()
        {
            InitTask();
        }

        protected virtual void OnDisable()
        {
            timer.OnTick -= UpdateTaskProgress;
        }

        protected override void InitTask()
        {
            taskSO.Init("0:00", TimeSpan.FromSeconds(seconds).ToString(@"mm\:ss"));
            timer.StartTimer(seconds, 0);
            timer.OnTick += UpdateTaskProgress;
        }

        protected override void UpdateTaskProgress()
        {
            taskSO.UpdateProgress((float)timer.CurrentSeconds / seconds, TimeSpan.FromSeconds(timer.CurrentSeconds).ToString(@"mm\:ss"));
        }
    }
}