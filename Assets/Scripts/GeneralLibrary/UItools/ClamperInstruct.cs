using UnityEngine;

namespace GenLibrary
{
    [System.Serializable]
    public class ClamperInstruct
    {
        [SerializeField]
        private float clampMin = defaultMin;
        [SerializeField]
        private float clampMax = defaultMax;

        [SerializeField]
        private bool isClamp = true;

        private const float defaultMin = 0f;
        private const float defaultMax = 1f;

        [SerializeField]
        private float log_lastValue = -1f;

        public void SetClampMinMax(float _minClamp, float _maxClamp)
        {
            isClamp = true;
            clampMin = _minClamp;
            clampMax = _maxClamp;
        }

        public void Reinit()
        {
            clampMin = defaultMin;
            clampMin = defaultMax;
            isClamp = false;
        }

        public float GetClampedValue(float _query)
        {
            if (!isClamp)
            {
                log_lastValue = _query;
                return _query;
            }
            else
            {
                log_lastValue = Mathf.Clamp(_query, clampMin, clampMax);
                return log_lastValue;
            }
        }
    }

}

