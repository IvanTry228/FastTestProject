using UnityEngine;
using GenLibrary.UpdateCustom;

namespace GenLibrary.ObserverColliders
{
    public class Listener_TapColliderObserver : EventSubsriberMonobeh
    {
        public IMouseDragColliderObserver currentDragObserver;

        [SerializeField]
        private TapColliderObserver currentTapColliderObserver;

        protected override void Init()
        {
            Inject(currentTapColliderObserver);
            base.Init();
        }

        public void Inject(IMouseDragColliderObserver _currentDragObserver)
        {
            Unsubsribe();
            currentDragObserver = _currentDragObserver;
        }

        protected override void Subsribe()
        {
            base.Subsribe();
            currentDragObserver.OnMouseDragEvent += FuncOnMouseDragEvent;
            currentDragObserver.OnMouseDownEvent += FuncOnMouseDownEvent;
            currentDragObserver.OnMouseUpEvent += FuncOnMouseUpEvent;
        }

        protected override void Unsubsribe()
        {
            base.Unsubsribe();
            if (currentDragObserver == null)
                return;
            currentDragObserver.OnMouseDragEvent -= FuncOnMouseDragEvent;
            currentDragObserver.OnMouseDownEvent -= FuncOnMouseDownEvent;
            currentDragObserver.OnMouseUpEvent -= FuncOnMouseUpEvent;
        }

        protected virtual void FuncOnMouseDragEvent()
        {

        }

        protected virtual void FuncOnMouseDownEvent()
        {

        }

        protected virtual void FuncOnMouseUpEvent()
        {

        }
    }
}
