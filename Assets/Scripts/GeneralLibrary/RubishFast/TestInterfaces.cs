//using System.Numerics;
using UnityEngine;

public interface IVector3
{
    public Vector3 GetVector();
}

public interface ILocalVector //: IVector3
{
    public Vector3 GetVector();

}

public interface IWorldVector //: IVector3
{
    public Vector3 GetVector();

}

public interface ISpacesVector : ILocalVector, IWorldVector
{
}

public class Fast_ISpacesVector : ILocalVector, IWorldVector //ISpacesVector
{
    private Vector3 localVector;
    private Vector3 worldVector;

    Vector3 ILocalVector.GetVector()
    {
        return localVector;
    }

    Vector3 IWorldVector.GetVector()
    {
        return worldVector;
    }



    //public Vector3 GetVector()
    //{
    //    throw new System.NotImplementedException();
    //}

    ////4) and one more try, but its also doesnt works
    //Vector3 ILocalVector.IVector3.GetVector()
    //{
    //    return localVector;
    //}

    //Vector3 IWorldVector.IVector3.GetVector()
    //{
    //    return worldVector;
    //}


    ////1) working, but only 1 implements (implicitly)
    //public Vector3 GetVector()
    //{
    //    return localVector; return worldVector; //only 1
    //}

    ////2) working but only 1 implements (explicitly)
    //Vector3 IVector3.GetVector()
    //{
    //    return localVector; return worldVector; //only 1
    //}

    ////3) potential solution (explicitly and separate), but ofc it doesnt works
    //Vector3 ILocalVector.GetVector() 
    //{
    //    return localVector;
    //}

    //Vector3 IWorldVector.GetVector()
    //{
    //    return worldVector;
    //}

    ////4) and one more try, but its also doesnt works
    //Vector3 ILocalVector.IVector3.GetVector()
    //{
    //    return localVector;
    //}

    //Vector3 IWorldVector.IVector3.GetVector()
    //{
    //    return worldVector;
    //}
}
