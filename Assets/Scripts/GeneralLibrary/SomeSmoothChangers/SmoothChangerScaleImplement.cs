using UnityEngine;

[System.Serializable]
public class SmoothChangerScaleImplement : SmoothChangerVectorImplement
{
    [SerializeField]
    private Transform objOfScale;

    protected override void RealizationChange(float _argNewCoeff)
    {
        base.RealizationChange(_argNewCoeff);
        SetLocalScale(objOfScale, genericValueCurrentAfterChanging);
    }

    private void SetLocalScale(Transform _objOfTransform, Vector3 _localScale)
    {
        _objOfTransform.localScale = _localScale;
    }

    public void SetTransform(Transform _argNewTransform)
    {
        objOfScale = _argNewTransform;
    }
}
