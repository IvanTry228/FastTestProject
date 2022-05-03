using UnityEngine;

namespace GenLibrary
{
    [System.Serializable]
    public class DamageableBehaviour_Push : DamageableOnTakenDamagehaviour
    {
        [SerializeField]
        private PushableRigidbodyMonobeh currentPusher;
        public override void BehaviourImplement(ISourceDamage _currentSourceDamage)
        {
            base.BehaviourImplement(_currentSourceDamage);
            currentPusher.ToPushByWorldPos(_currentSourceDamage.GetStartDamagePosition(), _currentSourceDamage.GetDamageValue());
        }
    }
}