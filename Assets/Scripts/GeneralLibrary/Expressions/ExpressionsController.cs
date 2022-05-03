using NaughtyAttributes;
using System;
using System.Collections.Generic;
using UnityEngine;

namespace GenLibrary
{
    public interface IExpressionsController
    {
        public event Action OnAllExpressionTrue;

        public void AddExpression(ExpressionCustom _someExpression);
        public void RemoveExpression(ExpressionCustom _someExpression);

        public void CallCastCheck();
    }

    public class ExpressionsController : MonoBehaviour, IExpressionsController
    {
        [SerializeField][ReadOnly]
        private List<ExpressionCustom> currentExprCustom = new List<ExpressionCustom>();

        public bool resultExpression;

        public event Action OnAllExpressionTrue;

        public void AddExpression(ExpressionCustom _someExpression)
        {
            currentExprCustom.Add(_someExpression);
        }

        public void RemoveExpression(ExpressionCustom _someExpression)
        {
            currentExprCustom.Remove(_someExpression);
        }

        private void Start()
        {
            Init();
        }

        private void Update()
        {
            if (resultExpression == false)
                CallCastCheck();
        }

        public void Init()
        {
            //ExpressionCustom currentExpressionCustom = new ExpressionCustom(TemplatesExpressions.Get_expr_TransformsEqual(transform1, transform2));
            //AddExpression(currentExpressionCustom);
        }

        [Button]
        public void CallCastCheck()
        {
            foreach (var item in currentExprCustom)
            {
                bool resultItem = item.CastCheckExpression();
                if (resultItem == false)
                    return;
            }

            CastExpressionTrue();
        }

        protected virtual void CastExpressionTrue()
        {
            resultExpression = true;
            OnAllExpressionTrue?.Invoke();
        }
    }
}
