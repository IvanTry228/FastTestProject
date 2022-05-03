namespace GenLibrary
{
    public class Getter_OverrideGeneric<Tcreature, Tidamageable> : GetterGenericMonobeh<Tidamageable> //where Tcreature : Tidamageable  //MonoBehaviour, IGetter<IDamageable>//>
    {
        public Tcreature someOverrided;

        //public override Tidamageable GetSome()
        //{
        //    //Tidamageable casted = (Tidamageable)someOverrided;
        //    return someOverrided;
        //}
    }
}