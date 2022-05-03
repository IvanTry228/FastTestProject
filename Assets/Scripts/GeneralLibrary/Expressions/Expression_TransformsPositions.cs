using UnityEngine;

namespace GenLibrary
{
    [System.Serializable]
    public class Expression_TransformsPositions : Expression_Template
    {
        [SerializeField]
        private Transform transform1;
        [SerializeField]
        private Transform transform2;

        protected override void Init_ExpressionCustom()
        {
            someExpressionCustom = new ExpressionCustom(TemplatesExpressions.Get_expr_TransformsEqual(transform1, transform2));
        }
    }
}
