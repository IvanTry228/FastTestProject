using GenLibrary.ModelMonobehTemplate;

namespace GenLibrary
{
    public class Getter_IDamageable_PartBody : Getter_OverrideGeneric<ModelGetMonobeh<DamageablePartModel, IDamageable>, IDamageable> //GetterGenericMonobeh<IDamageable> //MonoBehaviour, IGetter<IDamageable>//>
    {
        //public CreatureMonobeh test_fast_CreatureMonobeh;

        public override IDamageable GetSome()
        {
            return someOverrided.GetSome();
        }
    }

    
}