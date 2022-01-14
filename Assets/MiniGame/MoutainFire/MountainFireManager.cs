using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MountainFireManager : MinigameManager
{

    // Start is called before the first frame update
    void Start()
    {
        switch (GameManager.Instance.Level)
        {
            case 1:
                TimerTime = 10;
                break;
            case 2:
                TimerTime = 11;
                break;
            case 3:
                TimerTime = 12;
                break;
            default:
                TimerTime = 13;
                break;
        }
    }

    //여기 아래 안씀 다 고치기 힘들다 ㅠㅠ
    public override IEnumerator GameClear()
    {
        yield return new WaitForSeconds(1);
    }

    public override IEnumerator GameOver()
    {
        yield return new WaitForSeconds(1);
    }
}
