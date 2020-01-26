using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;
using UnityEngine.EventSystems;
using UnityEngine.UI;

public class CustomButton : Selectable, IPointerDownHandler, IPointerUpHandler
{
    public UnityEvent OnMouseDown;
    public UnityEvent OnMouseUp;

    public void OnPointerDown(PointerEventData pointerEventData)
    {
        base.OnPointerDown(pointerEventData);

        if (pointerEventData.button == PointerEventData.InputButton.Left)
        {
            if (OnMouseDown != null) OnMouseDown.Invoke();
        }
    }

    public override void OnPointerUp(PointerEventData pointerEventData)
    {
        base.OnPointerUp(pointerEventData);

        if (pointerEventData.button == PointerEventData.InputButton.Left)
        {
            if (OnMouseUp != null) OnMouseUp.Invoke();
        }
    }
}
