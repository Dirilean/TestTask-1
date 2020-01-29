using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class CreaterObject : MonoBehaviour
{
    public string name;
    Camera curCam;

    public void Start()
    {
        GetComponent<CustomButton>().OnMouseDown.AddListener(()=>CreateElement());
        curCam = Camera.main;
    }

    /// <summary>
    /// Создание элемента
    /// </summary>
    void CreateElement()
    {
        Vector3 pos =curCam.ScreenToWorldPoint(Input.mousePosition);
        pos.z = 0;
        DraggingElement element= Pool.instance.GetObject(name,pos).GetComponent<DraggingElement>();

        StartCoroutine(FirstDrag(element));
    }

    /// <summary>
    /// Перетаскивание элемента сразу после создания, не отжимая кнопки
    /// </summary>
    /// <param name="element">Перетаскиваемый элемент</param>
    /// <returns></returns>
    IEnumerator FirstDrag(DraggingElement element)
    {
        while (!Input.GetMouseButtonUp(0))
        {
            yield return null;
            element.OnMouseDrag();
        }
        element.OnMouseUp();
    }

}
