using System;

namespace GenLibrary.ObserverColliders
{
    public interface IMouseDragColliderObserver
    {
        public event Action OnMouseDragEvent;
        public event Action OnMouseDownEvent;
        public event Action OnMouseUpEvent;
    }
}