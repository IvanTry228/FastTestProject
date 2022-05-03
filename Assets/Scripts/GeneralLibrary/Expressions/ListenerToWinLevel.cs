using UnityEngine;

namespace GenLibrary
{
    public class ListenerToWinLevel : ListenerExpression
    {
        [SerializeField]
        private Expression_TransformsPositions currentExpr_Transforms;

        protected override void Init()
        {
            base.Init();
            currentIExpressionsController.AddExpression(currentExpr_Transforms.GetSomeExpressionCustom());
        }

        protected override void FuncOnTrueEvent()
        {
            Debug.Log("WIN GAME");
        }
    }
}
