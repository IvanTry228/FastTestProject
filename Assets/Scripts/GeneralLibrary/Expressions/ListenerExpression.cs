using GenLibrary.UpdateCustom;
using UnityEngine;

namespace GenLibrary
{
    public class ListenerExpression : EventSubsriberMonobeh
    {
        protected IExpressionsController currentIExpressionsController;

        [SerializeField]
        private ExpressionsController serfExpressionsController;

        protected override void Init()
        {
            Inject(serfExpressionsController);
            base.Init();
        }

        public void Inject(IExpressionsController _currentIExpressionsController)
        {
            currentIExpressionsController = _currentIExpressionsController;
        }

        protected override void Subsribe()
        {
            base.Subsribe();
            if(currentIExpressionsController!=null)
                currentIExpressionsController.OnAllExpressionTrue += FuncOnTrueEvent;
        }

        protected override void Unsubsribe()
        {
            base.Unsubsribe();
            if (currentIExpressionsController != null)
                currentIExpressionsController.OnAllExpressionTrue -= FuncOnTrueEvent;
        }

        protected virtual void FuncOnTrueEvent()
        {

        }
    }
}
