using UnityEngine;
using System.Collections.Generic;

namespace GenLibrary
{
    public enum NavigationDirection : byte
    {
        Left,
        Right,
        Down,
        Up
    }

    public interface INavigationable
    {
        public void Navigate(NavigationDirection _navigationDirect);
    }

    public class ModelsBaseController<Tmodel, Tview> : MonoBehaviour, IRepository<Tmodel> 
                                    where Tmodel : IModelWithView<Tview> where Tview : IViewItem
    {
        [SerializeField]
        protected List<Tmodel> currentModelsList = new List<Tmodel>();

        public List<Tmodel> GetItems()
        {
            return currentModelsList;
        }

    }
}
