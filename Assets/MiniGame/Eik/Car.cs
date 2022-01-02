using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using DG.Tweening;

public class Car : MonoBehaviour
{
    public int spd = 8;
    GameObject GameObject;
    

    // Start is called before the first frame update
    void Start()
    {
       
       //transform.DOMoveY(-15, 13).SetLoops(-1, LoopType.Restart);
    }

    // Update is called once per frame
    void Update()
    {
        float a = transform.position.x;

        if(transform.position.y <= -14)
        {
            transform.position = new Vector2(a, 11);
            transform.position += (Vector3.down * spd * Time.deltaTime);
        }

        transform.position += (Vector3.down * spd * Time.deltaTime);
    }
}
