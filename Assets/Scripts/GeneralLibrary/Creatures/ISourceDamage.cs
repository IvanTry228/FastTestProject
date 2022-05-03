using UnityEngine;
using System.Collections.Generic;

namespace GenLibrary
{
    public interface ISourceDamage
    {
        public Vector3 GetStartDamagePosition();
        public Vector3 GetEndDamagePosition();

        public Vector3 GetDirectionDamage();

        public float GetDamageValue();

        public IEnumerable<IDamageable> GetAlreadyDamaged();

        public void AddDamagedToCollection(IDamageable _rootOwnerDamageable);
    }
}

