using UnityEngine;

namespace GenLibrary.Pagination
{
    public class SetModelWithNumberImplementation : MonoBehaviour
    {
        [SerializeField]
        private ActionModelSubsriber currentActionModelSubsriber;

        public virtual void SetForPaginationModel(ModelWithNumberButton _modelViewButton, int _currentNumber)
        {
            _modelViewButton.SetCurrentValue(_currentNumber);
            currentActionModelSubsriber.DelegateSubsribe(_modelViewButton);
        }
    }

    
}