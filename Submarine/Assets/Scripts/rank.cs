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

    //플레이어 점수 넘겨주실거라 매개변수로 받아야함 그것또한 밖에 따로 함수.

    private void Start()
    {
        TestMethod();
    }

    void TestMethod()
    {
        PlayerPrefs.SetInt("Rank1", 425);
        PlayerPrefs.SetInt("Rank2", 625);
        PlayerPrefs.SetInt("Rank3", 465);
        PlayerPrefs.SetInt("Rank4", 825);
        PlayerPrefs.SetInt("Rank5", 576);
        PlayerPrefs.SetInt("Rank6", 911);
        PlayerPrefs.SetInt("Rank7", 464);
        PlayerPrefs.SetInt("Rank8", 123);
        PlayerPrefs.SetInt("Rank9", 415);
        PlayerPrefs.SetInt("Rank10", 414);

        InScore(0);
    }


    public void InScore(int MyScore)  // 점수 받는 함수
    {
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
            Myscore.text = MyScore.ToString();
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
            ScoreText[i].text = "Score : " + list[i];
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
