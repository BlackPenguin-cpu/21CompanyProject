using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using DG.Tweening;
using UnityEngine.UI;


public class Eik : MonoBehaviour
{
    public int spd;
    GameObject Car;
    public Image image;
    public bool Check;

    public SpriteRenderer renderer;
    public List<Sprite> eik;

    // Start is called before the first frame update
    void Start()
    {
        renderer = GetComponent<SpriteRenderer>();
    }

    // Update is called once per frame
    void Update()
    {
        Move();
    }



    public void Move()
    {
        if (transform.position.x >= 47)
        {
            transform.position += new Vector3(Time.deltaTime * spd, 0, 0);
            if (!Check)
            {
                Check = true;
                StartCoroutine(GameManager.Instance.ChangeScene(true, 2f));
            }
        }
        else if (Input.GetMouseButton(0))
        {
            transform.position += new Vector3(Time.deltaTime * spd, 0, 0);

            renderer.sprite = eik[0];
        }
        else if (!Input.GetMouseButton(0))
        {
            renderer.sprite = eik[1];
        }

    }

    void OnTriggerEnter2D(Collider2D other)
    {

        spd = 0;

        image.DOFade(1, 2f);
        if (Check)
        {
            Check = false;
            StartCoroutine(GameManager.Instance.ChangeScene(false, 2f));
        }
    }

}
