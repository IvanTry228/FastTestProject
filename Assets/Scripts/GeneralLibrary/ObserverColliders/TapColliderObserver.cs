using System;
using UnityEngine;

namespace GenLibrary.ObserverColliders
{
    public class TapColliderObserver : MonoBehaviour, IMouseDragColliderObserver
    {
        public event Action OnMouseDragEvent;
        public event Action OnMouseDownEvent;
        public event Action OnMouseUpEvent;

        private void OnMouseDrag()
        {
            OnMouseDragEvent?.Invoke();
        }

        private void OnMouseDown()
        {
            OnMouseDownEvent?.Invoke();
        }

        private void OnMouseUp()
        {
            OnMouseUpEvent?.Invoke();
        }
    }
}