using UnityEngine;

namespace GenLibrary.Spawns
{
    public class SpawnPrefabsUtility
    {
        public static T GetSpawnedInstantiateWithType<T>(T _sourcePrefab, Transform _parent = default) where T : MonoBehaviour
        {
            GameObject spawnedGrid = ObjectInstantiate(_sourcePrefab.gameObject, _parent); //(GameObject)UnityEditor.PrefabUtility.InstantiatePrefab(_gridItem_prefab, parentOfSpawn);
            T someItem = spawnedGrid.GetComponent<T>();
            return someItem;
        }

        public static GameObject ObjectInstantiate(GameObject obj, Transform _parent = default) //vector3 (possibly override)
        {
#if UNITY_EDITOR
            var _objectToArrayPrefabPath = UnityEditor.PrefabUtility.GetPrefabAssetPathOfNearestInstanceRoot(obj);
            GameObject _objecttoArrayPrefab = (GameObject)UnityEditor.AssetDatabase.LoadAssetAtPath(_objectToArrayPrefabPath, typeof(GameObject));
            return (GameObject)UnityEditor.PrefabUtility.InstantiatePrefab(_objecttoArrayPrefab, _parent);
#endif
            //if(Application.isPlaying)
            return Object.Instantiate(obj, _parent);
        }
    }
}