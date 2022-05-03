using UnityEngine;

namespace GenLibrary
{
    public interface IVectorPositionable<T>
    {
        public T GetCurrentVector();
    }
}