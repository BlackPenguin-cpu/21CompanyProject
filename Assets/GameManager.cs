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
    private int StageValue;
    public bool Stop;
    public int Score;
    public int Combo;

    [SerializeField] bool isLose;
    [SerializeField] private List<string> StageName;
    [SerializeField] private int Life;
    public int _Life
    {
        get
        {
            return Life;
        }
        set
        {
            if (value > 3)
            {
                Life = 3;
            }
            if (value <= 0)
            {
                isLose = true;
            }
            Life = value;
        }
    }

    public int Stage;
    public Slider slider;
    public Image blackScreen;
    public TextMeshProUGUI StageText;
    public TextMeshProUGUI ScoreText;

    // Start is called before the first frame update
    void Start()
    {
    }

    // Update is called once per frame
    void Update()
    {
        slider.value = nowTime / Timer;
        if (nowTime > Timer)
        {
            nowTime = 0;
            slider.gameObject.SetActive(false);
            StartCoroutine(ChangeScene(true, 0f));
        }
        if (!Stop) nowTime += Time.deltaTime;
    }
    public IEnumerator ChangeScene(bool isWin, float DelayTime)
    {
        slider.gameObject.SetActive(false);
        int Scorenow = Score;
        Stop = true;
        yield return new WaitForSeconds(DelayTime);
        Time.timeScale = 0;
        if (isWin)
        {
            blackScreen.gameObject.SetActive(true);
            StageText.text = "GREAT!!!";
            Combo++;
            Score += 104 + (20 * Combo);
            while (Scorenow != Score)
            {
                Scorenow++;
                ScoreText.text = "Combo: " + Combo +" Score: " + Scorenow.ToString();
                yield return new WaitForSecondsRealtime(0.005f);
            }
        }
        else
        {
            blackScreen.gameObject.SetActive(true);
            StageText.text = ":(";
            Life--;
            Combo = 0;
            ScoreText.text = "Combo: " + Combo + " Score: " + Score.ToString();
        }


        yield return new WaitForSecondsRealtime(1.5f);
        blackScreen.gameObject.SetActive(false);
        StageText.text = "";
        ScoreText.text = "";
        slider.gameObject.SetActive(true);
        Time.timeScale = 1;

        nowTime = 0;
        if (isLose)
        {
            StartCoroutine(GameOver());
        }
        else
        {
            Stop = false;
            NextGame();
        }
    }
    void NextGame()
    {
        if (StageValue < 0)
        {
            StageValue = StageName.Count;
        }
        //전에 했던 게임은 안나오게 수정 필요   (스택형 랜덤 사용 요구)
        int randnum = Random.Range(0, StageValue);
        SceneManager.LoadScene(StageName[randnum]);
        string index = StageName[randnum];
        StageName.RemoveAt(randnum);
        StageName.Add(index);
        StageValue--;
    }
    IEnumerator GameOver()
    {
        blackScreen.gameObject.SetActive(true);
        StageText.text = "GameOver...";
        yield return new WaitForSeconds(2);

        SceneManager.LoadScene("MainBoard");
    }
    public void GameStart()
    {
        StageValue = StageName.Count;
        Life = 3;
        NextGame();
    }
}
