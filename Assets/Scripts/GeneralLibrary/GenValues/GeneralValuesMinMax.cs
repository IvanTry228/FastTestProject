using System;

namespace GenLibrary.GenValues
{
    [Serializable]
    public struct GeneralValuesMinMax<T>
    {
        public T current;
        public T min;
        public T max;

        public event Action<T> OnValueChanged;

        public void CallExecureChangesEvent()
        {
            OnValueChanged?.Invoke(current);
        }

        public GeneralValuesMinMax(T _min, T _max)
        {
            this = new GeneralValuesMinMax<T>(_min, _max, _max);
        }

        public GeneralValuesMinMax(T _min, T _max, T _current)
        {
            this = default;

            min = _min;
            max = _max;

            current = _current;
        }
    }
}

