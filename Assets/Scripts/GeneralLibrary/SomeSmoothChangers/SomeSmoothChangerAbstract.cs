using System;
using System.Collections;
using UnityEngine;

public class SomeSmoothChangerAbstract<T> //: MonoBehaviour
{
    [SerializeField]
    private float currentCoeff; //0-1f;
    [SerializeField]
    private AnimationCurve currentAnimCurv = AnimationCurve.Linear(0f, 0f, 1f, 1f);

    [SerializeField]
    protected T genericValueCurrentAfterChanging;
    [SerializeField]
    protected T genericValueStart;
    [SerializeField]
    protected T genericValueTarget;

    private Coroutine bodyChangeCoroutine;

    [SerializeField]
    private float speedChanging = 0.02f;

    private const float minLerp = 0f;
    private const float maxLerp = 1f;

    [SerializeField]
    private MonoBehaviour orderMonobeh;

    public event Action<T> OnValueChanged;
    public event Action OnValueReachedTarget;

    public void CallChangeSome(T _start, T _target)
    {
        genericValueStart = _start;
        genericValueTarget = _target;
        bodyChangeCoroutine = CustomCoroutines.GetCorrectStartCoroutineWithReset(orderMonobeh, bodyChangeCoroutine, ProcedureSmoothChange());
    }

    public void CallCancelProcedure()
    {
        CustomCoroutines.CallTryStopCoroutine(orderMonobeh, bodyChangeCoroutine);
    }

    private IEnumerator ProcedureSmoothChange()
    {
        for (float fi = minLerp; fi <= maxLerp; fi += GetLerpSpeedChange())
        {
            currentCoeff = currentAnimCurv.Evaluate(fi);
            RealizationChange(currentCoeff);
            yield return null;
        }
        currentCoeff = maxLerp;
        RealizationChange(maxLerp);
        OnValueReachedTarget?.Invoke();
    }

    private float GetLerpSpeedChange()
    {
        return speedChanging * CustomUtility.GetSmoothFrameSpeed();
    }

    protected virtual void RealizationChange(float _argNewCoeff)
    {
        OnValueChanged?.Invoke(genericValueCurrentAfterChanging);
    }
}
