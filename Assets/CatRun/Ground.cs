using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Ground : MonoBehaviour
{
    public float Speed;
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        transform.position += new Vector3(-Speed * Time.deltaTime, 0, 0);
        if(transform.position.x < -17.6f)
        {
            transform.position = new Vector3(17.7f, transform.position.y, 0);
        }
    }
}
