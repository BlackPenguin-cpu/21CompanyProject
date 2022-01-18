using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;
using TMPro;
using DG.Tweening;

public class GameManager : Singleton<GameManager>
{
    public float Timer;
    public float nowTime;
    private int StageValue;
    public bool Stop;
    public int Score;
    public int Combo;
    public int Level;
    // ���� ���� �����

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
                Debug.Log(isLose);
            }
            Life = value;
        }
    }

    public int Stage;
    public Slider slider;
    public Image blackScreen;
    public TextMeshProUGUI StageText;
    public TextMeshProUGUI ScoreText;
    public Image SliderFillColor;
    private MinigameManager minigame;
    private void Start()
    {
    }

    // Start is called before the first frame update
    protected override void Awake()
    {
        base.Awake();
        Stop = true;
    }

    // Update is called once per frame
    void Update()
    {
        ChangeSliderColor(nowTime / Timer);
        if (nowTime < 0)
        {
            Stop = true;
            nowTime = 0;
            slider.gameObject.SetActive(false);
            if (SceneManager.GetActiveScene().name == "MountainFire")
            {
                StartCoroutine(ChangeScene(false, FindObjectOfType<FireManager>().Gameoverr()));
            }
            else if (SceneManager.GetActiveScene().name == "CatRun")
            {
                StartCoroutine(ChangeScene(true, 0.01f));
            }
            else if (SceneManager.GetActiveScene().name == "SeaTurtle")
            {
                StartCoroutine(ChangeScene(true, FindObjectOfType<SeaTurtleManager>().GameClear()));
            }
            else if (SceneManager.GetActiveScene().name == "Chocolate")
            {
                StartCoroutine(ChangeScene(false, 3));
                FindObjectOfType<ChocolateManager>().isGameOver = true;
            }
        }
        if (Input.GetKeyDown(KeyCode.F1))
        {
            Stop = false;
        }
        if (!Stop) nowTime -= Time.deltaTime;

        //TimerColor2();
    }
    public IEnumerator ChangeScene(bool isWin, float Delay)
    {
        slider.gameObject.SetActive(false);
        Stop = true;
        yield return new WaitForSecondsRealtime(Delay);
        StartCoroutine(_ChangeScene(isWin));
    }
    public IEnumerator ChangeScene(bool isWin, IEnumerator coroutine)
    {
        slider.gameObject.SetActive(false);
        Stop = true;
        yield return StartCoroutine(coroutine);
        StartCoroutine(_ChangeScene(isWin));
    }

    private IEnumerator _ChangeScene(bool isWin)
    {
        int Scorenow = Score;
        Time.timeScale = 0;
        if (isWin)
        {
            blackScreen.gameObject.SetActive(true);
            StageText.text = "GREAT!!! - Life: " + Life;
            Combo++;
            Score += 104 + (Random.Range(19, 22) * Combo);
            while (Scorenow != Score)
            {
                Scorenow++;
                ScoreText.text = "Combo: " + Combo + " Score: " + Scorenow.ToString();
                yield return new WaitForSecondsRealtime(0.005f);
            }
        }
        else
        {
            blackScreen.gameObject.SetActive(true);
            _Life--;
            StageText.text = ":(  - Life: " + Life;
            Combo = 0;
            ScoreText.text = "Combo: " + Combo + " Score: " + Score.ToString();
        }


        yield return new WaitForSecondsRealtime(1.5f);
        blackScreen.gameObject.SetActive(false);
        StageText.text = "";
        ScoreText.text = "";
        Time.timeScale = LevelTimeScale();

        nowTime = 0;
        if (isLose)
        {
            StartCoroutine(GameOver());
        }
        else
        {
            NextGame();
        }
    }
    void NextGame()
    {
        if (StageValue < 0)
        {
            StageValue = StageName.Count;
            Level++;
        }


        int randnum = Random.Range(0, StageValue);
        SceneManager.LoadScene(StageName[randnum]);
        string index = StageName[randnum];

        slider.gameObject.SetActive(true);
        StageName.RemoveAt(randnum);
        StageName.Add(index);
        StageValue--;
    }
    IEnumerator GameOver()
    {
        blackScreen.gameObject.SetActive(true);
        StageText.text = "GameOver...";
        yield return new WaitForSecondsRealtime(2);
        isLose = false;
        SceneManager.LoadScene("MainBoard");
    }
    private void OnLevelWasLoaded(int level)
    {
        if (level != 0)
        {
            minigame = FindObjectOfType<MinigameManager>();
            nowTime = Timer = minigame.TimerTime;
            Debug.Log(minigame.TimerTime);
            Stop = false;
        }
    } 
    public void GameStart()
    {
        StageValue = StageName.Count;
        Life = 3;
        Level = 1;
        NextGame();
    }

    float LevelTimeScale()
    {
        return 1.0f + (0.3f * Level);
    }

    void ChangeSliderColor(float value)
    {
        slider.value = value;
        SliderFillColor.color = new Color(value, 1 - value, 0);
    }
}
