using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SeaTurtleManager : MinigameManager
{
    Camera MainCamera;
    float Timer;
    bool isGameEnd;
    void Start()
    {
        MainCamera = FindObjectOfType<Camera>();
    }

    void Update()
    {
        MouseEvent();
        ClearCheck();
    }
    void ClearCheck()
    {
        //if (Timer >= 15 && !isGameEnd)
        //{
        //    isGameEnd = true;
        //    GameManager.Instance.ChangeScene(true, GameClear());
        //}
        //else if(!isGameEnd)
        //{
        //    Timer += Time.deltaTime;
        //}
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
                    Hitobject.collider.gameObject.GetComponent<PlasticBag>()._isMouseDown = true;
                }
            }
        }

    }
    public override IEnumerator GameClear()
    {
        Debug.Log("SeaTurtle : GameClear");
        yield return new WaitForSeconds(1);
    }

    public override IEnumerator GameOver()
    {
        Debug.Log("SeaTurtle : GameOver");
        yield return new WaitForSeconds(1);
    }

}
