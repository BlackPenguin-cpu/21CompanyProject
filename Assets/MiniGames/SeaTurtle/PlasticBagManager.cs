using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlasticBagManager : ObjectPool<PlasticBag>
{
    public float objCountDelay;
    void Start()
    {
        switch (GameManager.Instance.Level)
        {
            case 1:
                objCountDelay = 5;
                break;
            case 2:
                objCountDelay = 3.5f;
                break;
            case 3:
                objCountDelay = 2;
                break;
        }
        InvokeRepeating(nameof(CreateObj), 1, objCountDelay);
    }

    void Update()
    {

    }
    void CreateObj()
    {
        //SoundManager.Instance.PlaySound("plastic");
        GetObj(new Vector3(Random.Range(-11.0f, 11.0f), -5, 0), Quaternion.identity, transform, true);
    }
}
