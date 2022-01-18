using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Pigeon : MinigameManager   
{
    private Camera MainCamera;
    public GameObject pigeon;
    public int maxspawn;

    void Start()
    {
        switch (GameManager.Instance.Level)
        {
            case 1:
                TimerTime = 10;
                break;
            case 2:
                TimerTime = 10;
                break;
            default:
                TimerTime = 10;
                break;

        }
        LevelSpawn();
        PigeonSpawn();
        MainCamera = FindObjectOfType<Camera>();
    }

    void Update()
    {
        PigeonClick();
    }

    void PigeonSpawn()
    {
        for (int i = 0; i < maxspawn; i++)
        {
            float position_x = Random.Range(-8.0f, 8.0f), position_y = Random.Range(1.0f, -5.0f);
            int rotation = Random.Range(0, 2);
            if (rotation == 0)
            {
                rotation = 180;
            }
            else if (rotation == 1)
            {
                rotation = 0;
            }
            Instantiate(pigeon, new Vector3(position_x, position_y, 0), Quaternion.Euler(new Vector3(0, rotation, 0)));
        }
    }

    void LevelSpawn()
    {
        if (GetComponent<timer>().level == 1)
        {
            maxspawn = 4;
        }
        else if (GetComponent<timer>().level == 2)
        {
            maxspawn = 7;
        }
        else if (GetComponent<timer>().level >= 3)
        {
            maxspawn = 10;
        }
    }

    void PigeonClick()
    {
        if (Input.GetMouseButtonUp(0))
        {
           
            Vector2 mousepos = MainCamera.ScreenToWorldPoint(Input.mousePosition);
            if (Physics2D.Raycast(mousepos, Vector3.forward))
            {
                RaycastHit2D Hitobject = Physics2D.Raycast(mousepos, Vector3.forward);
                if (Hitobject.collider.gameObject.tag == "Pigeon")
                {
                    Hitobject.collider.GetComponent<PigeonFly>().click = true;
                    Hitobject.collider.GetComponent<PigeonFly>().random = true;
                }
            }


        }
    }

    public override IEnumerator GameOver()
    {
        yield return new WaitForSeconds(1);
    }

    public override IEnumerator GameClear()
    {
        yield return new WaitForSeconds(1);
    }
}
