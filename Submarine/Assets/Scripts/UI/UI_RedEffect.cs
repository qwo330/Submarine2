using UnityEngine;

public class UI_RedEffect : MonoBehaviour
{
    public const string key_Warning = "Warning";
    public const string key_Hit = "Hit";

    [Header("Setting")]
    int WarningHP = 10;

    [Space(10)]
    [SerializeField]
    Animator animator;

    void Start()
    {
        GameManager.Instance.HitEvent += HitEffect;
    }

    public void HitEffect(int hp)
    {
        animator.SetTrigger(key_Hit);

        if (hp <= WarningHP)
            WarningEffect();
    }

    public void WarningEffect()
    {
        animator.SetBool(key_Warning, true);
    }

    public void WarningEffectOff()
    {
        animator.SetBool(key_Warning, false);
    }
}
