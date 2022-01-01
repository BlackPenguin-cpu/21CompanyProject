using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EikCamera : MonoBehaviour
{
    public GameObject EikCam;
    public GameObject E;

    // Start is called before the first frame update
    void Start()
    {

    }

    // Update is called once per frame
    void Update()
    {
        if (E.transform.position.x >= 0 && E.transform.position.x <= 7)
        {
            transform.position = EikCam.transform.position + new Vector3(0, 0, -10);
        }

        
    }

}
