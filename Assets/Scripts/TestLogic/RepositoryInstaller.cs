using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Zenject;
using GenLibrary;
using System;
using NaughtyAttributes;

public class RepositoryInstaller : MonoInstaller
{
    public override void InstallBindings()
    {
        base.InstallBindings();

    }
}

[Serializable]
public class ItemTest
{
    public int id;
    public int naming;
}

public class ItemsController : MonoBehaviour
{
    [SerializeField]
    private IRepositoryAll<ItemTest> irepository;

    [SerializeField]
    private ItemTest currentItemTest;

    //[Button]
    public void CallCopyAndAdd()
    {
        ItemTest bufferNew = new ItemTest();
        bufferNew.id = currentItemTest.id;
        bufferNew.naming = currentItemTest.naming;

        irepository.AddItem(bufferNew);
    }

    private void Construct(IRepositoryAll<ItemTest> _irepository)
    {
        irepository = _irepository;
    }

}

public abstract class RepositoryImplementing<T> : IRepositoryAll<T>
{
    public List<T> collectionHolders;

    public void AddItem(T _item)
    {
        
        collectionHolders.Add(_item);
    }

    public T GetItemByExpression(Func<T, bool> _expressionPredicate)
    {
        throw new NotImplementedException();
    }

    public List<T> GetItemsByExpression(Func<T, bool> _expressionPredicate)
    {
        throw new NotImplementedException();
    }

    public List<T> GetItems()
    {
        return collectionHolders;
    }

    public void RemoveItem(T _item)
    {
        collectionHolders.Remove(_item);
    }
}
