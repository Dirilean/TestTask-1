using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class WaterEffect : MonoBehaviour
{
    public static WaterEffect instance;
    private Material water;
    private SpriteRenderer spriteRenderer;
    private string property = "_Mask";
    private float step = 0.01f;
    IEnumerator fading;
    private void Awake()
    {
        spriteRenderer = GetComponent<SpriteRenderer>();
        water = spriteRenderer.material;
        spriteRenderer.enabled = false;
        instance = this;
    }


    public void Fade(bool IsRise)
    {
        if (fading != null) StopCoroutine(fading);
        fading = FadeCorutine(IsRise);
        StartCoroutine(fading);
    }
    private IEnumerator FadeCorutine(bool IsRise)
    {
        float cur= water.GetFloat(property);
        if (IsRise)
        {
            spriteRenderer.enabled = true;
            while (cur > 0)
            {
                cur = cur - step;
                water.SetFloat(property, cur);
                yield return null;
            }
            water.SetFloat(property, 0);
        }
        else
        {
            while (cur < 1)
            {
                cur = cur + step;
                water.SetFloat(property, cur);
                yield return null;
            }
            water.SetFloat(property, 1);
            spriteRenderer.enabled = false;
        }
    }
}
