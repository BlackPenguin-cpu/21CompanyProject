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
    State state;
    public float JumpPower;
    // Start is called before the first frame update
    void Start()
    {
        anim = GetComponent<Animator>();
        rigid = GetComponent<Rigidbody2D>();
    }

    // Update is called once per frame
    void Update()
    {
        anim.SetInteger("State", (int)state);
        if (Input.GetKeyDown(KeyCode.Space))
        {
            state = State.JUMP;
            rigid.AddForce(new Vector3(0, JumpPower, 0),ForceMode2D.Impulse);
            StartCoroutine(Jump());
        }
    }
    IEnumerator Jump()
    {
        yield return new WaitForSeconds(1);
        state = State.RUN;
    }

    private void OnCollisionEnter(Collision collision)
    {
        if (collision.gameObject.tag.Contains("IronFan"))
        {
            //추후 수정 필요
            Debug.Log("게임오버");
            Destroy(gameObject);
        }
    }
}
