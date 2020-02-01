using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class RepairKit : MonoBehaviour
{
    [Header("Setting")]
    public int RepairHP = 10;

    public AudioClip Clip;

    void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.CompareTag(GameManager.Tag_Player))
        {
            SoundManager.Instance.PlaySFX(Clip);

            GameManager.Instance.Player.Repair(RepairHP);
            GameManager.Instance.RepairEvent.Invoke(RepairHP);
            ObjectPool.Instance.ReturnObject(gameObject);
        }
    }
}
