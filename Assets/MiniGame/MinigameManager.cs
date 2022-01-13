using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public abstract class MinigameManager : MonoBehaviour
{
    public float TimerTime;
    [SerializeField] protected string StartString;
    [SerializeField] protected string AnimalNews;

    public abstract IEnumerator GameOver();
    public abstract IEnumerator GameClear();
}
