using System;
using UnityEngine;

namespace GenLibrary.UpdateCustom
{
    public class UpdaterCustom : MonoBehaviour, IUpdateCustom
    {
        public event Action OnFixedUpdate;
        public event Action OnUpdate;
        public event Action OnLateUpdate;

        public static UpdaterCustom Instance { get; private set; } // = this; // new UpdaterCustom();

        private void Awake()
        {
            Instance = this;
        }

        private void FixedUpdate()
        {
            OnFixedUpdate?.Invoke();
        }

        private void Update()
        {
            OnUpdate?.Invoke();
        }

        private void LateUpdate()
        {
            OnLateUpdate?.Invoke();
        }
    }
}