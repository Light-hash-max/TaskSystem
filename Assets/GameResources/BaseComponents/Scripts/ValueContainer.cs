namespace TaskSystem.BaseComponents
{
    using System;
    using UnityEngine;

    public class ValueContainer<T>
    {
        public event Action OnValueChanged = delegate { };

        public T Value
        {
            get => _value;

            set
            {
                _value = value;
                OnValueChanged();
            }
        }

        private T _value;

        public ValueContainer(T value)
        {
            _value = value;
        }
    }
}