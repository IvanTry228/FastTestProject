using System.Collections.Generic;
using UnityEngine;
using NaughtyAttributes;

namespace GenLibrary.Pagination
{
    public class MultiPaginationAdapter : MonoBehaviour
    {
        [SerializeField]
        private Pagination_ModelsController mainPaginationController;

        [SerializeField]
        private List<Pagination_ModelsController> currentControllers;

        [SerializeField]
        private int[] OffsetsPaginationsArguments = new int[] { -1, 0, 1 }; //fast

        private void Awake()
        {
            Subsribe();
        }

        private void Subsribe()
        {
            mainPaginationController.OnPaginationDataUpdate += FuncPaginationData;
        }

        [Button]
        public void TestCall()
        {
            FuncPaginationData(mainPaginationController.GetPaginationData());
        }

        private void FuncPaginationData(PaginationData _paginData)
        {
            for (int i = default; i < currentControllers.Count; i++)
            {
                int incrementOffset = OffsetsPaginationsArguments[i];
                //if (incrementOffset == default)
                //    continue;

                int setPage = _paginData.GetCurrentPage() + incrementOffset;
                currentControllers[i].SetForciblyPageNumber(setPage);
            }
        }
    }

}
