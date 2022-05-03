using System;
using UnityEngine;
using GenLibrary.ModelMonobehTemplate;
using NaughtyAttributes;

namespace GenLibrary
{

    [System.Serializable]
    public class DamageablePartModel : IDamageable, IGetter<IDamageable>
    {
        public PartBodyEnum currentPartBody;

        public event Action<ISourceDamage> OnTakenDamage;

        //injects
        protected IDamageable ownerIDamageable;

        public RelationsTeams currentRelations;

        public void call_Convert_List_To_Dictionary()
        {
            currentRelations.call_Convert_List_To_Dictionary();
        }
        public void call_Convert_Dictionary_To_List()
        {
            currentRelations.call_Convert_Dictionary_To_List();
        }

        //serfs
        [SerializeField]
        private Transform currentTransform_body;
        [SerializeField]
        private ModelGetMonobeh<CreatureModelBase, ICreatureable> currentGetter_CreatureModelBase;


        //public Getter_OverrideGeneric<CreatureMonobeh, IDamageable> currentGetter;

        public void InjectSet(IDamageable _ownerIDamageable)
        {
            ownerIDamageable = _ownerIDamageable;
        }

        public IDamageable GetOwnerDamageable()
        {
            return ownerIDamageable;
        }

        public bool IsInDamageableState()
        {
            return ownerIDamageable.IsInDamageableState();
        }

        public void TakeDamage(ISourceDamage _argDamageSource)
        {
            OnTakenDamage?.Invoke(_argDamageSource);

            DamageCoreOperations.BaseCheckAndCommunicateSourceDamageAndDamageable(_argDamageSource, ownerIDamageable);

            //ownerIDamageable.TakeDamage(_argDamageSource);

            //DamageCoreOperations.
        }

        public Vector3 GetCurrentVector() //Vector3 IVectorPositionable<Vector3>.GetCurrentVector()
        {
            return currentTransform_body.position;
        }

        public IDamageable GetSome()
        {
            return currentGetter_CreatureModelBase.GetSome();
        }

        public TeamDamageable GetTeamDamageable()
        {
            throw new NotImplementedException();
        }
    }
}