using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class lifeline : MonoBehaviour
{
    public GameObject level;
    public int life = 1;
    void Start()
    {
        maxlife();
    }

    void Update()
    {
        if(life == 0)//게임 클리어
        {
            level.GetComponent<timer>().clear = false;
            StartCoroutine(GameManager.Instance.ChangeScene(true, 2f));
        }
    }

    void maxlife()
    {
        if (level.GetComponent<timer>().level == 1)
        {
            life = 4;
        }
        else if (level.GetComponent<timer>().level == 2)
        {
            life = 7;
        }
        else if (level.GetComponent<timer>().level == 3)
        {
            life = 10;
        }
    }

    void OnTriggerEnter2D(Collider2D collider)
    {
        if (collider.tag == "Pigeon")
        {
            life--;
            Destroy(collider.gameObject);
        }
    }
}
