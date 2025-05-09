namespace FunnyBaloons.Timer
{
    using System;
    using System.Threading;
    using System.Threading.Tasks;
    using UnityEngine;

    /// <summary>
    /// Таймер
    /// </summary>
    public class Timer
    {
        /// <summary>
        /// Прошла секуда
        /// </summary>
        public event Action OnTick = delegate { };

        /// <summary>
        /// Завершился таймер
        /// </summary>
        public event Action OnTimerComplete = delegate { };

        /// <summary>
        /// Запущен ли таймер
        /// </summary>
        public bool IsRunning { get; protected set; } = false;

        /// <summary>
        /// Время таймера
        /// </summary>
        public int CurrentSeconds { get; protected set; } = 0;

        protected int targetSeconds = 0;
        protected int deltaSeconds = 0;

        protected CancellationTokenSource cancellationTokenSource = default;

        /// <summary>
        /// Запустить таймер
        /// </summary>
        public virtual async void StartTimer(int target, int startSeconds, int delta = 1)
        {
            targetSeconds = target;
            CurrentSeconds = startSeconds;
            deltaSeconds = delta;
            OnTick();
            await StartCountdown();
        }

        protected virtual async Task StartCountdown()
        {
            cancellationTokenSource = new CancellationTokenSource();

            IsRunning = true;

            while (CurrentSeconds != targetSeconds)
            {
                if (cancellationTokenSource.Token.IsCancellationRequested) break;
                await Task.Delay(1000, cancellationTokenSource.Token);
                CurrentSeconds += deltaSeconds;
                OnTick();
            }

            IsRunning = false;
            OnTimerComplete();
        }

        /// <summary>
        /// Остановить таймер
        /// </summary>
        public void StopCountdown()
        {
            cancellationTokenSource.Cancel();
            IsRunning = false;
            OnTimerComplete();
        }
    }
}