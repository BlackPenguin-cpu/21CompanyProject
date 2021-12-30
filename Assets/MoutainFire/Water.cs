using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Water : MonoBehaviour
{
    private void OnEnable()
    {
        Invoke("returnFire", 2);
    }
    void Update()
    {
        
    }
    void returnFire()
    {
        HeliCopter.Instance.ReturnObj(gameObject.GetComponent<Water>());

    }
    private void OnTriggerEnter2D(Collider2D collision)
    {
        if(collision.tag == "fire")
        {
            Fire fire = collision.GetComponent<Fire>();

            fire._Hp--;
        }
    }
}
