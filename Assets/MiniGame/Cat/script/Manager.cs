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
    public bool check;

    public SpriteRenderer renderer;
    public List<Sprite> catcat;

    void Start()
    {
        ClickLevel();
    }

    void Update()
    {
        if (sec <= 0)
        {
            GameOver();
        }
        if (count == max && !check)
        {
            GameClear();
        }

        if (Input.GetMouseButtonUp(0) && count < max && !check)
        {
            CameraShake();
        }

        if (count < max)
        {
            Timer();
        }
    }

    void ClickLevel()//난이도에 따라 클릭 최대수 조정
    {
        switch (level)
        {
            case 1:
                max = click[0];
                break;
            case 2:
                max = click[1];
                break;
            case 3:
                max = click[2];
                break;

        }
    }

    void Timer()//제한시간 UI 조정
    {
        sec -= Time.deltaTime;
        timer.GetComponent<Slider>().value = sec;

    }

    void GameOver()
    {

        speeeeeeeeed += Time.deltaTime * 3.21221f;
        cat.SetActive(false);
        die.SetActive(true);
        die.transform.position += Vector3.left * speeeeeeeeed * Time.deltaTime;
        MainCamara.transform.DOShakePosition(0.5f, 0.1f, 10, 360, false, true);
        if (!check)
        {
            check = true;
            StartCoroutine(GameManager.Instance.ChangeScene(false, 4f));
        }

    }

    void GameClear()
    {
        cat.transform.DOMoveX(-17, 4);
        renderer.sprite = catcat[0];
        check = true;
        StartCoroutine(GameManager.Instance.ChangeScene(true, 4f));
    }

    void CameraShake()//고양이 클릭시 카메라 흔들기
    {
        float x = Random.Range(-0.1f, 0.1f);
        float y = Random.Range(-0.1f, 0.1f);
        Vector3 shake = new Vector3(x, y, -10f);
        MainCamara.transform.DOShakePosition(0.2f, 0.2f, 10, 360);
        count++;
    }
}
