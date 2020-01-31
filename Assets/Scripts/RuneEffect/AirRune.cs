using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AirRune : MonoBehaviour, IMouseEventListener
{
    Rune[] AllRunes;
    bool wind;
    public float speed = 0.005f;
    public float min;
    public float max=3;
    float[] allRunesSpeed;
    public void Enter()
    {
        AllRunes= GameObject.FindObjectsOfType<Rune>();
        allRunesSpeed = new float[AllRunes.Length];

        for (int i = 0; i <allRunesSpeed.Length; i++)
        {
            allRunesSpeed[i] = Random.Range(min, max);
        }

        wind = true;

        for (int i = 0; i < AllRunes.Length; i++)
        {
            StartCoroutine(WindForOne(AllRunes[i].transform));
        }
    }

    IEnumerator WindForOne(Transform rune)
    {   
        float ySpeed = Random.Range(-speed, speed);
        int frames = Random.Range(10,30);
        while (wind)
        {
            if (frames == 0)
            {
                ySpeed = Random.Range(-speed, speed);
                frames = Random.Range(10, 30);
            }
            frames--;
            for (int i = 0; i < AllRunes.Length; i++)
            {
                rune.localPosition += new Vector3(speed, ySpeed) * allRunesSpeed[i];
            }
            yield return null;
        }
    }

    public void Exit()
    {
        wind = false;
    }
}
