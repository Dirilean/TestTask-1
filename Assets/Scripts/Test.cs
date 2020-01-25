using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Test : MonoBehaviour
{
    // Update is called once per frame
    void Update()
    {
        if (Input.GetKeyDown(KeyCode.Space))
        {
            Pool.instance.GetObject("air", new Vector3(Random.Range(-5, 5), Random.Range(-5, 5), Random.Range(-5,5)));
        }
    }
}
