using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Humandelete : MonoBehaviour
{
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
            Destroy(gameObject);
        }
    }
}
