using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[System.Serializable]
public class SmoothChangerFloatImplement : SomeSmoothChangerAbstract<float>
{
    protected override void RealizationChange(float _argNewCoeff)
    {
        genericValueCurrentAfterChanging = Mathf.LerpUnclamped(genericValueStart, genericValueTarget, _argNewCoeff);
        base.RealizationChange(_argNewCoeff);
    }
}
