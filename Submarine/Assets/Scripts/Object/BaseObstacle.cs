using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public abstract class BaseObstacle : MonoBehaviour
{
    [Header("Setting")]
    public int Power = 5;

    void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.CompareTag(GameManager.Tag_Player))
        {
            CollisionAction();
        }
    }

    public abstract void CollisionAction();
}
