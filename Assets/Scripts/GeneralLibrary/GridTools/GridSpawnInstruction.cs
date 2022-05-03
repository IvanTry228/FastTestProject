using UnityEngine;

namespace GenLibrary.GridTools
{
    [System.Serializable]
    public struct GridSpawnInstruction
    {
        public Vector3 sizeGridInstruct;
        public Vector3 sizeOffsetInstruct;
        public bool isDependSizeFromScale;

        public bool isRelativeSpawn;

        public GridSpawnInstruction(bool _isMarker)
        {
            this = default;
            sizeGridInstruct = Vector3.one;
            sizeOffsetInstruct = Vector3.one;
        }
    }
}
