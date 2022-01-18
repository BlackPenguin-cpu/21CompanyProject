using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using DG.Tweening;
using UnityEngine.UI;


public class Eik : MinigameManager
{
    public int spd;
    GameObject Car;
    public Image image;
    public bool Check;

    public SpriteRenderer renderer;
    public List<Sprite> eik;

    // Start is called before the first frame update

    private void Awake()
    {
        switch (GameManager.Instance.Level)
        {
            case 1:
                TimerTime = 15;
                break;
            case 2:
                TimerTime = 15;
                break;
            default:
                TimerTime = 15;
                break;
        }
    }
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
                StartCoroutine(GameManager.Instance.ChangeScene(true, GameClear()));
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
        if (!Check)
        {
            Check = true;
            StartCoroutine(GameManager.Instance.ChangeScene(false, GameOver()));
        }
    }

    public override IEnumerator GameOver()
    {
        yield return new WaitForSeconds(2);
    }

    public override IEnumerator GameClear()
    {
        yield return new WaitForSeconds(2);
    }
}
