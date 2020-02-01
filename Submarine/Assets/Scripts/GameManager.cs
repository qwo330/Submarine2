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
    public int Time;

    WaitForSeconds oneSec = new WaitForSeconds(1f);
    float nextMapPosX;

    void Awake()
    {
        Instance = this;
        State = GameState.Ready;
        Level = 0;
        nextMapPosX = MapWidth * 0.5f;

        OneSecEvent += HardMore;
        HitEvent += CheckGameover;
    }  

    void Start()
    {
        ObjectPool.Instance.Init();
    }

    public void GameStart()
    {
        State = GameState.Play;
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
        while(State == GameState.Play)
        {
            yield return oneSec;
            Time++;
            OneSecEvent.Invoke(Time);
            //Createobstacle(Time);
        }
    }


    void CheckGameover(int hp)
    {
        if (hp <= 0)
        {
            GameOver();
        }
    }

    public void GameOver()
    {
        State = GameState.GameOver;
        UI_Result.SetActive(true);
        //StopAllCoroutines();
    }

    public void CreateMap()
    {
        int index = 0;

        int length = Enum.GetNames(typeof(MapType)).Length;
        //int index = UnityEngine.Random.Range(0, length + 1);
        string name = ((MapType)index).ToString();

        GameObject go = ObjectPool.Instance.GetObject(name);
        go.transform.position = new Vector3(nextMapPosX, 0, 0);
        nextMapPosX += MapWidth;

    }
}
