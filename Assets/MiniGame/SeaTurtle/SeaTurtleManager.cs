using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System.Linq;
using DG.Tweening;
    
public class SeaTurtleManager : MinigameManager
{
    Camera MainCamera;
    float Timer;
    bool isGameEnd;

    private void Awake()
    {
        switch (GameManager.Instance.Level)
        {
            case 1:
                TimerTime = 7;
                break;
            case 2:
                TimerTime = 10;
                break;
            default:
                TimerTime = 13;
                break;
        }
    }

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
        yield return new WaitForSeconds(1);
        PlasticBag[] plasticBag = FindObjectsOfType<PlasticBag>();

        plasticBag.ToList().ForEach(x => PlasticBagManager.Instance.ReturnObj(x));
        //foreach (var x in plasticBag) PlasticBagManager.Instance.ReturnObj(x);
        transform.DOMoveX(-8,3);
        yield return new WaitForSeconds(2);
    }

    public override IEnumerator GameOver()
    {
        Rigidbody2D rigid = GetComponent<Rigidbody2D>();
        rigid.isKinematic = false;
        rigid.gravityScale = 0.4f;
        rigid.AddTorque(-1, ForceMode2D.Impulse);
        yield return new WaitForSeconds(2);
    }

}
