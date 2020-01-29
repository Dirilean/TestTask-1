using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EffectsForRune : DraggingElement
{
    ParticleSystem particle;
    Animator anim;
    private string animBool="Stay";
    AudioSource auSourse;
    private float MaxVolume=0.5f;
    float riseSpeed = 10f;
    IEnumerator fading;

    protected override void Awake()
    {
        base.Awake();
        particle = GetComponent<ParticleSystem>();
        anim = GetComponent<Animator>();
        auSourse = GetComponent<AudioSource>();
    }
    private void OnMouseEnter()
    {
        if (particle != null) particle.Play();
        if (anim != null) anim.SetBool("Stay", true);
        if (auSourse != null)
        {
            if (fading != null) StopCoroutine(fading);

            fading = FadeSound(true);
            StartCoroutine(fading);
        }
    }
    private void OnMouseExit()
    {
        if (particle != null) particle.Stop();
        if (anim != null) anim.SetBool("Stay", false);
        if (auSourse != null)
        {
            if (fading != null) StopCoroutine(fading);

            fading = FadeSound(false);
            StartCoroutine(fading);

        }
    }

    protected override void Dragging()
    {
        base.Dragging();
        OnMouseExit();
    }

    public override void OnMouseUp()
    {
        base.OnMouseUp();
        OnMouseEnter();
    }

    /// <summary>
    /// fade sound in audiosource
    /// </summary>
    /// <param name="IsRise">true for up volume</param>
    /// <returns></returns>
    private IEnumerator FadeSound(bool IsRise)
    {
        
        if (IsRise)
        {
            auSourse.Play();
            while (auSourse.volume < MaxVolume)
            {
                auSourse.volume += MaxVolume /riseSpeed;
                yield return null;
            }
            auSourse.volume = MaxVolume;
        }
        else
        {
            while (auSourse.volume > 0)
            {
                auSourse.volume -= MaxVolume / riseSpeed;
                yield return null;
            }
            auSourse.volume = 0;
            auSourse.Stop();
        }
    }
}
