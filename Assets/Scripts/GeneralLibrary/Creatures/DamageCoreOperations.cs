using System.Linq;

namespace GenLibrary
{
    public static class DamageCoreOperations
    {
        public static bool IsAlreadyDamagedByThisSource(ISourceDamage _argDamageSource, IDamageable _argDamageable)
        {
            IDamageable iowner = _argDamageable.GetOwnerDamageable();
            if (_argDamageSource.GetAlreadyDamaged() == null)
                return false;
            bool IsAlreadyDamaged = _argDamageSource.GetAlreadyDamaged().Contains(iowner);
            return IsAlreadyDamaged;
        }

        public static void CommunicateSourceDamageAndDamageable(ISourceDamage _argDamageSource, IDamageable _argDamageable)
        {
            _argDamageable.TakeDamage(_argDamageSource);
            _argDamageSource.AddDamagedToCollection(_argDamageable.GetOwnerDamageable());
        }

        public static void BaseCheckAndCommunicateSourceDamageAndDamageable(ISourceDamage _argDamageSource, IDamageable _argDamageable)
        {
            bool isAlreadyDamaged = IsAlreadyDamagedByThisSource(_argDamageSource, _argDamageable);
            if (isAlreadyDamaged)
                return;

            CommunicateSourceDamageAndDamageable(_argDamageSource, _argDamageable);
        }
    }
}

