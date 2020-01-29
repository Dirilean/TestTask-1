using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Experimental.Rendering.LWRP;

public class Rune : DraggingElement
{
    ParticleSystem particle;
    Animator anim;
    private string animBool="Stay";

    public AudioClip clip;
    public GameObject breaking;
    SpriteRenderer curSprite;
    Light2D light;
    protected override void Awake()
    {
        base.Awake();
        particle = GetComponent<ParticleSystem>();
        anim = GetComponent<Animator>();
        curSprite = GetComponent<SpriteRenderer>();
        light = GetComponentInChildren<Light2D>();
    }

    private void OnEnable()
    {
        ResetState();
    }

    private void OnMouseEnter()
    {
        if (particle != null) particle.Play();
        if (anim != null) anim.SetBool("Stay", true);
        if (clip != null)
        {
            AudioManager.instance.FadeSound(true, clip);
        }
    }

    private void OnMouseExit()
    {
        if (particle != null) particle.Stop();
        if (anim != null) anim.SetBool("Stay", false);
        if (clip != null)
        {
            AudioManager.instance.FadeSound(false, clip);
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
        if (breaking.activeInHierarchy) return;
        OnMouseEnter();
    }

    /// <summary>
    /// fade sound in audiosource
    /// </summary>
    /// <param name="IsRise">true for up volume</param>
    /// <returns></returns>

    protected override void OnMouseDown()
    {
        if (Deleting.deleteMod)
        {
            Break();
        }
    }

    /// <summary>
    /// break rune (deleting whith anim)
    /// </summary>
    public void Break()
    {
        breaking.SetActive(true);
        if (Deleting.deleteMod) AudioManager.instance.PlaySoundOfBreak();
    }

    public void HideNormalRune()
    {
        curSprite.enabled = false;
        light.enabled = false;
        if (clip != null)
        {
            AudioManager.instance.FadeSound(false, clip);
        }
    }
    private void ResetState()
    {
        curSprite.enabled = true;
        light.enabled = true;
        breaking.SetActive(false);
    }
}
