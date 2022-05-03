using System;

namespace GenLibrary
{
    public interface IUpdateCustom
    {
        public event Action OnFixedUpdate;
        public event Action OnUpdate;
        public event Action OnLateUpdate;
    }
}