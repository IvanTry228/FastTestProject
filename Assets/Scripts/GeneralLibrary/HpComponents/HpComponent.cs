using UnityEngine;
using System;
using GenLibrary.GenValues;

namespace GenLibrary.HpComponents
{
    [System.Serializable]
    public class HpComponent : IHpComponent<float>
    {
        [SerializeField]
        private bool IsAlive = true;
        [SerializeField]
        private GeneralValuesMinMax<float> hpValues = new GeneralValuesMinMax<float>(0f, 100f);

        public event Action<IDieable> OnDie;

        public bool IsDead()
        {
            return !IsInAlive();
        }

        public bool IsInAlive()
        {
            return IsAlive;
        }

        public void ToDie()
        {
            if (!IsDead())
            {
                hpValues.ClampCurrentValues();
                IsAlive = false;
                OnDie?.Invoke(this);
            }
        }

        public void DecrementValue(float _argIncrementValue, out bool _isToDie)
        {
            _argIncrementValue = Mathf.Abs(_argIncrementValue);
            hpValues.current -= _argIncrementValue;
            _isToDie = IsCheckNewStateToDie();
        }

        public GeneralValuesMinMax<float> GetHpValuesRead()
        {
            return hpValues;
        }

        private bool IsCheckNewStateToDie()
        {
            bool isToDie = hpValues.current < hpValues.min;
            if (isToDie)
            {
                ToDie();
            }
            return isToDie;
        }

        public void InitAndSet(GeneralValuesMinMax<float> _hpValues, bool _isInAlive = true)
        {
            IsAlive = _isInAlive;
            hpValues = _hpValues;
        }

        public void Init()
        {
            InitAndSet(hpValues, IsAlive);
        }
    }
}

