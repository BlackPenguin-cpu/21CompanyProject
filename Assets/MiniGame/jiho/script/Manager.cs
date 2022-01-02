using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using DG.Tweening;

public class Manager : MonoBehaviour
{
    public GameObject timer;
    public GameObject cat;
    public GameObject die;
    public GameObject MainCamara;
    public float sec = 5f;
    public int[] click = { 10, 17, 25 };
    public int max;
    public int count = 0;
    public int level = 1;
    public float speeeeeeeeed;
    public float shake2 = 0.0000000005f;
    Vector3 end = new Vector3(-1f, 0f, 0f);

    void Start()
    {

    }

    void Update()
    {

        float x = Random.Range(-0.1f, 0.1f);
        float y = Random.Range(-0.1f, 0.1f);
        timer.GetComponent<Slider>().value = sec;
        if (sec <= 0)
        {
            speeeeeeeeed += Time.deltaTime * 3.21221f;
            cat.SetActive(false);
            die.SetActive(true);
            die.GetComponent<Transform>().position += end * speeeeeeeeed * Time.deltaTime;
            MainCamara.GetComponent<Transform>().position += new Vector3(0f, shake2, 0f);
            Invoke("shake3", 0.01f);
            shake2 -= Time.deltaTime * 0.02f;
            StartCoroutine(GameManager.Instance.ChangeScene(false, 5f));
        }
        if (level == 1)
        {
            max = click[0];
        }
        else if (level == 2)
        {
            max = click[1];
        }
        else if (level == 3)
        {
            max = click[2];
        }


        if (count >= max)
        {
            count = 0;
            transform.DOMoveX(-17,4);
            StartCoroutine(GameManager.Instance.ChangeScene(true, 4f));
        }

        if (Input.GetMouseButtonUp(0) && count < max)
        {
            Vector3 shake = new Vector3(x, y, -10f);
            count++;
            MainCamara.GetComponent<Transform>().position = shake;
            Invoke("shake", 0.1f);
        }

        if (count < max)
        {
            sec -= Time.deltaTime;
        }


    }

    void shake()
    {
        MainCamara.GetComponent<Transform>().position = new Vector3(0, 0, -10f);
    }

    void shake3()
    {
        MainCamara.GetComponent<Transform>().position = new Vector3(0, 0, -10f);
    }

}
