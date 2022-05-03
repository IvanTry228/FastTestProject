using UnityEngine;
using System;

namespace GenLibrary
{
    public interface IDamageable : IVectorsSpaces<Vector3>//IVectorWorldPositionable<Vector3>, IVectorLocalPositionable<Vector3>
    {
        public IDamageable GetOwnerDamageable(); //if owner than return this(self), if owner other – return other ref
        public void TakeDamage(ISourceDamage _argDamageSource); //in

        public bool IsInDamageableState(); //true

        public event Action<ISourceDamage> OnTakenDamage;

        //teams
        public TeamDamageable GetTeamDamageable();
    }

    
}

