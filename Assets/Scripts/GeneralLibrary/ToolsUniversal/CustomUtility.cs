using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CustomUtility : MonoBehaviour
{
    public const float defaultFixedTime = 50f;

    public static float InverseLerp(Vector3 a, Vector3 b, Vector3 value)
    {
        if (a.Equals(b))
            return 0;
        Vector3 AB = b - a;
        Vector3 AV = value - a;
        return Vector3.Dot(AV, AB) / Vector3.Dot(AB, AB);
    }

    public static float GetDistanceProjection(Vector3 worldA, Vector3 worldB, Vector3 worldM)
    {
        float inverseLerp = InverseLerp(worldA, worldB, worldM);
        Vector3 worldProject = Vector3.Lerp(worldA, worldB, inverseLerp);
        Vector3 distanceBetweenMandProject = worldProject - worldM;
        float distanceMagnitude = distanceBetweenMandProject.magnitude;
        return distanceMagnitude;
    }

    public static List<T> GetShuffleList<T>(List<T> _list)
    {
        int n = _list.Count;
        while (n > 1)
        {
            n--;
            int k = Random.Range(0, n + 1);

            T value = _list[k];
            _list[k] = _list[n];
            _list[n] = value;
        }

        return _list;
    }

    public static int GetIndexWithCountList(int _countList, float _minValue, float _maxValue, float _argValue)
    {
        if (_countList == 1) //only optimization
            return 0;

        float reverseLerpValue = Mathf.InverseLerp(_minValue, _maxValue, _argValue);
        int toReturnIndex = (int)(_countList * reverseLerpValue);

        toReturnIndex = Mathf.Clamp(toReturnIndex, 0, _countList-1);

        return toReturnIndex;
    }

    public static float GetReverseLerp(float _minValue, float _maxValue, float _argValue)
    {
        float allRange = Mathf.Abs(_maxValue - _minValue);

        float currentRange = Mathf.Abs(_argValue - _minValue);

        float reverseLerp = currentRange / allRange;

        return reverseLerp;
    }

    public static Vector3 MultiplyVectors(Vector3 _vector1, Vector3 _vector2)
    {
        Vector3 toReturnVector = new Vector3();

        toReturnVector.x = _vector1.x * _vector2.x;
        toReturnVector.y = _vector1.y * _vector2.y;
        toReturnVector.z = _vector1.z * _vector2.z;

        return toReturnVector;
    }

    public static Vector2 MultiplyVectors(Vector2 _vector1, Vector2 _vector2)
    {
        Vector3 toReturnVector = new Vector3();

        toReturnVector.x = _vector1.x * _vector2.x;
        toReturnVector.y = _vector1.y * _vector2.y;

        return toReturnVector;
    }

    public static Vector3 ConvertVectorSpaces(Vector2 _toConvert)
    {
        Vector3 toReturnVector = new Vector3();

        toReturnVector.x = _toConvert.x;
        toReturnVector.y = _toConvert.y;
        toReturnVector.z = 0;


        return toReturnVector;
    }

    public static Vector2 ConvertVectorSpaces(Vector3 _toConvert)
    {
        Vector2 toReturnVector = new Vector3();

        toReturnVector.x = _toConvert.x;
        toReturnVector.y = _toConvert.y;

        return toReturnVector;
    }

    public static Vector3 ChangeVectorAxises(Vector2 _toChangeAxisVector)
    {
        Vector3 bufferVectorToReturn = new Vector3(); //+ _toChangeAxisVector;
                                                      //bufferVectorToReturn
        bufferVectorToReturn.x = _toChangeAxisVector.x;
        bufferVectorToReturn.y = 0;
        bufferVectorToReturn.z = _toChangeAxisVector.y;

        return bufferVectorToReturn;
    }

    public static float GetSmoothFrameSpeed()
    {
        return defaultFixedTime * Time.deltaTime;
    }

    public static float InverseFloat(float _artToReverse)
    {
        return 1f / _artToReverse;
    }

    public static Vector3 GetAbsVector3(Vector3 _argVector)
    {
        _argVector.x = Mathf.Abs(_argVector.x);
        _argVector.y = Mathf.Abs(_argVector.y);
        _argVector.z = Mathf.Abs(_argVector.z);
        return _argVector;
    }

    public static Vector3 GetRoundVectorToNearInt(Vector3 _argVector)
    {
        _argVector.x = Mathf.RoundToInt( _argVector.x);
        _argVector.y = Mathf.RoundToInt(_argVector.y);
        _argVector.z = Mathf.RoundToInt(_argVector.z);
        return _argVector;
    }

    public static bool IsPositiveNumber(float _argCheck)
    {
        float answerFloat = Mathf.Sign(_argCheck);
        return answerFloat >= 0;
    }
}
