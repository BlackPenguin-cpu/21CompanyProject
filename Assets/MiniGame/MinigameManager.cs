using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public abstract class MinigameManager : MonoBehaviour
{

    public float TimerTime;

    public abstract IEnumerator GameOver();
    public abstract IEnumerator GameClear();
}
