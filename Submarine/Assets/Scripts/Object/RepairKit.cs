using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class RepairKit : MonoBehaviour
{
    [Header("Setting")]
    public int RepairHP = 10;

    void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.CompareTag(GameManager.Tag_Player))
        {
            GameManager.Instance.RepairEvent.Invoke(RepairHP);
            ObjectPool.Instance.ReturnObject(gameObject);
        }
    }
}
