using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Mine : BaseObstacle
{
    void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.CompareTag(GameManager.Tag_Player))
        {
            CollisionAction();
        }
    }

    public override void CollisionAction()
    {
        GameManager.Instance.HitEvent.Invoke(Power);
        ObjectPool.Instance.ReturnObject(gameObject);
    }
}
