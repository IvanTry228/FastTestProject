using UnityEngine;

namespace GenLibrary
{
    [System.Serializable]
    public class DamageComponent
    {
        public float DamageValue;
        public Vector3 StartPosition;
        public Vector3 EndPosition;

        public Transform currentTransform;
    }
}

