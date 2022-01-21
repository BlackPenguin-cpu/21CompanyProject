using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class StartDash : MinigameManager
{

    public GameObject Light;
    public GameObject Hunter;
    void Start()
    {
        HunterSpawn();
        Light.SetActive(true);
        switch (GameManager.Instance.Level)
        {
            case 1:
                TimerTime = 12;
                break;
            case 2:
                TimerTime = 8;
                break;
            default:
                TimerTime = 5;
                break;
        }
    }

    void Update()
    {
    }

    void HunterSpawn()
    {
        float Random_x = Random.Range(-13, 13f);
        float Random_y = Random.Range(-7, 7f);
        Hunter.transform.position = new Vector3(Random_x, Random_y, 0f);
    }

    public override IEnumerator GameOver()
    {
        throw new System.NotImplementedException();
    }

    public override IEnumerator GameClear()
    {
        throw new System.NotImplementedException();
    }
}
