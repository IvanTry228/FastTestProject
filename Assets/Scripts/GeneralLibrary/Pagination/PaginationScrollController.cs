using UnityEngine;

namespace GenLibrary.Pagination
{
    public class PaginationScrollController : MonoBehaviour
    {
        [SerializeField]
        private CustomScrollHelper currentCustomScroll;
        [SerializeField]
        private Pagination_ModelsController currentPaginController;

        private float extraOffsetLock = 0.05f;
        private float middle = 0.5f;

        private void Awake()
        {
            Subsribe();
        }

        private void Subsribe()
        {
            currentCustomScroll.OnNavigateChange += CallChangePagination;
            currentPaginController.OnPaginationDataUpdate += FuncWithUpdatePaginData;
        }

        public void CallChangePagination(NavigationDirection _navDirect)
        {
            currentPaginController.CallNavigate(_navDirect);
        }

        public void FuncWithUpdatePaginData(PaginationData _paginData)
        {
            var directions = _paginData.GetPossibleDirections();

            float min_left = middle - extraOffsetLock;
            float max_right = middle + extraOffsetLock;

            if (directions.Contains(NavigationDirection.Left))
                min_left = 0f - extraOffsetLock;

            if (directions.Contains(NavigationDirection.Right))
                max_right = 1f + extraOffsetLock;

            currentCustomScroll.GetClamperInstruct().SetClampMinMax(min_left, max_right);
        }
        //private void Set
    }

}
