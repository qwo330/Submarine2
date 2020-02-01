using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SoundManager : MonoBehaviour
{
    public static SoundManager Instance {get; private set; }

    public AudioSource BGM_Player;
    public AudioSource SFX_Player;

    public AudioClip BGM, BGM_Effect;

    WaitForSeconds wait20 = new WaitForSeconds(20f);

    void Awake()
    {
        Instance = this;
        PlayBGM(BGM);
        StartCoroutine(PlayBGM_Effect());
    }

    public float PlayBGM(AudioClip clip)
    {
        BGM_Player.clip = clip;
        BGM_Player.Play();
        float playTime = clip.length;
        return playTime;
    }

    IEnumerator PlayBGM_Effect()
    {
        while (true)
        {
            yield return wait20;

            if (SFX_Player.isPlaying)
                SFX_Player.Stop();
            float playtime = PlaySFX(BGM_Effect);
        }
    }

    public float PlaySFX(AudioClip clip)
    {
        if (SFX_Player.isPlaying)
            SFX_Player.Stop();

        SFX_Player.clip = clip;
        SFX_Player.Play();
        float playtime = clip.length;

        return playtime;
    }
}
