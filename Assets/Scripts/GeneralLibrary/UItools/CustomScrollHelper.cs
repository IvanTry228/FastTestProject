using System;
using System.Linq;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.Events;
using NaughtyAttributes;

namespace GenLibrary
{

    public class CustomScrollHelper : MonoBehaviour
    {
        [SerializeField]
        private ExtendedScrollRect new_currentScrollRect;
        [SerializeField]
        private Scrollbar scrollBar_x;
        [SerializeField]
        private SmoothChangerFloatImplement currentSmoothChanger = new SmoothChangerFloatImplement(); //ISmoothChanger

        [SerializeField]
        private ClamperInstruct currentClamper = new ClamperInstruct();

        [SerializeField]
        private int discreteCountItems = 3;
        [SerializeField]
        private float middleValue = 0.5f;

        [SerializeField][ReadOnly]
        private int lastIndex = -1;
        [SerializeField][ReadOnly]
        private float lastInputed_x = -1f;

        public UnityEvent OnFuncBegin;
        public UnityEvent OnFuncUp;

        public event Action<NavigationDirection> OnNavigateChange;

        private void Start()
        {
            Init();
        }

        [Button]
        public void Init()
        {
            new_currentScrollRect.NewOnBeginDrag += (_) => FuncOnDragBegin();
            new_currentScrollRect.NewOnEndDrag += (_) => FuncOnDragUp();

            new_currentScrollRect.onValueChanged.AddListener(FuncOnValueChanged);
        }

        public ClamperInstruct GetClamperInstruct()
        {
            return currentClamper;
        }

        public float GetNearestSnapValue(float _query)
        {
            return GetNearestDiscreteDiapazone(_query, discreteCountItems, out lastIndex);
        }

        public float GetCurrentValue_bar_x()
        {
            return scrollBar_x.value;
        }

        public void SetValueTargetSmooth(float _value)
        {
            currentSmoothChanger.CallChangeSome(GetCurrentValue_bar_x(), _value);
        }

        public void SetForciblyValue(float _value) //0-1f
        {
            scrollBar_x.value = _value; // + 0.1f;
        }

        private void FuncOnValueChanged(Vector2 arg0)
        {
            scrollBar_x.value = currentClamper.GetClampedValue(scrollBar_x.value);
            //UnityEditor.EditorUtility.SetDirty(this);
        }

        private void FuncOnDragBegin()
        {
            OnFuncBegin?.Invoke();
            currentSmoothChanger.OnValueReachedTarget -= FuncOnValueReached;
            currentSmoothChanger.OnValueChanged += SetForciblyValue;
            currentSmoothChanger.CallCancelProcedure();
        }

        private void FuncOnDragUp()
        {
            OnFuncUp?.Invoke();
            SetSmoothAndReturnToMiddle();
        }

        public void SetSmoothAndReturnToMiddle()
        {
            SetValueTargetSmooth(GetNearestSnapValue(GetCurrentValue_bar_x()));
            currentSmoothChanger.OnValueReachedTarget += FuncOnValueReached;
        }

        private void FuncOnValueReached()
        {
            SetForciblyValue(middleValue);
            HandleCastNavigation();
            currentSmoothChanger.OnValueChanged -= SetForciblyValue;
        }

        private void HandleCastNavigation()
        {
            NavigationDirection lastNavigate = (NavigationDirection)lastIndex;
            if (lastNavigate == NavigationDirection.Left)
                OnNavigateChange?.Invoke(NavigationDirection.Left);
            if (lastNavigate == NavigationDirection.Down)
                OnNavigateChange?.Invoke(NavigationDirection.Right);
        }

        public static float GetNearestDiscreteDiapazone(float _query, int _count, out int _index)
        {
            int discreteCount = _count; //3

            float maxVal = 1f;

            int decrementDiapazone = 1;

            int countDiapazones = discreteCount - decrementDiapazone; //2

            float step = maxVal / countDiapazones; //0.5

            float[] arr_Diapazones = new float[discreteCount];

            for (int i = default; i < arr_Diapazones.Length; i++)
            {
                arr_Diapazones[i] = Mathf.Abs(_query - (i * step));
            }

            _index = Array.IndexOf(arr_Diapazones, arr_Diapazones.Min());

            return _index * step;
        }
    }
}