using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;
using TMPro;
using DG.Tweening;

public class UIManager : Singleton<UIManager>
{
    // �̰� �׳� ������ ����ҷ� ������ ����
    public Canvas ResultCanvas;
    [SerializeField]
    public List<Image> Life;
    public Image BackGround;
    public TextMeshProUGUI Score;
    public TextMeshProUGUI Combo;
    public TextMeshProUGUI AnimalAll;
    public TextMeshProUGUI AnimalNews;
    public Image TimerGauge;
    public Image AnimalIcon;

    //void Start()
    //{

    //}

    //void Update()
    //{

    //}


    //public void ScreenPrint(bool isWin)
    //{
    //    if (isWin)
    //    {
    //        BackGround.color = new Color(0, 1, 0, 1);
    //    }
    //    else
    //    {
    //        BackGround.color = new Color(0, 1, 0, 1);

    //    }
    //}

    //public IEnumerator ClearTextEffect(int AddValue, float Delay)
    //{
    //    int ScoreValue = int.Parse(Score.text);
    //    int targetValue = ScoreValue + AddValue;
    //    float Value = AddValue / Delay;
    //    while (targetValue <= ScoreValue)
    //    {
    //        ScoreValue += (int)(Value * Time.deltaTime);
    //        Score.text = ScoreValue.ToString();
    //        yield return 0;
    //    }
    //}

}
