using System;

namespace GenLibrary
{
    public interface IResurrection
    {
        public void ToResurrection(); //protected use

        public event Action<IDieable> OnResurrection;
    }
}

