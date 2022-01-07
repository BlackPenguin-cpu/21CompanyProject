using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public abstract class MinigameManager : MonoBehaviour
{

    public float TimerTime;


    protected abstract IEnumerator GameOver();
    protected abstract IEnumerator GameClear();
}
