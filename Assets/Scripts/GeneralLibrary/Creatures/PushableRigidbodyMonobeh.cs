using UnityEngine;

namespace GenLibrary
{
    [System.Serializable]
    public struct PusherSettingsStruct
    {
        public float powerPush; 
        public float powerTorque; 

        public bool isToPush;
        public bool isTorquePush;

        public bool isIgnoreMass;

        public bool isForciblyNormalize;

        public bool isClampForceDirection;
        public float maxClampMagnitudeDirection;

        public bool isClampForceRigidbodyVelocity;
        public float maxClampForceRigidbodyVelocity;

        public const float defaultMaxMagnitude = 100f;

        public PusherSettingsStruct(bool _fakeMarker) //override default
        {
            powerPush = 1f; 
            powerTorque = 0.1f; 
            isIgnoreMass = false;
            isToPush = true;
            isTorquePush = true;
            isForciblyNormalize = false;

            isClampForceDirection = true;
            maxClampMagnitudeDirection = defaultMaxMagnitude;

            isClampForceRigidbodyVelocity = true;
            maxClampForceRigidbodyVelocity = defaultMaxMagnitude;
        }
    }

    public class PushableRigidbodyMonobeh : MonoBehaviour, IPushable
    {
        [SerializeField]
        private Rigidbody currentRigidbody;
        [SerializeField]
        private PusherSettingsStruct currentSettings = new PusherSettingsStruct(true);
        [SerializeField]
        private Vector3 lastDirection = Vector3.zero;

        public Rigidbody GetRigidbody()
        {
            return currentRigidbody;
        }

        public void ToPushByWorldPos(Vector3 _positionWorld, float _coeffForce = 1f)
        {
            Vector3 directionWorld = GenLibraryOperations.GetDirectionWorld(currentRigidbody.transform.position, _positionWorld);
            ToPush(directionWorld, _coeffForce);
        }

        public void ToPush(Vector3 _directionNormalize, float _coeffForce = 1)
        {
            if (currentSettings.isForciblyNormalize)
                _directionNormalize = _directionNormalize.normalized;

            Vector3 directionWithForce = _directionNormalize * _coeffForce;

            if (currentSettings.isIgnoreMass)
                directionWithForce *= currentRigidbody.mass;

            if (currentSettings.isClampForceDirection)
                directionWithForce = Vector3.ClampMagnitude(directionWithForce, currentSettings.maxClampMagnitudeDirection);

            if (currentSettings.isToPush)
                currentRigidbody.AddForce(directionWithForce * currentSettings.powerPush, ForceMode.Force);
            if(currentSettings.isTorquePush)
                currentRigidbody.AddTorque(directionWithForce * currentSettings.powerTorque, ForceMode.Force);

            if (currentSettings.isClampForceRigidbodyVelocity)
                currentRigidbody.velocity = Vector3.ClampMagnitude(currentRigidbody.velocity, currentSettings.maxClampForceRigidbodyVelocity);
        }
    }
}