using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SeaTurtleManager : MinigameManager
{
    bool isMouseDown;
    Rigidbody2D plasticbag;
    Camera MainCamera;
    public float power;
    void Start()
    {
        MainCamera = FindObjectOfType<Camera>();
        plasticbag = null;
    }

    void Update()
    {
        MouseEvent();
    }
    void MouseEvent()
    {
        if (Input.GetMouseButtonDown(0))
        {
            Vector2 mousepos = MainCamera.ScreenToWorldPoint(Input.mousePosition);
            if (Physics2D.Raycast(mousepos, Vector3.forward))
            {
                RaycastHit2D Hitobject = Physics2D.Raycast(mousepos, Vector3.forward);
                if (Hitobject.collider.gameObject.tag == "PlasticBag")
                {
                    Debug.Log("しいしいけ");
                    isMouseDown = true;
                    plasticbag = Hitobject.collider.gameObject.GetComponent<Rigidbody2D>();
                }
            }
        }
        if (isMouseDown)
        {
            Vector3 mousepos = MainCamera.ScreenToWorldPoint(Input.mousePosition);
            Vector3 pos = mousepos - plasticbag.transform.position ;
            Vector3.Normalize(pos);
            plasticbag.AddForce(pos * power * Time.deltaTime, ForceMode2D.Impulse);
        }
        if (Input.GetMouseButtonUp(0))
        {
            isMouseDown = false;
        }
    }
    protected override IEnumerator GameClear()
    {
        yield return new WaitForSeconds(1);
    }

    protected override IEnumerator GameOver()
    {
        yield return new WaitForSeconds(1);
    }

}
