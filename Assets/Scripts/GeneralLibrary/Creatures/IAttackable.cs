using System;

namespace GenLibrary
{
    public interface IAttackable
    {
        public void ToAttack(); //IDamageSource _argDamageSource

        public event Action<IDamageable> OnDamagedSomeDamageable;
    }
}

