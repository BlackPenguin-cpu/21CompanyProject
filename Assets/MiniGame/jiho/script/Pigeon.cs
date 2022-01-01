using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Pigeon : MonoBehaviour
{
    private Camera MainCamera;
    void Start()
    {
        MainCamera = FindObjectOfType<Camera>();
    }

    void Update()
    {
        if (Input.GetMouseButtonUp(0))
        {

            Vector2 mousepos = MainCamera.ScreenToWorldPoint(Input.mousePosition);
            if (Physics2D.Raycast(mousepos, Vector3.forward))
            {
                RaycastHit2D Hitobject = Physics2D.Raycast(mousepos, Vector3.forward);
                if (Hitobject.collider.gameObject.tag == "Pigeon")
                {
                    Debug.Log("备备备备备");
                }
            }


        }
    }
}
