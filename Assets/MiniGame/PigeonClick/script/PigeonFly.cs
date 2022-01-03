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
        if (random == true) //��ѱⰡ ���� x ��ǥ �������� ����
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
