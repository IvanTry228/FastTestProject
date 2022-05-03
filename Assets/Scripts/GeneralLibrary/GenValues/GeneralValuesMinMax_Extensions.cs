using UnityEngine;

namespace GenLibrary.GenValues
{
    public static class GeneralValuesMinMax_Extensions
    {
        public static float GetInverseLerp_CoeffBetween(this GeneralValuesMinMax<float> _generalValues)
        {
            float coeff = Mathf.InverseLerp(_generalValues.min, _generalValues.max, _generalValues.current);
            return coeff;
        }

        public static void SetForciblyCurrentValue(this ref GeneralValuesMinMax<float> _generalValues, float _argSetValue)
        {
            if (_generalValues.current != _argSetValue)
            {
                _generalValues.current = _argSetValue;
                _generalValues.CallExecureChangesEvent();
            }
        }

        public static void CallIncrementValue(this ref GeneralValuesMinMax<float> _generalValues, float _argSetValue)
        {
            _generalValues.current += _argSetValue;
            _generalValues.ClampCurrentValues();
            _generalValues.CallExecureChangesEvent();
        }

        public static void ClampCurrentValues(this ref GeneralValuesMinMax<float> _generalValues)
        {
            _generalValues.current = Mathf.Clamp(_generalValues.current, _generalValues.min, _generalValues.max);;
        }
    }
}