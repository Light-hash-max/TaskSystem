namespace TaskSystem.Core
{
    using UnityEngine;

    /// <summary>
    /// Проверяет и обновляет статус задания
    /// </summary>
    public abstract class AbstractTackChecker : MonoBehaviour
    {
        [SerializeField]
        protected TaskSO taskSO;

        protected abstract void InitTask();

        protected abstract void UpdateTaskProgress();
    }
}