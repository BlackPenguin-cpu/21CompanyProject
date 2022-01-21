using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public abstract class MinigameManager : MonoBehaviour
{
    public float TimerTime;
    public string StartString;
    public string AnimalNews;
    public Sprite AnimalIcon;

    public abstract IEnumerator GameOver();
    public abstract IEnumerator GameClear();
}
