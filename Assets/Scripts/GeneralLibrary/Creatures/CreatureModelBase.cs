using System;
using UnityEngine;
using GenLibrary.HpComponents;

namespace GenLibrary
{
    [System.Serializable]
    public class CreatureModelBase : ICreatureable
    {
        //serf dto from inspector (//or from injection set)
        [SerializeField]
        private IHpComponent<float> currentHpComponent; // = new HpComponent();

        public event Action<IDieable> OnDie;
        public event Action<ISourceDamage> OnTakenDamage;

        //serf other
        [SerializeField]
        private Transform currentTransform;

        public void InitAndSet(IHpComponent<float> _ihpComponent)
        {
            currentHpComponent = _ihpComponent;
            //currentHpComponent.Init();
        }

        public Vector3 GetCurrentVector()
        {
            return currentTransform.position;
        }

        public IDamageable GetOwnerDamageable()
        {
            return this;
        }

        public bool IsDead()
        {
            return currentHpComponent.IsDead();
        }

        public bool IsInAlive()
        {
            return currentHpComponent.IsInAlive();
        }

        public bool IsInDamageableState()
        {
            return IsInAlive();
        }

        public void TakeDamage(ISourceDamage _argDamageSource)
        {
            //new
            //DamageCoreOperations.BaseCheckAndCommunicateSourceDamageAndDamageable(_argDamageSource, this);

            //old
            OnTakenDamage?.Invoke(_argDamageSource);

            bool isToDie;
            currentHpComponent.DecrementValue(_argDamageSource.GetDamageValue(), out isToDie);
            if(isToDie)
                ToDie();
        }

        public void ToDie()
        {
            OnDie?.Invoke(this);
        }

        public IHpComponent<float> GetReadHpComponent()
        {
            return currentHpComponent;
        }

        public TeamDamageable GetTeamDamageable()
        {
            throw new NotImplementedException();
        }

        //public void Init()
        //{
        //    InitAndSet();
        //}
    }
}

