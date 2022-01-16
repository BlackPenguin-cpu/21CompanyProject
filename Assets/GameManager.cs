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
    // 쉬움 보통 어려움

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
    public Image image;
    Tween tween;

    private void Start()
    {
        //TimerColor();
        image.DOColor(Color.green, 1);
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
        slider.value = nowTime / Timer;
        if (nowTime > Timer)
        {
            nowTime = 0;
            slider.gameObject.SetActive(false);
            if (SceneManager.GetActiveScene().name == "MountainFire")
            {
                StartCoroutine(ChangeScene(false, FindObjectOfType<FireManager>().Gameoverr()));
            }
            else if(SceneManager.GetActiveScene().name == "CatRun")
            {
                StartCoroutine(ChangeScene(true, 0.01f));
            }
            else if(SceneManager.GetActiveScene().name == "SeaTurtle")
            {
                StartCoroutine(ChangeScene(true, FindObjectOfType<SeaTurtleManager>().GameClear()));
            }
        }
        if (Input.GetKeyDown(KeyCode.F1))
        {
            Stop = false;
        }
        if (!Stop) nowTime += Time.deltaTime;

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
        tween.Kill();
        image.color = new Color(0, 1, 0); 
        int Scorenow = Score;
        Time.timeScale = 0;
        if (isWin)
        {
            blackScreen.gameObject.SetActive(true);
            StageText.text = "GREAT!!! - Life: " + Life;
            Combo++;
            Score += 104 + (Random.Range(19,22) * Combo);
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
            StageText.text = ":(  - Life: " + Life ;
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
            Stop = false;
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
        Stop = false;

        //전에 했던 게임은 안나오게 수정 필요   (스택형 랜덤 사용 요구)
        int randnum = Random.Range(0, StageValue);
        SceneManager.LoadScene(StageName[randnum]);
        string index = StageName[randnum];
        if (index != "Cat" && index != "pigeon")
        {
            Debug.Log(index);
            slider.gameObject.SetActive(true);

        }
        else
        {
            slider.gameObject.SetActive(false);
        }
        StageName.RemoveAt(randnum);
        StageName.Add(index);
        StageValue--;

        tween = image.DOColor(Color.red, 7);
    }
    IEnumerator GameOver()
    {
        blackScreen.gameObject.SetActive(true);
        StageText.text = "GameOver...";
        yield return new WaitForSecondsRealtime(2);
        isLose = false;
        SceneManager.LoadScene("MainBoard");
    }
    public void GameStart()
    {
        Stop = false;
        StageValue = StageName.Count;
        Life = 3;
        Level = 0;
        NextGame();
    }

    float LevelTimeScale()
    {
        return 1.0f + (0.3f * Level);
    }


    /*
    void TimerColor()
    {
        slider.image.color = new Color(0, 1, 0, 1);
    }

    void TimerColor2()
    {
        slider.image.color = new Color(0.0000001f * Time.deltaTime, 0, 0, 1);
    }*/
}
