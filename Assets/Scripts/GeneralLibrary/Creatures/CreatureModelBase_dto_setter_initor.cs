using UnityEngine;
using GenLibrary.HpComponents;
using System.Collections.Generic;
using System;

namespace GenLibrary
{
    [System.Serializable]
    public class CreatureModelBase_dto_setter_initor
    {
        [SerializeField]
        private HpComponent dto_HpComponent = new HpComponent();

        public void CallInitCreatureModelBase(CreatureModelBase _creatureModelBase)
        {
            dto_HpComponent.Init();
            _creatureModelBase.InitAndSet(dto_HpComponent);
        }
    }

    public enum OptionsInit
    {
        FromEditorSerfieldDto,
        FromOther
    }

    public class SetupOptions
    {
        public static Dictionary<OptionsInit, Action> OptionsInitVariants = new Dictionary<OptionsInit, Action>(){ 
            [OptionsInit.FromEditorSerfieldDto] = SomeTestFunc,
            [OptionsInit.FromOther] = SomeTestFunc
        };

        public static void SomeTestFunc()
        {
            OptionsInitVariants.Add(OptionsInit.FromEditorSerfieldDto, SomeTestFunc);

            OptionsInitVariants = new Dictionary<OptionsInit, Action>()
            {
                [OptionsInit.FromEditorSerfieldDto] = SomeTestFunc
            };
        }
    }

}

