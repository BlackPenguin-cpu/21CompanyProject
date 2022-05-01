using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;
using TMPro;
using DG.Tweening;

public class UIManager : Singleton<UIManager>
{
    // 이거 그냥 데이터 저장소로 쓸꺼임 ㅇㅇ
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
    public string AnimalAllText;

}
