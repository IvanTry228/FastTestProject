using UnityEngine;
using System.Collections.Generic;

namespace GenLibrary
{
    [System.Serializable]
    public class SourceDamageBase : ISourceDamage
    {
        //[SerializeField]
        private List<IDamageable> alreadyDamagedList2 = new List<IDamageable>(2);

        [SerializeField]
        private DamageComponent currentDamageComponent;

        public SourceDamageBase(float _damageValue)
        {
            currentDamageComponent.DamageValue = _damageValue;
        }

        public void AddDamagedToCollection(IDamageable _rootOwnerDamageable)
        {
            if(alreadyDamagedList2==null)
                alreadyDamagedList2 = new List<IDamageable>(2);
            alreadyDamagedList2.Add(_rootOwnerDamageable);
        }

        public IEnumerable<IDamageable> GetAlreadyDamaged()
        {
            return alreadyDamagedList2;
        }

        public float GetDamageValue()
        {
            return currentDamageComponent.DamageValue;
        }

        public Vector3 GetDirectionDamage()
        {
            return (GetEndDamagePosition() - GetStartDamagePosition()).normalized;
        }

        public Vector3 GetEndDamagePosition()
        {
            return currentDamageComponent.currentTransform.position;
            //return currentDamageComponent.EndPosition;
        }

        public Vector3 GetStartDamagePosition()
        {
            return currentDamageComponent.currentTransform.position;
            //return currentDamageComponent.StartPosition;
        }
    }
}