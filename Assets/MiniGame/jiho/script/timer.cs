using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class timer : MonoBehaviour
{
    public GameObject UI;
    public int level = 1;
    public float sec = 5;
    public GameObject redlight;
    public GameObject greenlight;
    public GameObject road;
    public GameObject deadline;
    public bool on = true;
    public bool clear = true;
    void Start()
    {
        LevelTime();
        UI.GetComponent<Slider>().maxValue = sec;
    }

    void Update()
    {
        UI.GetComponent<Slider>().value = sec;
        if (sec > 0 && clear)
        {
            sec -= Time.deltaTime;
        }
        if (sec < 0)
        {
            if (on)
            {
                deadline.SetActive(true);
                road.SetActive(false);
                redlight.SetActive(true);
                on = false;
                Invoke("greenlighton", 1f);
            }
        }
    }

    void LevelTime()
    {
        if (level == 1)
        {
            sec = 5;
        }
        else if (level == 2)
        {
            sec = 4;
        }
        else if (level == 3)
        {
            sec = 3;
        }
    }

    void greenlighton()//요기가 게임 오버
    {
        redlight.SetActive(false);
        greenlight.SetActive(true);
        StartCoroutine(GameManager.Instance.ChangeScene(false, 2f));
    }
}
