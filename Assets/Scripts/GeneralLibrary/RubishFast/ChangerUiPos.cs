using UnityEngine;

public class ChangerUiPos : MonoBehaviour
{
    [SerializeField]
    private RectTransform currentUi;

    public void SetPositionX(int _posX)
    {
        var varREct = currentUi.transform.position;
        varREct.x = _posX;

        currentUi.transform.position = varREct;
    }
}
