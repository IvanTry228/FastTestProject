namespace GenLibrary.UpdateCustom
{
    public class UpdaterCustomListener : EventSubsriberMonobeh //MonoBehaviour
    {
        public bool isFixedUpdate;
        public bool isUpdate = true;
        public bool isLateUpdate;

        protected IUpdateCustom currentUpdater;

        private void Inject(IUpdateCustom _currentUpdater)
        {
            currentUpdater = _currentUpdater;
        }
        protected override void Init()
        {
            base.Init();
            Inject(UpdaterCustom.Instance);
        }

        protected override void Subsribe()
        {
            if (isFixedUpdate)
                currentUpdater.OnFixedUpdate += FuncOnFixedUpdate;
            if (isUpdate)
                currentUpdater.OnUpdate += FuncOnUpdate;
            if (isLateUpdate)
                currentUpdater.OnLateUpdate += FuncOnLateUpdate;
        }

        protected override void Unsubsribe()
        {
            currentUpdater.OnFixedUpdate -= FuncOnFixedUpdate;
            currentUpdater.OnUpdate -= FuncOnUpdate;
            currentUpdater.OnLateUpdate -= FuncOnLateUpdate;
        }

        protected virtual void FuncOnFixedUpdate()
        {

        }

        protected virtual void FuncOnUpdate()
        {

        }

        protected virtual void FuncOnLateUpdate()
        {

        }
    }
}
