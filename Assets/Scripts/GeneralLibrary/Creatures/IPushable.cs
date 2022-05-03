using UnityEngine;

namespace GenLibrary
{
    public interface IPushable
    {
        public void ToPushByWorldPos(Vector3 _positionWorld, float _coeffForce = 1f);
        public void ToPush(Vector3 _directionNormalize, float _coeffForce = 1f);
    }
}