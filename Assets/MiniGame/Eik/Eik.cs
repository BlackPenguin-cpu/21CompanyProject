using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using DG.Tweening;

public class Eik : MonoBehaviour
{
    public int spd;

    // Start is called before the first frame update
    void Start()
    {
       
    }

    // Update is called once per frame
    void Update()
    {
        Move();
    }

    public void Move()
    {
        if(transform.position.x >= 12)
        {
            transform.position += new Vector3(Time.deltaTime * spd, 0, 0);
        }
        else if (Input.GetMouseButton(0))
        {
            transform.position += new Vector3(Time.deltaTime*spd, 0, 0);
        }


       
    }
   
  
}
