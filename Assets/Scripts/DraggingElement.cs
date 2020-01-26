using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DraggingElement : MonoBehaviour
{
    Vector3 mousePos;
    Camera curCam;

    private void Awake()
    {
        curCam = Camera.main;
    }
    
    public void OnMouseDrag()
    {
        mousePos = curCam.ScreenToWorldPoint(Input.mousePosition);
        mousePos.z = 0;
        transform.position = mousePos;
    }

}
