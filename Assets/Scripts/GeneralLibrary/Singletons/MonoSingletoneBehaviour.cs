using UnityEngine;

public abstract class MonoSingletoneBehaviour<T> : MonoBehaviour where T : MonoBehaviour
{
    public static T Instance { get; private set; }
    private void Awake()
    {
        if (Instance == null)
        {
            Instance = this as T;
        }
        else
        {
            OnDestroyedObject();
        }

        Init();
    }
    protected virtual void Init()
    {

    }
    protected virtual void Start()
    {
        InitStart();
    }
    protected virtual void InitStart()
    {

    }
    protected virtual void OnDestroyedObject()
    {

    }
}