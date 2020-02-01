using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Mine : BaseObstacle
{
    public AudioClip Clip;

    void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.CompareTag(GameManager.Tag_Player))
        {
            CollisionAction();
        }
    }

    public override void CollisionAction()
    {
        SoundManager.Instance.PlaySFX(Clip);

        GameManager.Instance.Player.GetDamage(Power);
        ObjectPool.Instance.ReturnObject(gameObject);
    }
}
