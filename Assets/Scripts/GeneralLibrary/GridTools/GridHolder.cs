using System;
using System.Linq;
using UnityEngine;
using System.Collections.Generic;

namespace GenLibrary.GridTools
{

    public class GridHolder<Tmono, Tgrid> : MonoBehaviour, IGridHolderRepository<Tmono, Tgrid> 
                                                    where Tmono : MonoBehaviour where Tgrid : MonoBehaviour, IGridItem<Tmono>
    {
        [SerializeField] //[ReadOnly]
        private List<Tgrid> allGridItemsList = new List<Tgrid>();
        [SerializeField] //[ReadOnly]
        private List<Tmono> allMonoItemsList = new List<Tmono>();

        public List<Tmono> GetItems()
        {
            return allMonoItemsList;
        }

        public Tgrid GetItemByExpression(Func<Tgrid, bool> _expressionPredicate)
        {
            return GetItemsByExpression(_expressionPredicate).FirstOrDefault();
        }

        public List<Tgrid> GetItemsByExpression(Func<Tgrid, bool> _expressionPredicate)
        {
            var results = allGridItemsList.Where(_expressionPredicate);
            return results.ToList();
        }

        public Tgrid GetItemByGridStruct(Vector3 _gridPos)
        {
            return GetByDictionaryTGridByStruct(_gridPos);
        }

        public void AddItem(Tgrid _item)
        {
            allGridItemsList.Add(_item);
            allMonoItemsList.Add(_item.GetCurrentItem());
        }

        public void RemoveItem(Tgrid _item)
        {
            allGridItemsList.Remove(_item);
            allMonoItemsList.Remove(_item.GetCurrentItem());
        }

        public void ClearAll()
        {
            foreach (var item in allGridItemsList)
            {
                if (item != null)
                    ClearDeleteItem(item);
            }

            allGridItemsList.Clear();
            allMonoItemsList.Clear();
        }

        protected virtual void ClearDeleteItem(Tgrid _itemToDelete)
        {
            if(_itemToDelete.GetCurrentItem())
                UnityEngine.Object.DestroyImmediate(_itemToDelete.GetCurrentItem().gameObject);

            UnityEngine.Object.DestroyImmediate(_itemToDelete.gameObject);
        }

        //dictionary
        private Dictionary<Vector3, Tgrid> dict_VectorWithGrids = new Dictionary<Vector3, Tgrid>();

        protected virtual void UpdateDictionaryHolder()
        {
            var currentSourceList = allGridItemsList;

            dict_VectorWithGrids = new Dictionary<Vector3, Tgrid>(currentSourceList.Count);

            foreach (var item in currentSourceList)
            {
                InsertGridItemToDictionary(item, dict_VectorWithGrids);
            }
        }

        protected virtual void InsertGridItemToDictionary(Tgrid _item, Dictionary<Vector3, Tgrid> _dictionaryHolder)
        {
            Vector3 currentKey = _item.GetGridPosition().gridPos;
            _dictionaryHolder.Add(currentKey, _item);
        }

        protected Tgrid GetByDictionaryTGridByStruct(Vector3 _gridStruct)
        {
            EnsureInitDictionary();
            Tgrid someGrid;
            bool result = dict_VectorWithGrids.TryGetValue(_gridStruct, out someGrid);
            if (result)
                return someGrid;
            else
                return default;
        }

        private void EnsureInitDictionary()
        {
            if (allGridItemsList.Count != dict_VectorWithGrids.Count!)
                UpdateDictionaryHolder();
        }
    }

}
