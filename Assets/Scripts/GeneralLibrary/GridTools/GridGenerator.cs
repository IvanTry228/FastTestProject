using UnityEngine;
using NaughtyAttributes;
using GenLibrary.Spawns;

namespace GenLibrary.GridTools
{
    [System.Serializable]
    public struct GridPosition
    {
        public Vector3 gridPos;

        public GridPosition(Vector3 _gridPos)
        {
            gridPos = _gridPos;
        }
    }

    public interface IGridItem<T> where T : MonoBehaviour 
    {
        public T GetCurrentItem(); // { get; set; }

        public GridPosition GetGridPosition(); // { get; set; }

        public void Init(T _item, Vector3 _gridStruct);
    }

    public interface IGridHolderRepository<Tmono, Tgrid> : IRepositoryGetters<Tgrid>,  IRepository<Tmono> where Tgrid : IGridItem<Tmono> where Tmono : MonoBehaviour
    {
        public Tgrid GetItemByGridStruct(Vector3 _gridPos);
    }

    public class GridGenerator<Tmono, Tgrid> : MonoBehaviour
                               where Tmono : MonoBehaviour where Tgrid : MonoBehaviour, IGridItem<Tmono>
    {
        [SerializeField]
        private GridSpawnInstruction currentGridInstruct = new GridSpawnInstruction(default);

        [SerializeField]
        protected GridHolder<Tmono, Tgrid> currentGridHolder = new GridHolder<Tmono, Tgrid>();

        [SerializeField]
        private SpawnPrefabProvider<Tmono> currentSpawnPrefabProvider_mono; //ISpawnGetterProvider<T> ispawnerProvider = new SpawnPrefabProvider<T>();
        [SerializeField]
        private SpawnPrefabProvider<Tgrid> currentSpawnPrefabProvider_grid; //ISpawnGetterProvider<T> ispawnerProvider = new SpawnPrefabProvider<T>();

        [Button]
        public void CallGenerateGrid()
        {
            GetGenerateGrid(currentGridInstruct);
        }

        public void GetGenerateGrid(GridSpawnInstruction _instruct)
        {
            currentGridHolder.ClearAll();

            Vector3 sizeGrid = _instruct.sizeGridInstruct;

            for (int zi = default; zi < sizeGrid.z; zi++)
            {
                for (int yi = default; yi < sizeGrid.y; yi++)
                {
                    for (int xi = default; xi < sizeGrid.x; xi++)
                    {
                        Vector3 gridStruct = new Vector3(xi, yi, zi);
                        ToSetGrid(_instruct, gridStruct);
                    }
                }
            }

            #if UNITY_EDITOR
                UnityEditor.EditorUtility.SetDirty(gameObject);
                UnityEditor.EditorUtility.SetDirty(this);
                UnityEditor.EditorUtility.SetDirty(currentGridHolder);
            #endif
        }

        public static string GetTextString(in Vector3 _vector)
        {
            return "(" + _vector.x + "," + _vector.y + "," + _vector.z + ")";
        }

        protected virtual void ToSetGrid(in GridSpawnInstruction _instruct, in Vector3 _gridStruct)
        {
            var bufferItem = GetItemSpawned();
            Transform bufferItemTransform = bufferItem.transform;
            Vector3 scaleMulti = bufferItemTransform.lossyScale;

            Vector3 positionSpace = Vector3.Scale(_gridStruct, _instruct.sizeOffsetInstruct);

            if (_instruct.isDependSizeFromScale)
                positionSpace = Vector3.Scale(positionSpace, scaleMulti);

            if (_instruct.isRelativeSpawn)
            {
                Vector3 parentWorldPos = bufferItemTransform.parent.position;
                positionSpace = parentWorldPos + positionSpace;
            }

            bufferItemTransform.position = positionSpace;

            string setName = bufferItem.name + GetTextString(_gridStruct); // "_" + _gridStruct.x + "," + _gridStruct.y + "," + _gridStruct.z;
            bufferItem.name = setName;

            //grid:
            Tgrid bufferGrid = GetItemGridNew();
            bufferGrid.Init(bufferItem, _gridStruct);

            currentGridHolder.AddItem(bufferGrid);
        }

        private Tmono GetItemSpawned()
        {
            Tmono spawned = currentSpawnPrefabProvider_mono.GetItem();
            return spawned;
        }

        protected virtual Tgrid GetItemGridNew()
        {
            return currentSpawnPrefabProvider_grid.GetItem();
        }
    }

}
