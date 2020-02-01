using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class StartBt : MonoBehaviour
{

    public GameObject Target;
    public void OnClickStart()
    {
        Target.SetActive(false);
        GameManager.Instance.GameStart();
    }
}