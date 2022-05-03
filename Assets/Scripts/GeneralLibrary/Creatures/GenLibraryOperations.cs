using UnityEngine;

namespace GenLibrary
{
    public static class GenLibraryOperations
    {
        public static Vector3 GetDirectionWorld(Transform _target, Transform _object)
        {
            return GetDirectionWorld(_target.position, _object.position);
        }

        public static Vector3 GetDirectionWorld(Vector3 _target, Vector3 _object)
        {
            return _target - _object;
        }
    }
}