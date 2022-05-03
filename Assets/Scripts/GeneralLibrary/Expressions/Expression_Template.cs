namespace GenLibrary
{
    [System.Serializable]
    public class Expression_Template : IGetSomeExpressionInstruction
    {
        protected ExpressionCustom someExpressionCustom;

        public ExpressionCustom GetSomeExpressionCustom()
        {
            if (someExpressionCustom == null)
                Init_ExpressionCustom(); // someExpressionCustom = new ExpressionCustom(TemplatesExpressions.Get_expr_TransformsEqual(transform1, transform2));
            return someExpressionCustom;
        }

        protected virtual void Init_ExpressionCustom()
        {

        }
    }
}
