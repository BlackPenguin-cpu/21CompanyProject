using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PigeonFly : MonoBehaviour
{
    public bool click = false;
    public bool random = false;
    private float random_x = 0;
    void Start()
    {

    }

    void Update()
    {
        XRandom();
        PigeonDDukbaegi();
    }

    void OnTriggerEnter2D(Collider2D collider)
    {
        if(collider.tag == "deadline")
        {
            Destroy(gameObject);
        }
    }

    void XRandom()
    {
        if (random == true) //비둘기가 날라갈 x 좌표 랜덤으로 지정
        {
            random = false;
            random_x = Random.Range(-0.2f, 0.3f);
        }
    }

    void PigeonDDukbaegi()
    {
        if (click)
        {
            if (random_x < 0f)
            {
                transform.rotation = Quaternion.Euler(new Vector3(0, 0, 0));
            }
            if(random_x > 0f)
            {
                transform.rotation = Quaternion.Euler(new Vector3(0, 180, 0));
            }
            GetComponent<Transform>().position += new Vector3(random_x, 0.1f, 0);
        }
    }
}
