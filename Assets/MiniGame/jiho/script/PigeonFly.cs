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
        if (random == true)
        {
            random = false;
            random_x = Random.Range(-0.2f, 0.3f);
        }
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

    void OnTriggerEnter2D(Collider2D collider)
    {
        if(collider.tag == "deadline")
        {
            Debug.Log("ю╦╬с аж╠щ");
            Destroy(gameObject);
        }
    }
}
