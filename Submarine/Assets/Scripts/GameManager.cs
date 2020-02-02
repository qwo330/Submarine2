using System;
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
    public const string Tag_Player = "Player";
    public const string Tag_Obstacle = "Obstacle";
    public const string Tag_Repair = "Repair";

    static GameManager _instance;
    public static GameManager Instance { get; private set; }

    #region Inspector
    public SubMarine Player;
    public GameObject UI_Result;
    #endregion

    [Header("Setting")]
    public float MapWidth = 100f;

    [Space(10)]
    public GameState State;
    public int Level;
    public UnityAction<int> OneSecEvent;
    public UnityAction<int> HitEvent;
    public UnityAction<int> RepairEvent;
    public UnityAction GameOverEvent;
    public int Time;

    WaitForSeconds oneSec = new WaitForSeconds(1f);
    float nextMapPosX;

    void Awake()
    {
        Instance = this;
        State = GameState.Ready;

        OneSecEvent += HardMore;
        HitEvent += CheckGameover;
    }  

    void Start()
    {
        ObjectPool.Instance.Init();
    }

    public void GameStart()
    {
        UI_Result.SetActive(false);

        State = GameState.Play;
        Time = 0;
        Level = 0;
        nextMapPosX = 0f;

        StartCoroutine(Timer());

        Player.Init();
    }

    public void HardMore(int sec)
    {
        // todo : 시간 흐름에 따라 게임 난이도 상승
    }

    IEnumerator Timer()
    {
        while(State == GameState.Play)
        {
            yield return oneSec;
            Time++;
            OneSecEvent.Invoke(Time);
            CreateMap();
        }
    }

    public void CheckGameover(int power)
    {
        int hp = Player.HP;
        if (hp <= 0)
        {
            GameOver();
        }
    }

    public void GameOver()
    {
        State = GameState.GameOver;
        UI_Result.SetActive(true);
        rank rank = UI_Result.GetComponent<rank>();
        rank.InScore(Time);
        GameOverEvent.Invoke();
        //StopAllCoroutines();
    }

    public void CreateMap()
    {
        int index = UnityEngine.Random.Range(0, 7); // maptype 0 ~ 15 사용
        string name = ((MapType)index).ToString();

        //Debug.Log("create  " + name);

        GameObject go = ObjectPool.Instance.GetObject(name);
        go.transform.position = new Vector3(nextMapPosX, 0, 0);
        nextMapPosX += MapWidth;

    }
}

public class MinSec
{
    public int Min;
    public int Sec;

    public void CalcTime(int sec)
    {
        Min = sec / 60;
        Sec = sec % 60;
    }
}