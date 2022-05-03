using UnityEngine;

namespace GenLibrary
{

    public class Getter_IDamageable_Creature : Getter_OverrideGeneric<CreatureMonobeh, IDamageable> //GetterGenericMonobeh<IDamageable> //MonoBehaviour, IGetter<IDamageable>//>
    {
        public override IDamageable GetSome()
        {
            return someOverrided.GetSome();

            //PartBodyMonobeh testPart = new PartBodyMonobeh();
            //TestMethod(testPart);
            //ISourceDamage currentVar = (ISourceDamage)testPart;
        }
    }

    public enum PartBodyEnum
    {
        Default,
        Body,
        Head
    }

    public class DamageablePartMonobeh : MonoBehaviour, IGetter<IDamageable>
    {
        public DamageablePartModel currentDamageableModel;

        public IDamageable GetSome()
        {
            return currentDamageableModel;
        }
    }

    
}