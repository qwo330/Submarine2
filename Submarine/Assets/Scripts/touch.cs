using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class touch : MonoBehaviour
{
    SubMarine player;

    private void Start()
    {
        player = GameManager.Instance.Player;
    }
    // Update is called once per frame
    void Update()
    {
#if UNITY_EDITOR
        if (Input.GetMouseButton(0) == false)
            return;

        Vector2 pos = Input.mousePosition;
#elif UNITY_ANDROID
        Vector2 pos = Input.GetTouch(0).position;
#endif
        if (pos.x <= Screen.width / 2)
        {
            // 플레이어 아래로
            player.Move(Vector2.down);
        }
        if (pos.x >= Screen.width / 2)
        {
            // 플레이어 위로
            player.Move(Vector2.up);
        }

    }
}
