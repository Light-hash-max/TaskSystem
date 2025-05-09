namespace TaskSystem.BaseComponents
{
    using UnityEngine;

    [CreateAssetMenu(fileName = "IntValueSO", menuName = "TaskSystem/BaseComponents/IntValueSO")]
    public class IntValueSO : ScriptableObject
    {
        public ValueContainer<int> ContainerVal = new ValueContainer<int>(0);

        public string ID => id;

        [SerializeField]
        protected string id = string.Empty;
    }
}