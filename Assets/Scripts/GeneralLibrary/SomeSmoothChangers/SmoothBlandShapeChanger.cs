using UnityEngine;

[System.Serializable]
public class SmoothBlandShapeChanger : SmoothChangerFloatImplement
{
    [SerializeField]
    private BlandShapeSkinChangeManager currentBlandShapeChanger;

    [SerializeField]
    private float coeffMultiToBlandShape = 100f;

    protected override void RealizationChange(float _argNewCoeff)
    {
        base.RealizationChange(_argNewCoeff);
        currentBlandShapeChanger.SetWeightBlandshapes(_argNewCoeff*coeffMultiToBlandShape);
    }

}
