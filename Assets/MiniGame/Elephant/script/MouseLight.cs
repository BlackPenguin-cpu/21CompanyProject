using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MouseLight : MonoBehaviour
{
    public Camera CAM;

    void Start()
    {

    }

    void Update()
    {
        Vector3 mouse = CAM.ScreenToWorldPoint(new Vector3(Input.mousePosition.x, Input.mousePosition.y, 10));
        Debug.Log(mouse);
        transform.position = mouse;
    }
}
