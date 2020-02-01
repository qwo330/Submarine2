using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Map : BaseObstacle
{
    MapType Type;

    void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.CompareTag("Player"))
        {
            GameManager.Instance.CreateMap();
        }
    }

    void OnTriggerExit2D(Collider2D collision)
    {
        if (collision.CompareTag("Player"))
        {
            Invoke("WaitAndReturn", 3f);
        }
    }

    void WaitAndReturn()
    {
        ObjectPool.Instance.ReturnObject(gameObject);
    }
}