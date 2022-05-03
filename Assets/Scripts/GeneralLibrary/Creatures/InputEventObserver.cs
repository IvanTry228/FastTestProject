using UnityEngine;
using System;

namespace GenLibrary
{
    [System.Serializable]
    public class InputEventObserver //: MonoBehaviour
    {
        [SerializeField]
        private KeyCode keyCode;
        public event Action OnButtonGetKeyDown;

        private IUpdateCustom updateCustom;

        public InputEventObserver(KeyCode _keyCode)
        {
            keyCode = _keyCode;
        }

        public void Inject(IUpdateCustom _updateCustom)
        {
            updateCustom = _updateCustom;
            updateCustom.OnUpdate += CustomUpdate;
        }

        public void CustomUpdate()
        {
            if (Input.GetKeyDown(keyCode))
            {
                OnButtonGetKeyDown?.Invoke();
                Debug.Log("InputEventObserver keyCode inputed");
            }
        }

    }
}