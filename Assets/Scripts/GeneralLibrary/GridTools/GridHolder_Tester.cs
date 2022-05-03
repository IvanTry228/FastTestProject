using System;
using UnityEngine;
using System.Collections.Generic;
using NaughtyAttributes;

namespace GenLibrary.GridTools
{
    public class GridHolder_Tester<Tmono, Tgrid> : MonoBehaviour
                                                    where Tmono : MonoBehaviour where Tgrid : MonoBehaviour, IGridItem<Tmono>
    {
        [SerializeField]
        private GridHolder<Tmono, Tgrid> current_GridHolder;

        [SerializeField]
        private List<Tgrid> GetTGrid = new List<Tgrid>();

        [SerializeField]
        private Tgrid current_test_Tgrid;

        [SerializeField]
        private Vector3 testQUery = new Vector3(1, 1, 0);

        [Button]
        public void Test_ExecuteQuery1()
        {
            current_test_Tgrid = current_GridHolder.GetItemByGridStruct(testQUery);
        }

        [Button]
        public void Test_ExecuteQuery2_by_x()
        {
            var expression = new Func<Tgrid, bool>(item => item.GetGridPosition().gridPos.x == testQUery.x);
            GetTGrid = current_GridHolder.GetItemsByExpression(expression);
        }

        [Button]
        public void Test_ExecuteQuery3_invert()
        {
            var expression = new Func<Tgrid, bool>(item => item.GetGridPosition().gridPos.x != testQUery.x);
            GetTGrid = current_GridHolder.GetItemsByExpression(expression);
        }
    }
}