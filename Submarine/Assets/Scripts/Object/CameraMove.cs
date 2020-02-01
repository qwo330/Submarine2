using UnityEngine;

public class CameraMove : MonoBehaviour
{
    [HideInInspector]
    public SubMarine Player;
    public Vector3 Offset;

    void Start()
    {
        Player = GameManager.Instance.Player;
    }

    void LateUpdate()
    {
        transform.position = new Vector3(Player.transform.position.x, 0, 0) + Offset;
    }
}
