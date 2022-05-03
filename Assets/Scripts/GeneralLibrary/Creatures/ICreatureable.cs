using GenLibrary.HpComponents;

namespace GenLibrary
{
    public interface ICreatureable : IAliveable, IDieable, IDamageable//, IInitiable
    {
        //?
        public void InitAndSet(IHpComponent<float> _ihpComponent);
        //?
        public IHpComponent<float> GetReadHpComponent();
    }

    //public interface IGetCreatureable
    //{
    //    public ICreatureable GetICreatureable();
    //}
}

