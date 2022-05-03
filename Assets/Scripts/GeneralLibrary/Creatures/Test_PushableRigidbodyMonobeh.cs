using UnityEngine;
using NaughtyAttributes;
using GenLibrary.UpdateCustom;
using static GenLibrary.GenLibraryOperations;

namespace GenLibrary
{
    public class Test_PushableRigidbodyMonobeh : UpdaterCustomListener // MonoBehaviour
    {
        [SerializeField]
        private PushableRigidbodyMonobeh currentPusher;

        [SerializeField]
        private Vector3 lastDirection = Vector3.one;
        [SerializeField]
        private float overridePower = 1f;

        [SerializeField]
        private Transform targetOfPush;

        [SerializeField]
        private InputEventObserver currentInputEventObserver = new InputEventObserver(KeyCode.Z);

        protected override void Init()
        {
            base.Init();
            currentInputEventObserver.Inject(currentUpdater);
            currentInputEventObserver.OnButtonGetKeyDown += TestCallPush;
        }

        protected override void FuncOnUpdate()
        {
            base.FuncOnUpdate();
            TestCallPush(); 
        }

        protected override void FuncOnFixedUpdate()
        {
            base.FuncOnFixedUpdate();
            TestCallPush();
        }
        protected override void FuncOnLateUpdate()
        {
            base.FuncOnLateUpdate();
            TestCallPush();
        }

        [Button]
        public void TestCallPush()
        {
            lastDirection = GetDirectionWorld(targetOfPush, currentPusher.GetRigidbody().transform);
            currentPusher.ToPush(lastDirection, overridePower);
        }
    }
}