using UnityEngine;

namespace GenLibrary.Spawns
{
    public interface ISpawnGetterProvider<T>
    {
        public T GetItem();
    }

    public class SpawnPrefabProvider<T> : MonoBehaviour, ISpawnGetterProvider<T> where T : MonoBehaviour
    {
        [SerializeField]
        public T sourcePrefab;
        [SerializeField]
        private Transform currentParent;

        public T GetItem()
        {
            T item_spawnedPRefab = SpawnPrefabsUtility.GetSpawnedInstantiateWithType(sourcePrefab, currentParent);
            return item_spawnedPRefab;
        }
    }

}
