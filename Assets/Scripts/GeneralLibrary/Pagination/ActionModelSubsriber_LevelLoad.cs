using GenLibrary;

public class ActionModelSubsriber_LevelLoad : ActionModelSubsriber
{
    public override void DelegateSubsribe(ModelWithNumberButton _modeWithNUmber)
    {
        _modeWithNUmber.DelegateWithCommunication = () => _modeWithNUmber.GetCurrentIntNumber();
    }
}
//namespace GenLibrary
//{
    
//}
