using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MouseLight : MonoBehaviour
{
    public Camera CAM;
    public GameObject cube;
    public bool isclick = false;
    public GameObject human;
    public GameObject BigLight;
    public GameObject Light;
    void Start()
    {

    }

    void Update()
    {
        Cursor();

        if (isclick)
        {
            GameClear();
        }
    }

    void GameClear()
    {
        Light.GetComponent<Light>().range = 0;
        BigLight.SetActive(true);
        human.transform.Translate(new Vector3(0, 0, 8 * Time.deltaTime));
    }

    void Cursor()
    {
        Vector3 mouse = CAM.ScreenToWorldPoint(new Vector3(Input.mousePosition.x, Input.mousePosition.y, 10));

        transform.position = mouse;

        RaycastHit2D[] hitobject = Physics2D.RaycastAll(mouse, Vector3.forward);
        foreach (var item in hitobject)
        {
            if (item.collider.gameObject.tag == "Human" && Input.GetMouseButtonUp(0))
            {
                human = item.collider.gameObject;
                isclick = true;
            }
        }

    }
}
