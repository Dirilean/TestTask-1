using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Experimental.Rendering.LWRP;

public class LightingManager : MonoBehaviour
{
    public static LightingManager instance;

    private Light2D sun;
    private float step = 0.01f;
    IEnumerator fading;

    public Gradient gradientSunToNight;

    public float sunlyIntensity;
    public float nightIntensity;

    private void Awake()
    {
        instance = this;
        sun = GetComponent<Light2D>();
    }

    public void Fade(bool toNight)
    {
        if (fading != null) StopCoroutine(fading);
        fading = FadeCorutine(toNight);
        StartCoroutine(fading);
    }
    private IEnumerator FadeCorutine(bool toNight)
    {
        if (toNight)
        {
            while (sun.intensity > nightIntensity)
            {
                sun.intensity -= step;
                sun.color = gradientSunToNight.Evaluate((sunlyIntensity-nightIntensity)*step);
                yield return null;
            }
            sun.intensity = nightIntensity;
        }
        else
        {
            while (sun.intensity < sunlyIntensity)
            {
                sun.intensity += step;
                sun.color = gradientSunToNight.Evaluate((sunlyIntensity - nightIntensity) * step);
                yield return null;
            }
            sun.intensity = sunlyIntensity;
        }
    }

}
