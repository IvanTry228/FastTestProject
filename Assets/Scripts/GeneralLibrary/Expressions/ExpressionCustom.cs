using System;
using UnityEngine;

namespace GenLibrary
{
    public interface IGetSomeExpressionInstruction
    {
        public ExpressionCustom GetSomeExpressionCustom();
    }

    public class ExpressionCustom //: MonoBehaviour
    {
        private Func<bool> SomeActionCondition;
        
        public ExpressionCustom(Func<bool> _SomeActionCondition)
        {
            SomeActionCondition = _SomeActionCondition;
        }

        public bool CastCheckExpression()
        {
            bool isReturn = SomeActionCondition.Invoke();
            return isReturn;
        }
    }

    public class TemplatesExpressions
    {
        public static Func<bool> Get_expr_TransformsEqual(Transform _transf1, Transform _transf2)
        {
            Func<bool> exprReturn = new Func<bool>(() => (_transf1.position == _transf2.position));
            return exprReturn;
        }
    }
}
