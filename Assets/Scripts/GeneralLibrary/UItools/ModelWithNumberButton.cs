namespace GenLibrary
{
    public class ModelWithNumberButton : ModelItemButton<ViewItem>
    {
        private int currentNumber;

        public int GetCurrentIntNumber()
        {
            return currentNumber;
        }

        public void SetCurrentValue(int _value)
        {
            currentNumber = _value;
            current_Tview.SetText(_value.ToString());
        }
    }
}