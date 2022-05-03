using System;

namespace GenLibrary
{
    public interface IDieablePublicInfo
    {
        public bool IsDead();

        public event Action<IDieable> OnDie;
    }
}