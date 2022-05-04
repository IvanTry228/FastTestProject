using UnityEngine;
using Zenject;
using GenLibrary;
using NaughtyAttributes;

public class ItemsController : MonoBehaviour
{
    [SerializeField]
    private IRepositoryAll<ItemTest> irepository;

    [SerializeField]
    private ItemTest currentItemTest;

    [Button]
    public void CallCopyAndAdd()
    {
        ItemTest bufferNew = new ItemTest();
        bufferNew.id = currentItemTest.id;
        bufferNew.naming = currentItemTest.naming;

        irepository.AddItem(bufferNew);
    }

    public int quaryId;
    [SerializeField][ReadOnly]
    private ItemTest queryItem;

    [Button]
    public void GetByExpressionId()
    {
        queryItem = irepository.GetItemByExpression(item => item.id == quaryId);
    }

    [Inject]
    private void Construct(IRepositoryAll<ItemTest> irepository)
    {
        this.irepository = irepository;
    }
}
