using GenLibrary.GenValues;

namespace GenLibrary.HpComponents
{
    public interface IInitiable
    {
        public void Init();
    }

    public interface IHpComponent<T> : IAliveable, IDieable, IInitiable
    {
        public GeneralValuesMinMax<T> GetHpValuesRead();

        public void DecrementValue(T _argIncrementValue, out bool _isToDie);

        //?
        public void InitAndSet(GeneralValuesMinMax<T> _hpValues, bool _isInAlive = true);
    }
}

