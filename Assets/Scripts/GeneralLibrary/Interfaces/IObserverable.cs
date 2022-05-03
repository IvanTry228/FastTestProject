using System;

namespace GenLibrary
{
    public interface IObserverable<T>
    {
        public event Action<T> OnSuccessTypeCommunicate_Enter;
        public event Action<T> OnSuccessTypeCommunicate_Exit;
    }
}