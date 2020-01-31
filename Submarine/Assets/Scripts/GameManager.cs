using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;

public enum GameState
{
    Ready,
    Play,
    GameOver,
}

public class GameManager : MonoBehaviour
{
    static GameManager _instance;
    public static GameManager Instance { get; private set; }

    #region Inspector
    public SubMarine Player;
    public GameObject UI_Result;
    #endregion

    public GameState state;
    public UnityAction<int> OneSecEvent;
    public int Time;

    WaitForSeconds oneSec = new WaitForSeconds(1f);

    void Awake()
    {
        Instance = this;
        OneSecEvent += HardMore;
        state = GameState.Ready;
    }

    public void GameStart()
    {
        state = GameState.Play;
        UI_Result.SetActive(false);
        Time = 0;
        StartCoroutine(Timer());

        Player.Init();
    }

    public void HardMore(int sec)
    {
        // todo : 시간 흐름에 따라 게임 난이도 상승
    }

    IEnumerator Timer()
    {
        yield return oneSec;
        Time++;
        OneSecEvent.Invoke(Time);
    }

    public void GameOver()
    {
        state = GameState.GameOver;
        UI_Result.SetActive(true);
        StopAllCoroutines();
    }
}
