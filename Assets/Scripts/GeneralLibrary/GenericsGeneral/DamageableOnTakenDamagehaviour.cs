namespace GenLibrary
{
    [System.Serializable]
    public class DamageableOnTakenDamagehaviour
    {
        IDamageable currentDamageable;

        public void Inject(IDamageable _currentDamageable)
        {
            if (currentDamageable != null)
                currentDamageable.OnTakenDamage -= BehaviourImplement;

            currentDamageable = _currentDamageable;
            Init();
        }

        private void Init()
        {
            currentDamageable.OnTakenDamage += BehaviourImplement;
        }

        public virtual void BehaviourImplement(ISourceDamage _currentSourceDamage)
        {

        }
    }
}