using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;
using TMPro;
using DG.Tweening;

public class UIManager : Singleton<UIManager>
{
    public Image[] Life;
    public Image BackGround;
    public TextMeshProUGUI Score;
    public TextMeshProUGUI Combo;
    public TextMeshProUGUI AnimalAll;
    public TextMeshProUGUI AnumalNews;

    void Start()
    {

    }

    void Update()
    {

    }

    void ScreenPrint(bool isWin)
    {
        if (isWin)
        {
            BackGround.color = new Color(0, 1, 0, 1);
        }
        else
        {
            BackGround.color = new Color(0, 1, 0, 1);

        }
    }

    public IEnumerator ClearTextEffect(int ScoreValue, int AddValue, float Delay)
    {
        int targetValue = ScoreValue + AddValue;
        float Value = AddValue / Delay;
        while (targetValue.ToString() == Score.text)
        {
            ScoreValue = (int)(Value * Time.deltaTime);
        }
    }

}
