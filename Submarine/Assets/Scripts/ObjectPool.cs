using System.Collections.Generic;
using UnityEngine;

public class ObjectPool : MonoBehaviour
{
    const string path = "/";

    public static ObjectPool Instance { get; private set; }

    [SerializeField]
    Transform parent;

    Dictionary<string, Stack<GameObject>> Pools = new Dictionary<string, Stack<GameObject>>();

    void Awake()
    {
        Instance = this;
        //DontDestroyOnLoad(gameObject);
    }

    public void Init()
    {
        CreatePool("Mine", 100);
    }

    public void CreatePool(string name, int count = 32)
    {
        Stack<GameObject> stack;

        if (Pools.ContainsKey(name))
            stack = Pools[name];
        else
        {
            stack = new Stack<GameObject>();
            Pools.Add(name, stack);
        }

        GameObject prefab = Resources.Load<GameObject>(path + name);
        for (int i = 0; i < count; i++)
        {
            GameObject obj = Instantiate(prefab, parent);
            obj.SetActive(false);
            stack.Push(obj);
        }
    }

    public GameObject GetObject(string name)
    {
        if (Pools.ContainsKey(name) == false)
            CreatePool(name);

        var stack = Pools[name];

        if (stack.Count == 0)
            CreatePool(name);

        GameObject obj = stack.Pop();
        obj.SetActive(true);
        return obj;
    }

    public void ReturnObject(GameObject obj)
    {
        obj.SetActive(false);
        string name = obj.name;
        var stack = Pools[name];
        stack.Push(obj);
    }
}