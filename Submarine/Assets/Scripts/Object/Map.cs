using UnityEngine;

public class Map : BaseObstacle
{
    void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.CompareTag(GameManager.Tag_Player))
        {
            var player = collision.GetComponent<SubMarine>();
            player.GetDamage(Power);
            //GameManager.Instance.CreateMap();
        }
    }

    public override void CollisionAction() { }
}