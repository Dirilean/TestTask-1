using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TimeOfDay : MonoBehaviour, IMouseEventListener
{
    public bool isNight;
    public void Enter()
    {
        LightingManager.instance.Fade(isNight);
    }

    public void Exit()
    {
    }
}
