using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CatManager : MonoBehaviour
{
    public float Cooldown;
    float nowCooltime = 5;
    public GameObject IronFan;
    // Start is called before the first frame update
    void Start()
    {

    }

    // Update is called once per frame
    void Update()
    {

        if (nowCooltime > Cooldown)
        {
            nowCooltime = 0;
            Cooldown = Random.Range(5, 10);
            Instantiate(IronFan, new Vector2(25, -3.5f), Quaternion.identity);
        }
        nowCooltime += Time.deltaTime;
    }
}
