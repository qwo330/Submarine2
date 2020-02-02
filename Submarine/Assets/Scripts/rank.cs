using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class rank : MonoBehaviour
{
    List<int> list = new List<int>();  // 점수를 넣을 리스트

    public int Score = 0; // 플레이어 점수 초기화

    public Text[] ScoreText;

    public Text Myscore;

    //public Text TextMyScore;

    public GameObject TextMyScore;

    private void Start()
    {
        InScore(0);
    }

    public void InScore(int MyScore)  // 점수 받는 함수
    {
        MinSec TimeScore = new MinSec();

        TimeScore.CalcTime(MyScore);

        list.Add(MyScore);
        for (int i = 1; i <= 10; i++)
        {
            LoadPlayerPrefs("Rank" + i);
        }

        list.Sort();
        list.Reverse();

        SaveRankPlayerPrefs();

        if (MyScore > 0)
        {
            TextMyScore.SetActive(true);
            string min = TimeScore.Min.ToString().PadLeft(2, '0');
            string sec = TimeScore.Sec.ToString().PadLeft(2, '0');
            Myscore.text = string.Format("{0}' {1}''", min, sec);
        }
        else
        {
            TextMyScore.SetActive(false);
            Myscore.text = "";
        }

        Rank();
    }
    public void Rank() // 리스트 정렬 후 역순, 10개 점수를 출력.
    {
        for(int i = 0; i < 10; i++)
        {
            int score = list[i];
            MinSec ms = new MinSec();
            ms.CalcTime(score);

            string min = ms.Min.ToString().PadLeft(2, '0');
            string sec = ms.Sec.ToString().PadLeft(2, '0');
            string time = string.Format("{0}' {1}''", min, sec);
            ScoreText[i].text = "Score : " + time;
        }
    }

    void LoadPlayerPrefs(string key)
    {
        if (PlayerPrefs.HasKey(key))
        {
            int score = PlayerPrefs.GetInt(key);
            list.Add(score);
        }
    }

    void SaveRankPlayerPrefs()
    {
        for (int i = 1; i <= 10; i++)
        {
            PlayerPrefs.SetInt("Rank" + i, list[i-1]);
        }
        
        PlayerPrefs.Save();
    }


}
