using GenLibrary.ModelMonobehTemplate;
using UnityEngine;
using UnityEngine.Events;

namespace GenLibrary
{

    public class CreatureMonobeh : ModelGetMonobeh<CreatureModelBase, ICreatureable> //MonoBehaviour, IModelGet<CreatureModelBase, ICreatureable> //IGetter<ICreatureable>, 
    {
        //[SerializeField]
        //private CreatureModelBase test_CreatureModelBase; //currentModel
        [SerializeField]
        private CreatureModelBase_dto_setter_initor test_CreatureDto;

        [SerializeField]
        private UnityEvent testing_UnityEvent;

        public override ICreatureable GetSome()
        {
            return currentModel;
        }

        [ContextMenu("ExecuteUnityEvent")]
        public void ExecuteUnityEvent()
        {
            Debug.Log("ExecuteUnityEvent before hp= = " + currentModel.GetReadHpComponent().GetHpValuesRead().current);
            testing_UnityEvent.Invoke();
            Debug.Log("ExecuteUnityEvent after hp= = " + currentModel.GetReadHpComponent().GetHpValuesRead().current);
        }

        //public ICreatureable GetICreatureable()
        //{
        //    return test_CreatureModelBase;
        //}

        

        // Start is called before the first frame update
        void Start()
        {
            //test_CreatureModelBase.InitAndSet(test_CreatureModelBase.GetDtoHpComponent());
            test_CreatureDto.CallInitCreatureModelBase(currentModel);
            testing_UnityEvent.AddListener(()=> currentModel.TakeDamage(new SourceDamageBase(20f)));
            currentModel.OnDie += TestOnDIeFunc;
        }

        private void TestOnDIeFunc(IDieable _iDieable)
        {
            Debug.Log("IDieable isDead = " + _iDieable.IsDead());
        }
    }
}
