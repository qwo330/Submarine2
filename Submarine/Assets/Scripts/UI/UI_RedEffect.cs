using UnityEngine;

public class UI_RedEffect : MonoBehaviour
{
    public const string key_Warning = "Warning";
    public const string key_Hit = "Hit";

    [Header("Setting")]
    public int WarningHP = 10;

    [Space(10)]
    [SerializeField]
    Animator animator;

    void Start()
    {
        GameManager.Instance.GameOverEvent += WarningOff;
        GameManager.Instance.HitEvent += HitEffect;
        GameManager.Instance.RepairEvent += Repair;
    }

    public void HitEffect(int power)
    {
        animator.SetTrigger(key_Hit);
        int hp = GameManager.Instance.Player.HP;

        if (hp <= WarningHP)
        {
            WarningEffect();
        }
    }

    public void Repair(int power)
    {
        int hp = GameManager.Instance.Player.HP;
        if (hp > WarningHP)
            WarningEffectOff();
    }

    public void WarningEffect()
    {
        //Debug.Log("Waring Efffecet");

        animator.SetBool(key_Warning, true);
    }

    public void WarningEffectOff()
    {
        //Debug.Log("Waring Efffecet  FINISH");

        animator.SetBool(key_Warning, false);
    }

    public void WarningOff()
    {
        animator.SetBool(key_Warning, false);
    }
}
