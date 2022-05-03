using UnityEngine;

namespace GenLibrary.UpdateCustom
{
    public class EventSubsriberMonobeh : MonoBehaviour
    {
        private void Start()
        {
            Init();
        }

        protected virtual void Init()
        {
            Subsribe();
        }

        private void OnDestroy()
        {
            Unsubsribe();
        }

        protected virtual void Subsribe()
        {
            
        }

        protected virtual void Unsubsribe()
        {

        }
    }
}
