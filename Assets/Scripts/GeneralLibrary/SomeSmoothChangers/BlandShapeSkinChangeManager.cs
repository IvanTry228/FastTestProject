using UnityEngine;

[System.Serializable]
public class BlandShapeSkinChangeManager //: MonoBehaviour
{
    [SerializeField]
    private SkinnedMeshRenderer currentSkinMesh;

    [SerializeField]
    private int[] indexesOfBlandshapes = new int[] { 0 };

    public void SetWeightBlandshapes(float _coeff)
    {
        foreach (int item in indexesOfBlandshapes)
        {
            currentSkinMesh.SetBlendShapeWeight(item, _coeff);
        }
    }
}
