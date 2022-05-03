using UnityEngine;

namespace GenLibrary
{
    public class EventSubsriberListener_Monobeh<T> : MonoBehaviour // where T : MonoBehaviour
    {
        [SerializeField]
        private TriggerObserverAbstact<T> currentTriggerOfListing;

        private IObserverable<T> currentIObserverable;

        private void Start()
        {
            Init();
        }

        private void OnDestroy()
        {
            Unsubsribe();
        }

        private void Init()
        {
            currentIObserverable = currentTriggerOfListing;
            Subsribe();
        }

        private void Subsribe()
        {
            currentIObserverable.OnSuccessTypeCommunicate_Enter += FuncOnCommunicate_Enter;
            currentIObserverable.OnSuccessTypeCommunicate_Exit += FuncOnCommunicate_Exit;
        }

        private void Unsubsribe()
        {
            currentIObserverable.OnSuccessTypeCommunicate_Enter -= FuncOnCommunicate_Enter;
            currentIObserverable.OnSuccessTypeCommunicate_Exit -= FuncOnCommunicate_Exit;
        }

        protected virtual void FuncOnCommunicate_Enter(T _argType)
        {
            Debug.Log("Enter EventTriggerListenerAbstract _argType.. " + _argType);
        }

        protected virtual void FuncOnCommunicate_Exit(T _argType)
        {
            Debug.Log("Exit EventTriggerListenerAbstract _argType.. " + _argType);
        }
    }
}