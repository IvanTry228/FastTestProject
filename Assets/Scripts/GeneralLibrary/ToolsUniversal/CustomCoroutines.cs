using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CustomCoroutines : MonoSingletoneBehaviour<CustomCoroutines>
{
    public void CorrectStartCoroutineWithReset(IEnumerator _coroutine, IEnumerator _procedureInstruction)
    {
        if (_coroutine != null)
            StopCoroutine(_coroutine);

        _coroutine = null;

        _coroutine = _procedureInstruction;
        StartCoroutine(_coroutine);
    }

    public static Coroutine GetCorrectStartCoroutineWithReset(MonoBehaviour _someBehaviour, Coroutine _corout, IEnumerator _procedureInstruction)
    {
        if (_corout != null)
            _someBehaviour.StopCoroutine(_corout);

        _corout = _someBehaviour.StartCoroutine(_procedureInstruction);

        return _corout;
    }

    public static void CallTryStopCoroutine(MonoBehaviour _someBehaviour, Coroutine _corout)
    {
        if (_corout != null)
            _someBehaviour.StopCoroutine(_corout);
    }

    public static Coroutine ToDoSomethingWithResetCoroutine(MonoBehaviour _someBehaviour, Coroutine _corout, Action _someAction, float _timeWaitSec)
    {
        IEnumerator bufferInstruction = WaitingCoroutine(_someAction, _timeWaitSec);
        _corout = GetCorrectStartCoroutineWithReset(_someBehaviour, _corout, bufferInstruction);
        return _corout;
    }

    public static IEnumerator WaitingCoroutine(Action _someAction, float _timeWaitSec)
    {
        yield return new WaitForSeconds(_timeWaitSec);
        _someAction?.Invoke();
    }
}
