using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class timer : MonoBehaviour
{
    public GameObject UI;
    public float sec = 5;
    void Start()
    {

    }

    void Update()
    {
        UI.GetComponent<Slider>().value = sec;
        if (sec > 0)
        {
            sec -= Time.deltaTime;
        }
    }
}
