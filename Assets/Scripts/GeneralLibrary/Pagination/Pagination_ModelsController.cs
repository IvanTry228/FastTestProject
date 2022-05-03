using System;
using UnityEngine;
using NaughtyAttributes;

namespace GenLibrary.Pagination
{
    public class Pagination_ModelsController : ModelsBaseController<ModelWithNumberButton, ViewItem>
    {
        [SerializeField]
        private PaginationData currentPaginData;

        [SerializeField]
        private ModelWithNumberButton NavButton_Left;
        [SerializeField]
        private ModelWithNumberButton NavButton_Right;
        

        private int offsetSetValue = 1;

        public event Action<PaginationData> OnPaginationDataUpdate;

        private void Start()
        {
            UpdateStates();
        }

        public PaginationData GetPaginationData()
        {
            return currentPaginData;
        }

        public void SetForciblyPageNumber(int _numberPage)
        {
            currentPaginData.SetForciblyPageNumber(_numberPage);
            UpdatePagebyPagination(currentPaginData);
        }

        public void CallNavigate(NavigationDirection _argument)
        {
            currentPaginData.Navigate(_argument);
            UpdatePagebyPagination(currentPaginData);
        }

        [Button]
        public void UpdateStates()
        {
            UpdatePagebyPagination(currentPaginData);
        }

        private void UpdatePagebyPagination(PaginationData _paginData)
        {
            _paginData.Init();

            var listModels = GetItems();
            int offsetValue = _paginData.GetOffsetValue() + offsetSetValue;

            for (int i = default; i < _paginData.GetPaginatSize(); i++)
            {
                var bufferModel = listModels[i];
                int currentNumber = i + offsetValue;
                SetForPaginationModel(bufferModel, currentNumber);
            }

            FuncAfterSet(_paginData);
        }

        private void FuncAfterSet(PaginationData _paginData)
        {
            NavigateButtonWithArgument(_paginData, NavButton_Left, NavigationDirection.Left);
            NavigateButtonWithArgument(_paginData, NavButton_Right, NavigationDirection.Right);
            OnPaginationDataUpdate?.Invoke(_paginData);
        }

        private void NavigateButtonWithArgument(PaginationData _paginData, ModelWithNumberButton _modelButton, NavigationDirection _direct)
        {
            if (_modelButton == null)
                return;

            bool new_isPossible = _paginData.GetPossibleDirections().Contains(_direct);

            bool isPossibleDirect = new_isPossible;
            if (isPossibleDirect)
                _modelButton.DelegateWithCommunication = () => CallNavigate(_direct);

            _modelButton.SetTurnState(isPossibleDirect);
        }
        [SerializeField]
        private SetModelWithNumberImplementation currentSetModelWithNUmber;
        private void SetForPaginationModel(ModelWithNumberButton _modelViewButton, int _currentNumber)
        {
            currentSetModelWithNUmber.SetForPaginationModel(_modelViewButton, _currentNumber);
            //_modelViewButton.SetCurrentValue(_currentNumber);
            //currentActionModelSubsriber.DelegateSubsribe(_modelViewButton);
        }
    }

}