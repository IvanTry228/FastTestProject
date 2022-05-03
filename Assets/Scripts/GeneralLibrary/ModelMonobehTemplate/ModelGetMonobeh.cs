using UnityEngine;

namespace GenLibrary.ModelMonobehTemplate
{

    public class ModelGetMonobeh<T, IT> : MonoBehaviour, IModelGet<T, IT> where T : IT
    {
        [SerializeField]
        protected T currentModel;
        [SerializeField] //useless
        protected IT IcurrentModel;

        private void Start()
        {
            InitStart();
        }

        protected virtual void InitStart()
        {
            InitInject(currentModel);
        }

        public virtual IT GetSome()
        {
            return IcurrentModel;
        }

        public virtual void InitInject(IT _IcurrentModel)
        {
            IcurrentModel = _IcurrentModel;
        }
    }
}
