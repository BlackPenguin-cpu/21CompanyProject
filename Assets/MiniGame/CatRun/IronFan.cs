using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class IronFan : MonoBehaviour
{
    public float Speed;
    void Start()
    {
        Speed = Random.Range(5, 10);
    }

    // Update is called once per frame
    void Update()
    {
        gameObject.transform.position += new Vector3(-Speed * Time.deltaTime, 0, 0);
        if(gameObject.transform.position.x < -10)
        {
            Destroy(gameObject);
        }
    }
}
