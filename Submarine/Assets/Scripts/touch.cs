using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class touch : MonoBehaviour
{
    // Update is called once per frame
    void Update()
    {
        if(Application.platform == RuntimePlatform.Android)
        {
            Vector2 pos = Input.GetTouch(0).position;

            if(pos.x <= Screen.width/2)
            {
                // 플레이어 아래로
            }
            if (pos.x >= Screen.width/2)
            {
                // 플레이어 위로
            }
        }
    }
}
