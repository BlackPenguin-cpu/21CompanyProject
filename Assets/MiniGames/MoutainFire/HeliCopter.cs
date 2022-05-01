using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class HeliCopter : ObjectPool<Water>
{
    Rigidbody2D rigid;
    Camera cam;
    [SerializeField] GameObject WaterTank;
    FireManager fireManager;
    //[SerializeField] GameObject Water;
    float Timer;
    void Start()
    {
        fireManager = FindObjectOfType<FireManager>();
        rigid = GetComponent<Rigidbody2D>();
        cam = FindObjectOfType<Camera>();

        SoundManager.Instance.PlaySound("Heli");
    }

    // Update is called once per frame
    void Update()
    {
        Timer += Time.deltaTime;
        if (Timer > 0.01f && fireManager.End == false)
        {
            Timer = 0;
            GetObj(transform.position, Quaternion.identity, WaterTank.transform, true);
        }
        Move();
    }

    private void Move()
    {
        if (transform.localEulerAngles.z > 35f && transform.localEulerAngles.z < 100f)
        {
            transform.rotation = Quaternion.Euler(0, 0, 35f);
        }
        if (transform.localEulerAngles.z < 325f && transform.localEulerAngles.z > 100f)
        {
            transform.rotation = Quaternion.Euler(0, 0, 325f);
        }
        if (Input.GetMouseButton(0) && !GameManager.Instance.Pause)
        {
            if (cam.ScreenToWorldPoint(Input.mousePosition).x > 0 && rigid.velocity.x < 8)
            {
                GetComponent<SpriteRenderer>().flipX = true;
                rigid.AddForce(new Vector2(5 * Time.deltaTime, 0), ForceMode2D.Impulse);
                if (transform.localEulerAngles.z < 325f)
                {
                    rigid.AddTorque(-2f * Time.deltaTime, ForceMode2D.Impulse);
                }
                else
                    rigid.AddTorque(-0.2f * Time.deltaTime, ForceMode2D.Impulse);
            }
            else if (cam.ScreenToWorldPoint(Input.mousePosition).x < 0 && rigid.velocity.x > -8)
            {
                GetComponent<SpriteRenderer>().flipX = false;
                rigid.AddForce(new Vector2(-5 * Time.deltaTime, 0), ForceMode2D.Impulse);
                if (transform.localEulerAngles.z > 325f)
                {
                    rigid.AddTorque(2f * Time.deltaTime, ForceMode2D.Impulse);
                }
                rigid.AddTorque(0.2f * Time.deltaTime, ForceMode2D.Impulse);
            }
        }
        else
        {
            transform.rotation = Quaternion.RotateTowards(transform.rotation, Quaternion.Euler(0, 0, 0), 500 * Time.deltaTime);
        }
    }
}

