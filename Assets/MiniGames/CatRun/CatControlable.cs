using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public enum State
{
    RUN,
    JUMP
}

public class CatControlable : MonoBehaviour
{
    Rigidbody2D rigid;
    Animator anim;
    BoxCollider2D Colider;
    State state;
    public float JumpPower;
    private int JumpCount;

    public bool Die;
    // Start is called before the first frame update
    void Start()
    {
        JumpCount = 1;
        Colider = GetComponent<BoxCollider2D>();
        anim = GetComponent<Animator>();
        rigid = GetComponent<Rigidbody2D>();
    }

    // Update is called once per frame
    void Update()
    {
        anim.SetInteger("State", (int)state);
        if (Input.GetMouseButtonDown(0) && JumpCount == 1)
        {
            JumpCount = 0;
            state = State.JUMP;
            rigid.AddForce(new Vector3(0, JumpPower, 0), ForceMode2D.Impulse);
            StartCoroutine(Jump());
        }
    }
    IEnumerator Jump()
    {
        SoundManager.Instance.PlaySound("Jump");

        yield return new WaitForSeconds(1);
        state = State.RUN;
    }

    private void OnCollisionEnter2D(Collision2D collision)
    {
       
        JumpCount = 1;
        if (collision.gameObject.tag.Contains("IronFan"))
        {
            StartCoroutine(GameManager.Instance.ChangeScene(false, GameOver()));
            SoundManager.Instance.PlaySound("Fall");
        }
    }

    IEnumerator GameOver()
    {
        Debug.Log("���ӿ���");
        Die = true;
        rigid.freezeRotation = false;
        Colider.isTrigger = true;
        rigid.AddForce(new Vector3(6, 0, 0), ForceMode2D.Impulse);
        rigid.AddTorque(-5, ForceMode2D.Impulse);
        yield return new WaitForSeconds(2);
    }

}
