using NaughtyAttributes;
using UnityEngine;

namespace GenLibrary.ModelMonobehTemplate
{
    public class ModelGetMonobeh_PartBody : ModelGetMonobeh<DamageablePartModel, IDamageable>
    {
        [SerializeField]
        public DamageableBehaviour_Push currentDamageableBehaviour;
        [Button]
        public void call_Convert_List_To_Dictionary()
        {
            currentModel.call_Convert_List_To_Dictionary();
        }
        [Button]
        public void call__Convert_Dictionary_To_List()
        {
            currentModel.call_Convert_Dictionary_To_List();
        }
        
        public override void InitInject(IDamageable _IcurrentModel)
        {

            base.InitInject(_IcurrentModel);
            currentModel.InjectSet(currentModel.GetSome());
            currentDamageableBehaviour.Inject(_IcurrentModel);
        }
    }
}
