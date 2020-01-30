using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class WaterRune : MonoBehaviour, IMouseEventListener
{

    public void Enter()
    {
        WaterEffect.instance.Fade(true);
    }

    public void Exit()
    {
        WaterEffect.instance.Fade(false);
    }
}
