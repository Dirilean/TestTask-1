using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AudioManager : MonoBehaviour
{
    public static AudioManager instance;
    public static AudioSource background;
    public static AudioSource effects;

    public AudioSource _background;
    public AudioSource _effects;

    public AudioClip breaking;

    private float maxEffectVolume = 0.5f;
    float riseSpeed = 10f;
    IEnumerator fading;

    private void Awake()
    {
        if (instance != null) Destroy(this.gameObject);
        else instance = this;

        background = _background;
        effects = _effects;
    }
    public void FadeSound(bool IsRise, AudioClip clip)
    {
        if (fading != null) StopCoroutine(fading);

        fading = FadeSoundCorutine(IsRise,clip);
        StartCoroutine(fading);
    }
    private IEnumerator FadeSoundCorutine(bool IsRise, AudioClip clip)
    {
        if (IsRise)
        {
            if(clip!=null) AudioManager.effects.clip = clip;
            AudioManager.effects.Play();
            AudioManager.effects.loop = true;
            while (AudioManager.effects.volume < maxEffectVolume)
            {
                AudioManager.effects.volume += maxEffectVolume / riseSpeed;
                yield return null;
            }
            AudioManager.effects.volume = maxEffectVolume;
        }
        else
        {
            while (AudioManager.effects.volume > 0)
            {
                AudioManager.effects.volume -= maxEffectVolume / riseSpeed;
                yield return null;
            }
            AudioManager.effects.volume = 0;
            AudioManager.effects.Stop();
            AudioManager.effects.clip = null;
            AudioManager.effects.loop = false;
        }
    }

    public void PlaySoundOfBreak()
    {
        effects.volume = maxEffectVolume;
        effects.PlayOneShot(breaking);
    }

    public void BackGroundMute()
    {
        background.mute = !background.mute;
    }
    public void EffectsMute()
    {
        effects.mute = !effects.mute;
    }
}
