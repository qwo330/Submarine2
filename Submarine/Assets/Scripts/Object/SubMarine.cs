using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SubMarine : MonoBehaviour
{
    [Header("Setting")]
    public int MaxHP = 100;
    public float X_Speed = 1f;
    public float Y_Speed = 1f;
    public Boundary HeightBoundary;

    [Space(10)]
    public int HP;

    [HideInInspector]
    public bool Hitable = true;

    public void Init()
    {
        HP = MaxHP;
        Hitable = true;
        transform.position = Vector3.zero;
    }

    void Update()
    {
        if (GameManager.Instance.state == GameState.Play)
            Move(Vector2.up);
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

#if UNITY_EDITOR
    [Header("Only Editor")]
    [SerializeField]
    CircleCollider2D collider;
    Vector3 offset;
    float radius;

    void OnDrawGizmos()
    {
        if (offset == null)
            offset = collider.offset;

        if (Mathf.Approximately(radius, 0))
            radius = collider.radius;

        Gizmos.color = Color.red;
        Gizmos.DrawWireSphere(offset, radius);    
    }
#endif
}

[System.Serializable]
public class Boundary
{
    public float Top = 10f;
    public float Bottom = -10f;
}