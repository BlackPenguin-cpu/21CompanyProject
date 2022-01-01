using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using DG.Tweening;

public class Car : MonoBehaviour
{
    public int spd;

    // Start is called before the first frame update
    void Start()
    {
        transform.DOMoveY(-7.5f, 7).SetLoops(-1, LoopType.Restart);
    }

    // Update is called once per frame
    void Update()
    {
        //https://m.blog.naver.com/PostView.naver?isHttpsRedirect=true&blogId=gold_metal&logNo=220499531497
    }
}
