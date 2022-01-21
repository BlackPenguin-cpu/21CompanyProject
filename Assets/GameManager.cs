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
    public int ClearCount;

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
    [SerializeField] private float DelayedValue = 1;
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

        UIManager UIDirectory = FindObjectOfType<UIManager>();
        MinigameManager minigame = FindObjectOfType<MinigameManager>();
        UIDirectory.ResultCanvas.gameObject.SetActive(true);
        UIDirectory.AnimalNews.text = minigame.AnimalNews;
        UIDirectory.AnimalIcon.sprite = minigame.AnimalIcon;
        UIDirectory.AnimalAll.text = "구한 총 동물 수" + ClearCount;
        if (isWin)
        {
            TextMeshProUGUI ScoreUI = UIDirectory.Score;
            blackScreen.gameObject.SetActive(true);
            blackScreen.color = new Color(0, 1, 0, 1);
            //StageText.text = "GREAT!!! - Life: " + Life;
            ClearCount++;
            Combo++;
            UIDirectory.Combo.text = Combo.ToString();
            Score += 104 + (Random.Range(19, 22) * Combo);
            float target = DelayedValue - (1 / (Score - Scorenow));
            while (Scorenow != Score)
            {
                Scorenow++;
                UIDirectory.Score.text = Scorenow.ToString();
                yield return new WaitForSecondsRealtime(target);
            }
        }
        else
        {
            UIDirectory.BackGround.gameObject.SetActive(true);
            UIDirectory.BackGround.color = new Color(0, 0, 0, 1);
            _Life--;
            StageText.text = ":(  - Life: " + Life;
            Combo = 0;
            UIDirectory.Combo.text = Combo.ToString();
            UIDirectory.Score.text = Scorenow.ToString();
        }


        yield return new WaitForSecondsRealtime(1.5f);
        UIDirectory.ResultCanvas.gameObject.SetActive(false);
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
        blackScreen.gameObject.SetActive(false);
        StageText.text = "";
        SceneManager.LoadScene("MainBoard");
    }
    public void GameStart()
    {
        StageValue = StageName.Count;
        Score = 0;
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
        SliderFillColor.color = new Color(1 - value, value, 0);
    }
    private void OnLevelWasLoaded(int level)
    {
        if (level != 1)
        {
            minigame = FindObjectOfType<MinigameManager>();
            nowTime = Timer = minigame.TimerTime;
            Debug.Log(minigame.TimerTime);
            Stop = false;
        }
    }
}
