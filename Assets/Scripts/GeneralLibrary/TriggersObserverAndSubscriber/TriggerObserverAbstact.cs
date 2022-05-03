using System;
using UnityEngine;
using UnityEngine.Events;
using System.Collections.Generic;

namespace GenLibrary
{
    public class TriggerObserverAbstact<T> : MonoBehaviour, IObserverable<T>
    {
        [SerializeField]
        private FilterCheckCommunication currentFilterCheck = new FilterCheckCommunication();

        [SerializeField]
        protected List<string> communicateTags = new List<string>();

        [SerializeField]
        protected List<string> communicateLayers = new List<string>();

        [SerializeField]
        private bool isLockToCommunicate = false;
        [SerializeField]
        private bool isLimitCommunicateTimes = false;

        [SerializeField]
        private int maxCountCommunicateTimes = 1;

        [SerializeField]
        //[ReadOnly]
        private int countSuccessCommunicateTimes = 0;

        public UnityEvent OnSuccessCommunicateGameObj_Enter;
        public UnityEvent OnSuccessCommunicateGameObj_Exit;

        public event Action<T> OnSuccessTypeCommunicate_Enter;
        public event Action<T> OnSuccessTypeCommunicate_Exit;

        [SerializeField]
        //[ReadOnly]
        protected List<GameObject> enteredObjects = new List<GameObject>();

        [SerializeField]
        //[ReadOnly]
        protected List<T> enteredAbstractTypes = new List<T>();

        //ITriggerObserver
        public void SetIsLockToCommunicate(bool _isLock = true)
        {
            isLockToCommunicate = _isLock;
        }

        private void OnTriggerEnter(Collider other)
        {
            HandlerColliderEnter(other);
        }

        private void OnTriggerExit(Collider other)
        {
            HandlerColliderExit(other);
        }

        private void HandlerColliderEnter(Collider _argCollider)
        {
            if (!IsMayToCommunicate())
                return;

            bool isToCommunicate = false;

            if (currentFilterCheck.isForciblyWithoutTrigger)
                isToCommunicate = true;
            else
            {
                if (currentFilterCheck.isTagFilter)
                    isToCommunicate = IsMayToCommunicateWithTag(_argCollider);

                if (currentFilterCheck.isLayerFilter)
                    isToCommunicate = IsMayToCommunicateWithLayer(_argCollider);

                if (currentFilterCheck.isComponentFilter)
                    isToCommunicate = IsMayToCommunicateWithComponent(_argCollider);
            }

            if (isToCommunicate)
                Enter_CommunicateWithGameObj(_argCollider.gameObject);
        }

        private void HandlerColliderExit(Collider _argCollider)
        {
            if (enteredObjects.Count == 0)
                return;

            GameObject objFromCollider = _argCollider.gameObject;
            if (enteredObjects.Contains(objFromCollider))
            {
                Exit_WithGameObj(objFromCollider);
            }

            if (enteredAbstractTypes.Count == 0)
                return;

            T bufferTgeneric;

            if (_argCollider.TryGetComponent<T>(out bufferTgeneric))
            {
                Exit_WithComponent(bufferTgeneric);
            }

            if (enteredAbstractTypes.Contains(bufferTgeneric))
            {
                enteredAbstractTypes.Remove(bufferTgeneric);
                Debug.Log("TriggerObserverAbstact enteredAbstractTypes.Remove(bufferTgeneric) = ");
            }
        }

        protected virtual void Enter_CommunicateWithGameObj(GameObject _argObjToCommunicate)
        {
            countSuccessCommunicateTimes++;

            OnSuccessCommunicateGameObj_Enter?.Invoke();

            enteredObjects.Add(_argObjToCommunicate);

            Debug.Log("Current InteractTriggerBase obj = " + gameObject.name + " success communicate with " + _argObjToCommunicate.name); //_argObjToCommunicate.name
        }

        protected virtual void Enter_CommunicateWithComponent(T _argTypeToCommunicate)
        {
            OnSuccessTypeCommunicate_Enter?.Invoke(_argTypeToCommunicate);

            enteredAbstractTypes.Add(_argTypeToCommunicate);

            Debug.Log("ToCommunicateWithComponent.. " + _argTypeToCommunicate); //_argObjToCommunicate.name
        }

        protected virtual void Exit_WithGameObj(GameObject _argGameObjectExit)
        {
            enteredObjects.Remove(_argGameObjectExit);
            OnSuccessCommunicateGameObj_Exit?.Invoke();
        }

        protected virtual void Exit_WithComponent(T _argExitAbstract)
        {
            OnSuccessTypeCommunicate_Exit?.Invoke(_argExitAbstract);
        }

        private bool IsMayToCommunicateWithTag(Collider _argCollider)
        {
            bool isToCommunicate = false;

            foreach (var item in communicateTags)
            {
                if (item == _argCollider.tag)
                {
                    isToCommunicate = true;
                    break;
                }
            }

            return isToCommunicate;
        }

        private bool IsMayToCommunicateWithLayer(Collider _argCollider)
        {
            bool isToCommunicate = false;

            foreach (var item in communicateLayers)
            {
                Debug.Log("IsMayToCommunicateWithLayer item = " + item + " _argCollider.gameObject.layer.ToString() =" + _argCollider.gameObject.layer.ToString());
                if (item == _argCollider.gameObject.layer.ToString())
                {
                    isToCommunicate = true;
                    break;
                }
            }

            return isToCommunicate;
        }

        private bool IsMayToCommunicateWithComponent(Collider _argCollider)
        {
            T bufferTgeneric;

            if (_argCollider.TryGetComponent<T>(out bufferTgeneric))
            {
                Enter_CommunicateWithComponent(bufferTgeneric);
                return true;
            }

            return false;
        }

        protected virtual bool IsMayToCommunicate()
        {
            if (isLimitCommunicateTimes)
                if (countSuccessCommunicateTimes >= maxCountCommunicateTimes)
                    return false;

            return !isLockToCommunicate;
        }
    }
}