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

    private void Start()
    {
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
        ChocolateManager.Instance.Onclear();
    }
    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.tag == "Chocolate" && GameOver == false)
        {
            Destroy(collision.gameObject);
            GameOver = true;
            rigid.AddForce(new Vector2(2, 0), ForceMode2D.Impulse);
            transform.DOLocalRotateQuaternion(Quaternion.Euler(0,0,-110), 1.0f);
            GameManager.Instance.ChangeScene(false, 2);
        }
    }
}
