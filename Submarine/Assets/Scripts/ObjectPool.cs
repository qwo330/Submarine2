using System.Collections.Generic;
using UnityEngine;

public enum MapType
{
    BaseMap1 = 0,
    BaseMap2,
    BaseMap3,
    BaseMap4,
    BaseMap5,
    BaseMap6,
    BaseMap7,
    BaseMap8,
    BaseMap9,
    BaseMap10,
    BaseMap11,
    BaseMap12,
    BaseMap13,
    BaseMap14,
    BaseMap15,
    BaseMap16,



    Mine = 100,


    RepairKit = 200,
}


public class ObjectPool : MonoBehaviour
{
    const string path = "Prefab/";

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
        CreatePool(MapType.Mine.ToString());
        CreatePool(MapType.RepairKit.ToString());

        for (int i = 0; i < 8; i++)
        {
            string name = ((MapType)i).ToString();
            CreatePool(name, 8);
        }
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
            obj.name = name;
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
        if (obj.activeSelf)
            obj.SetActive(false);

        transform.parent = parent;
        string name = obj.name;
        var stack = Pools[name];
        stack.Push(obj);
    }
}