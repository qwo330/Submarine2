using UnityEngine;
using UnityEngine.UI;

public class UI_Play : MonoBehaviour
{
    public Text MinText, SecText;
    public Image Filled;

    SubMarine player;
    int maxHP;

    void Start()
    {
        GameManager.Instance.GameStartEvent += Init;
        GameManager.Instance.OneSecEvent += ShowTime;
        GameManager.Instance.OneSecEvent += UpdateLife;
        GameManager.Instance.HitEvent += UpdateLife;
        GameManager.Instance.RepairEvent += UpdateLife;

        player = GameManager.Instance.Player;
        maxHP = player.MaxHP;
    }

    void Init()
    {
        Filled.fillAmount = 1;
        MinText.text = "00'";
        SecText.text = "00''";
    }

    public void UpdateLife(int power)
    {
        int currentHP = player.HP;
        Filled.fillAmount = ((float)currentHP/maxHP);
    }

    public void ShowTime(int time)
    {
        MinSec ms = new MinSec();
        ms.CalcTime(time);

        MinText.text = string.Format("{0}'", ms.Min).PadLeft(3, '0');
        SecText.text = string.Format("{0}''", ms.Sec).PadLeft(4, '0');
    }
}
