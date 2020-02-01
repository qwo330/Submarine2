using UnityEngine;

public class ItemSpawner : MonoBehaviour
{
    public MapType type;
    GameObject getObject;

    void OnEnable()
    {
        LoadObject();
    }

    void OnDisable()
    {
        if (getObject != null)
            ObjectPool.Instance.ReturnObject(getObject);    
    }

    void LoadObject()
    {
        getObject = ObjectPool.Instance.GetObject(type.ToString());
        getObject.transform.position = transform.position;
    }
}
