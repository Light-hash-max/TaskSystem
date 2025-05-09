namespace TaskSystem.Core
{
    using System;
    using TaskSystem.BaseComponents;
    using UnityEngine;
    using UnityEngine.EventSystems;

    /// <summary>
    /// Увеличивает колиество тапов при нажатии
    /// </summary>
    [RequireComponent(typeof(Collider))]
    public class TapCount : MonoBehaviour, IPointerClickHandler
    {
        public event Action OnClicked = delegate { };

        [SerializeField]
        protected bool isOnlyOnce = true;
        [SerializeField]
        protected IntValueSO valueSO;

        protected bool isClicked = false;

        void IPointerClickHandler.OnPointerClick(PointerEventData eventData)
        {
            if (!isClicked || !isOnlyOnce)
            {
                isClicked = true;
                valueSO.ContainerVal.Value++;
                OnClicked();
            }
        }
    }
}