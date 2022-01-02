using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using DG.Tweening;

public class ChocolateDog : MonoBehaviour
{
    public float Speed;
    public float BackSpeed;
    public bool GameOver;

    Rigidbody2D rigid;
    Sprite sprite;

    private void Start()
    {
        sprite = GetComponent<Sprite>();
        rigid = GetComponent<Rigidbody2D>();
    }
    void Update()
    {
        if (!GameOver) transform.position += new Vector3(Speed * Time.deltaTime, 0, 0);
    }
    public IEnumerator OnDrag()
    {
        for (int i = 0; i < 100; i++)
        {
            transform.position += new Vector3(-BackSpeed * Time.deltaTime, 0, 0);
            yield return new WaitForSeconds(0.005f);
        }
    }
    private void OnBecameInvisible()
    {
        Debug.Log("¾Èº¸¿µ");
        StartCoroutine(GameManager.Instance.ChangeScene(true, GameClear()));
    }
    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.tag == "Chocolate" && GameOver == false)
        {
            Destroy(collision.gameObject);
            StartCoroutine(GameManager.Instance.ChangeScene(false, Gameover()));
        }
    }
    IEnumerator Gameover()
    {
        GameOver = true;
        rigid.AddForce(new Vector2(2, 0), ForceMode2D.Impulse);
        transform.DOLocalRotateQuaternion(Quaternion.Euler(0, 0, -110), 1.0f);
        yield return new WaitForSeconds(2);
    }

    public IEnumerator GameClear(){
        transform.DOMoveX(-17, 2);
        yield return new WaitForSeconds(2);
    }
}
