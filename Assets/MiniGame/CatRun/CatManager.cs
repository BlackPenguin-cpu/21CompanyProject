using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CatManager : MinigameManager
{
    public float Cooldown;
    float nowCooltime;
    public GameObject IronFan;
    List<int> a;

    private void Awake()
    {
        switch (GameManager.Instance.Level)
        {
            default:
                TimerTime = 8;
                break;
        }
    }
    void Start()
    {

        nowCooltime = TimerTime;
    }

    // Update is called once per frame
    void Update()
    {

        if (nowCooltime > Cooldown)
        {
            nowCooltime = 0;
            Cooldown = Random.Range(3, 6);
            Instantiate(IronFan, new Vector2(18, -3.5f), Quaternion.identity);
        }
        nowCooltime += Time.deltaTime;
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
