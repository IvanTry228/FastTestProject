namespace GenLibrary
{
    public interface ITurnable
    {
        //public Action OnSetChange;

        public void SetTurnState(bool _newState);

        public bool GetTurnState();

        public void CallRevertTurningState();
    }
}