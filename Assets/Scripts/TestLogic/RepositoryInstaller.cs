using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Zenject;
using GenLibrary;
using System;
using System.Linq;

public class RepositoryInstaller : MonoInstaller
{
    [SerializeField]
    private ConcreteRepositroyItemsTest testConcreteRepository;

    public override void InstallBindings()
    {
        //base.InstallBindings();
        Container.Bind<IRepositoryAll<ItemTest>>().FromInstance(testConcreteRepository); //IRepositoryAll<ItemTest>
    }
}

[Serializable]
public class ItemTest
{
    public int id;
    public int naming;
}

public abstract class RepositoryImplementing<T> : MonoBehaviour, IRepositoryAll<T>
{
    public List<T> collectionHolders;

    public void AddItem(T _item)
    {
        
        collectionHolders.Add(_item);
    }

    public T GetItemByExpression(Func<T, bool> _expressionPredicate)
    {
        return collectionHolders.Where(_expressionPredicate).FirstOrDefault();
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
