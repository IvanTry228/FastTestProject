using System;
using UnityEngine;
using NaughtyAttributes;
using UnityEngine.UI;
using TMPro;

namespace GenLibrary
{
    public class ModelItemButton<Tview> : MonoBehaviour, IModelWithView<Tview> where Tview : IViewItem
    {
        [SerializeField]
        protected Tview current_Tview;

        public Action DelegateWithCommunication;

        public virtual void FuncWithCommunication()
        {
            DelegateWithCommunication?.Invoke();
        }

        public virtual void SetTurnState(bool _newState)
        {
            current_Tview.SetTurnState(_newState);
        }

        public bool GetTurnState()
        {
            return current_Tview.GetTurnState();
        }

        public void CallRevertTurningState()
        {
            current_Tview.CallRevertTurningState();
        }

        public Tview GetTview()
        {
            return current_Tview;
        }
    }

    public interface IModelWithView<Tview> : ITurnable where Tview : IViewItem
    {

    }

    public interface IViewItem : ITurnable, ISetText, ISetSpriteImage
    {

    }

    public class ViewItem : MonoBehaviour, IViewItem
    {
        [SerializeField]
        private TextMeshProUGUI currentText;

        [SerializeField]
        private Button currentButtonView;

        [SerializeField]
        private Image currentButtonImage;

        [SerializeField][ReadOnly]
        private bool isInteractState = true;

        //ISetText
        public void SetText(string _text)
        {
            currentText.text = _text;
        }

        //ITurnable
        public void CallRevertTurningState()
        {
            SetTurnState(!GetTurnState());
        }

        public bool GetTurnState()
        {
            return isInteractState;
        }

        public virtual void SetTurnState(bool _newState)
        {
            isInteractState = _newState;
            currentButtonView.interactable = _newState;
        }

        public void SetSpriteImage(Sprite _newSprite)
        {
            currentButtonImage.sprite = _newSprite;
        }
    }
}