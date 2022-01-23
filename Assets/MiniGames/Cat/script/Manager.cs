using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using DG.Tweening;

public class Manager : MinigameManager
{
    public GameObject timer;
    public GameObject cat;
    public GameObject die;
    public GameObject MainCamara;
    public float sec = 5f;
    private int[] click = { 10, 17, 25 };
    public int max;
    public int count = 0;
    public float speeeeeeeeed;
    private float shake2 = 0.0000000005f;
    private bool check;

    public SpriteRenderer renderer;
    public List<Sprite> catcat;

    private void Awake()
    {
        switch (GameManager.Instance.Level)
        {
            case 1:
                TimerTime = 5;
                break;
            case 2:
                TimerTime = 4;
                break;
            default:
                TimerTime = 3;
                break;

        }
    }
    void Start()
    {
        SoundManager.Instance.PlaySound("Drive");

        sec = TimerTime;
        ClickLevel();
    }

    void Update()
    {
        if (sec <= 0)
        {
            StartCoroutine(GameOver());
        }
        if (count == max && !check)
        {
            StartCoroutine(GameClear());
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
        switch (GameManager.Instance.Level)
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
            default:
                max = click[2];
                break;

        }
    }

    void Timer()//제한시간 UI 조정
    {
        sec -= Time.deltaTime;
        timer.GetComponent<Slider>().value = sec;

    }

    //void GameOver()
    //{

    //    speeeeeeeeed += Time.deltaTime * 3.21221f;
    //    cat.SetActive(false);
    //    die.SetActive(true);
    //    die.transform.position += Vector3.left * speeeeeeeeed * Time.deltaTime;
    //    MainCamara.transform.DOShakePosition(0.5f, 0.1f, 10, 360, false, true);
    //    if (!check)
    //    {
    //        check = true;
    //        StartCoroutine(GameManager.Instance.ChangeScene(false, 4f));
    //    }

    //}

    void CameraShake()//고양이 클릭시 카메라 흔들기
    {
        float x = Random.Range(-0.1f, 0.1f);
        float y = Random.Range(-0.1f, 0.1f);
        Vector3 shake = new Vector3(x, y, -10f);
        MainCamara.transform.DOShakePosition(0.2f, 0.2f, 10, 360);
        count++;
    }

    public override IEnumerator GameOver()
    {
        SoundManager.Instance.PlaySound("Engine");

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
        yield return 0;
    }

    public override IEnumerator GameClear()
    {
        SoundManager.Instance.PlaySound("meow");

        cat.transform.DOMoveX(-17, 4);
        renderer.sprite = catcat[0];
        check = true;
        StartCoroutine(GameManager.Instance.ChangeScene(true, 4f));
        yield return 0;
    }
}
