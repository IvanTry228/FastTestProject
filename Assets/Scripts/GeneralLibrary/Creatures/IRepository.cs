using System;
using System.Collections.Generic;

namespace GenLibrary
{
    public interface IRepository<T>
    {
        public List<T> GetItems();
    }

    public interface IAddItem<T>
    {
        public void AddItem(T _item);
    }

    public interface IRemoveItem<T>
    {
        public void RemoveItem(T _item);
    }

    public interface IRepositoryGettersExpression<T>
    {
        public T GetItemByExpression(Func<T, bool> _expressionPredicate);
        public List<T> GetItemsByExpression(Func<T, bool> _expressionPredicate);
    }

    public interface IRepositoryGetters<T> : IRepositoryGettersExpression<T>
    {

    }

    public interface IRepositoryAll<T> : IRepository<T>, IRepositoryGetters<T>, IAddItem<T>, IRemoveItem<T>
    {

    }
}
