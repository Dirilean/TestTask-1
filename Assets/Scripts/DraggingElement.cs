using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;

public class DraggingElement : MonoBehaviour
{
    Vector3 mousePos;
    Camera curCam;
    Vector3 lastMousePos;
    private float deltaForDrag=0.1f;
    [ReadOnly]
    public bool isDrag=false;

    protected virtual void Awake()
    {
        curCam = Camera.main;
        deltaForDrag = Mathf.Pow(deltaForDrag, 2);
    }

    public virtual void OnMouseDrag()
    {
        mousePos = curCam.ScreenToWorldPoint(Input.mousePosition);
        mousePos.z = 0;
        if ((mousePos - lastMousePos).sqrMagnitude > deltaForDrag)
        {
            Dragging();
        }
    }

    protected virtual void Dragging()
    {
        transform.position = mousePos;
        isDrag = true;
    }

    protected virtual void OnMouseDown()
    {
        lastMousePos = curCam.ScreenToWorldPoint(Input.mousePosition);
        lastMousePos.z = 0;
    }

    public virtual void OnMouseUp()
    {
        isDrag = false;
    }

}
