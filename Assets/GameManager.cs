using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;
using TMPro;

public class GameManager : Singleton<GameManager>
{
    public float Timer;
    public float nowTime;
    public int StageValue;
    public string[] StageName;
    public int Life;

    public Slider slider;
    public Image blackScreen;
    public TextMeshProUGUI text;

    // Start is called before the first frame update
    void Start()
    {
        Timer = 8;
    }

    // Update is called once per frame
    void Update()
    {
        slider.value = nowTime / Timer;
        if (nowTime > Timer)
        {
            nowTime = 0;
            slider.gameObject.SetActive(false);
            StartCoroutine(ChangeScene(true));
        }
        nowTime += Time.deltaTime;
    }
    IEnumerator ChangeScene(bool isWin)
    {
        Time.timeScale = 0;
        if (isWin)
        {
            blackScreen.gameObject.SetActive(true);
            text.text = "GREAT!!!";
        }
        else
        {
            blackScreen.gameObject.SetActive(true);
            text.text = ":(";
        }
        yield return new WaitForSecondsRealtime(1);
        blackScreen.gameObject.SetActive(false);
        text.text = "";
        slider.gameObject.SetActive(true);
        Time.timeScale = 1;
        NextGame();
    }

    void NextGame()
    {
        //전에 했던 게임은 안나오게 수정 필요   (스택형 랜덤 사용 요구)
        SceneManager.LoadScene(StageName[Random.Range(0, StageValue)]);
    }
}
