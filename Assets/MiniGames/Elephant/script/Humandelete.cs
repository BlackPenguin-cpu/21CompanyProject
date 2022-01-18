using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Humandelete : MonoBehaviour
{

    public GameObject Light;
    void Start()
    {
        
    }

    void Update()
    {
        delete();
    }

    void delete()
    {
        if(transform.position.z >= 13)
        {
            Light.GetComponent<MouseLight>().isclick = false;
            Destroy(gameObject);
        }
    }
}
