using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SubMarine : MonoBehaviour
{
    [Header("Setting")]
    public int MaxHP = 100;
    public int NoDamageTime = 1;
    public int Tickdamage = 5;
    public int TickSec = 5;

    public float X_Speed = 1f;
    public float Y_Speed = 1f;
    public Boundary HeightBoundary;

    [Space(10)]
    public int HP;

    [HideInInspector]
    public bool Hitable = true;

    void Start()
    {
        GameManager.Instance.OneSecEvent += GetTickDamage;
        //GameManager.Instance.RepairEvent += Repair;
    }

    public void Init()
    {
        HP = MaxHP;
        Hitable = true;
        transform.position = Vector3.zero;
    }

    void Update()
    {
        if (GameManager.Instance.State == GameState.Play)
            Move(Vector2.right);
    }

    public void Move(Vector2 Dir)
    {
        float currentY = transform.position.y;
        transform.Translate(Vector2.right * X_Speed);

        if (Dir == Vector2.up && currentY < HeightBoundary.Top)
        {
            transform.Translate(Dir * Y_Speed);
        }
        else if (Dir == Vector2.down && currentY > HeightBoundary.Bottom)
        {
            transform.Translate(Dir * Y_Speed);
        }
    }

    public void GetDamage(int power)
    {

        if (Hitable)
        {
            HP -= power;
            GameManager.Instance.HitEvent.Invoke(power);

            if (HP <= 0)
                GameManager.Instance.CheckGameover(HP);

            StartCoroutine(WaitHitable());
        }
    }

    void GetTickDamage(int sec)
    {
        if (sec % TickSec == 0)
        {
            HP -= Tickdamage;
            if (HP <= 0)
                GameManager.Instance.CheckGameover(HP);

        }
    }

    public void Repair(int hp)
    {
        HP = Mathf.Min(HP + hp, MaxHP);
    }

    IEnumerator WaitHitable()
    {
        Hitable = false;
        yield return new WaitForSeconds(NoDamageTime);
        Hitable = true;
    }

#if UNITY_EDITOR
    [Header("Only Editor")]
    [SerializeField]
    CircleCollider2D coll;
    Vector3 offset;
    float radius;

    void OnDrawGizmosSelected()
    {
        //if (offset == null)
            offset = coll.offset;

        //if (Mathf.Approximately(radius, 0))
            radius = coll.radius;

        Gizmos.color = Color.red;
        Gizmos.DrawWireSphere(transform.position + offset, radius);    
    }
#endif
}

[System.Serializable]
public class Boundary
{
    public float Top = 10f;
    public float Bottom = -10f;
}