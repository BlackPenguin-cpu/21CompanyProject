using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MouseLight : MonoBehaviour
{
    public Camera CAM;
    public GameObject cube;

    void Start()
    {

    }

    void Update()
    {
        Vector3 mouse = CAM.ScreenToWorldPoint(new Vector3(Input.mousePosition.x, Input.mousePosition.y, 10));

        transform.position = mouse;

        RaycastHit2D[] hitobject = Physics2D.RaycastAll(mouse, Vector3.forward);
        foreach (var item in hitobject)
        {
            if (item.collider.gameObject.tag == "Human")
            {
                item.collider.gameObject.transform.Translate(new Vector3(0, 0, 8*Time.deltaTime));
            }
        }
    }

}
