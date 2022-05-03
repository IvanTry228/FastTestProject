
using UnityEngine;

public abstract class SingletonBehaviour<T> : MonoBehaviour where T : MonoBehaviour
{
    public static T Instance { get; private set; }
    private void Awake()
    {
        if (Instance != null)
            Destroy(Instance);

        Instance = this as T;
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

}