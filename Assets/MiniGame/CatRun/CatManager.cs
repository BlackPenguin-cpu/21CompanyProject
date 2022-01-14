using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CatManager : MinigameManager
{
    public float Cooldown;
    float nowCooltime;
    public GameObject IronFan;
    // Start is called before the first frame update
    void Start()
    {
        switch (GameManager.Instance.Level)
        {
            case 1:
                
                break;
            case 2:
                break;
            case 3:
                break;
            default:
                break;
        }
        nowCooltime = 10;
    }

    // Update is called once per frame
    void Update()
    {

        if (nowCooltime > Cooldown)
        {
            nowCooltime = 0;
            Cooldown = Random.Range(3, 6);
            Instantiate(IronFan, new Vector2(25, -3.5f), Quaternion.identity);
        }
        nowCooltime += Time.deltaTime;
    }
}
