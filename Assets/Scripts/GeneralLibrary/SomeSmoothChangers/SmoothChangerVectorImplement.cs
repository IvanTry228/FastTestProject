using UnityEngine;

//[System.Serializable]
public class SmoothChangerVectorImplement : SomeSmoothChangerAbstract<Vector3>
{
    protected override void RealizationChange(float _argNewCoeff)
    {
        base.RealizationChange(_argNewCoeff);
        genericValueCurrentAfterChanging = Vector3.LerpUnclamped(genericValueStart, genericValueTarget, _argNewCoeff);
    }
}
