using UnityEngine;

namespace GenLibrary
{
    public class GetterGenericMonobeh<T> : MonoBehaviour, IGetter<T>
    {
        [SerializeField]
        private T someGet;

        public virtual T GetSome()
        {
            return someGet;
        }
    }
}