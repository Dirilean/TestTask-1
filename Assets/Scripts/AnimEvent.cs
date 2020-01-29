using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;

public class AnimEvent : MonoBehaviour
{
    public UnityEvent[] events;

    public void InvokeEvent(int i)
    {
        if (events[i] != null) events[i].Invoke();
    }
}
