using System;
using UnityEngine;

namespace GenLibrary
{
    public class MarkerIDamageableTrigger : MonoBehaviour, IDamageable, IGetter<IDamageable>
    {
        public Transform currentPos;
        public bool isAlive = false;

        public event Action<ISourceDamage> OnTakenDamage;

        public Vector3 GetCurrentVector()
        {
            throw new NotImplementedException();
        }

        public IDamageable GetOwnerDamageable()
        {
            throw new NotImplementedException();
        }

        public Transform GetPointTransform()
        {
            return currentPos;
        }

        public Vector3 GetPointVector()
        {
            return currentPos.position;
        }

        public IDamageable GetSome()
        {
            return this;
        }

        public TeamDamageable GetTeamDamageable()
        {
            throw new NotImplementedException();
        }

        public bool IsInAlive()
        {
            return isAlive;
        }

        public bool IsInDamageableState()
        {
            throw new NotImplementedException();
        }

        public void TakeDamage(float _argPower, Vector3 _positionDamage)
        {
        }

        public void TakeDamage(ISourceDamage _argDamageSource)
        {
            throw new NotImplementedException();
        }
    }
}