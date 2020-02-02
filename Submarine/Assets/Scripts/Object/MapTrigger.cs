using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MapTrigger : MonoBehaviour
{
    void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.CompareTag(GameManager.Tag_Player))
        {
            GameManager.Instance.CreateMap();
        }
    }

    void OnTriggerExit2D(Collider2D collision)
    {
        if (collision.CompareTag(GameManager.Tag_Player))
        {
            CollisionAction();
        }
    }

    public void CollisionAction()
    {
        Invoke("WaitAndReturn", 3f);
    }

    void WaitAndReturn()
    {
        ObjectPool.Instance.ReturnObject(transform.parent.gameObject);
    }
}
