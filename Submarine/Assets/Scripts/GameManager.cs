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
    public UnityAction<int> oneSecEvent;
    public int Time;

    WaitForSeconds oneSec = new WaitForSeconds(1f);

    void Awake()
    {
        oneSecEvent += HardMore;
        state = GameState.Ready;
    }

    public void GameStart()
    {
        state = GameState.Play;
        UI_Result.SetActive(false);
        Time = 0;
        StartCoroutine(Timer());
    }

    public void HardMore(int sec)
    {

    }

    IEnumerator Timer()
    {
        yield return oneSec;
        Time++;
        oneSecEvent.Invoke(Time);
    }

    public void CheckGameOver()
    {
        if (Player.HP < 0)
        {
            GameOver();
        }
    }

    void GameOver()
    {
        state = GameState.GameOver;
        UI_Result.SetActive(true);
        StopAllCoroutines();
    }
}
