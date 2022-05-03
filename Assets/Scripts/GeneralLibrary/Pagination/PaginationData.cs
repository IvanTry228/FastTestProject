using UnityEngine;
using System.Collections.Generic;
using NaughtyAttributes;

namespace GenLibrary.Pagination
{
    [System.Serializable]
    public class PaginationData : INavigationable
    {
        [SerializeField]
        private int current_PaginationPage = 1;

        [SerializeField][ReadOnly]
        private int min_Pages = 0;

        [SerializeField] [ReadOnly]
        private int paginationSize = 10;
        [SerializeField] [ReadOnly]
        private int maxValue = 22;
        [SerializeField] [ReadOnly]
        private int extraMinOffset = 1;

        [SerializeField]
        private bool isExtraLogicPossibleCheck = true;

        [SerializeField] [ReadOnly]
        private List<NavigationDirection> possibleDirections = new List<NavigationDirection>();

        [SerializeField]
        private List<NavigationDirection> allDirections = new List<NavigationDirection>()
                                            { NavigationDirection.Left, NavigationDirection.Right };

        public void SetMaxOpenLevel(int _maxLevel)
        {
            maxValue = _maxLevel + paginationSize;
        }

        public List<NavigationDirection> GetPossibleDirections()
        {
            return possibleDirections;
        }

        public void Init()
        {
            FillPossibleWays();
        }

        public int GetCurrentPage()
        {
            return current_PaginationPage;
        }

        public void SetForciblyPageNumber(int _pageNumber)
        {
            current_PaginationPage = _pageNumber;
            FillPossibleWays();
        }

        public void Navigate(NavigationDirection _navigationDirect)
        {
            if (isExtraLogicPossibleCheck)
            {
                if (NavigateIsPossible(_navigationDirect) == false)
                    return;
            }

            switch (_navigationDirect)
            {
                case NavigationDirection.Left:
                    NavigateWithArgument(-1);
                    break;
                case NavigationDirection.Right:
                    NavigateWithArgument(1);
                    break;
            }

            FillPossibleWays();
        }

        private void FillPossibleWays()
        {
            possibleDirections.Clear();

            foreach (var item in allDirections)
            {
                if (NavigateIsPossible(item))
                    possibleDirections.Add(item);
            }
        }

        public bool NavigateIsPossible(NavigationDirection _navigationDirect)
        {
            switch (_navigationDirect)
            {
                case NavigationDirection.Left:
                    return IsNavigatePossible(-1);
                    break;
                case NavigationDirection.Right:
                    return IsNavigatePossible(1);
                    break;
            }
            return false;
        }

        private bool IsNavigatePossible(int _argument) //NavigationDirection
        {
            int bufferCheckPage = current_PaginationPage + _argument;
            return IsCorrectQueryPage(bufferCheckPage);
        }

        private bool IsCorrectQueryPage(int _numberCheck)
        {
            int max_Pages = GetMaxPages();

            if (_numberCheck < min_Pages)
                return false;

            if (_numberCheck >= max_Pages)
                return false;

            return true;
        }

        private void NavigateWithArgument(int _navigation)
        {
            current_PaginationPage += _navigation;
        }

        public int GetPaginatSize()
        {
            return paginationSize;
        }

        public int GetMaxPages()
        {
            int maxPage = (maxValue / paginationSize) + extraMinOffset;
            return maxPage;
        }

        public void InitPagination(int _current)
        {
            current_PaginationPage = _current;
        }

        public int GetOffsetValue()
        {
            return current_PaginationPage * paginationSize;
        }
    }
}
