using UnityEngine;

namespace GenLibrary.GridTools
{
    [System.Serializable]
    public class GridTileItem<T> : MonoBehaviour, IGridItem<T> where T : MonoBehaviour
    {
        [SerializeField]
        private GridPosition currentGridPos;

        [SerializeField]
        private T currentItem;

        public T GetCurrentItem()
        {
            return currentItem;
        }

        public GridPosition GetGridPosition()
        {
            return currentGridPos;
        }

        public void Init(T _item, Vector3 _gridStruct)
        {
            currentItem = _item;
            currentGridPos = new GridPosition(_gridStruct);
        }
    }

}
