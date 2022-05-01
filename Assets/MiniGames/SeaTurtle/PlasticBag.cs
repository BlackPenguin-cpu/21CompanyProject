using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlasticBag : MonoBehaviour
{
    Camera MainCamera;
    [SerializeField] float power;
    public float Speed;
    Rigidbody2D rigid;
    bool GameEnd;

    private Vector2 Target = new Vector2(0, 3.2f);

    private bool isMouseDown;
    public bool _isMouseDown
    {
        get { return isMouseDown; }
        set
        {
            if (GameEnd) return;
            isMouseDown = value;
        }
    }

    // Start is called before the first frame update
    void Start()
    {
        rigid = GetComponent<Rigidbody2D>();
        MainCamera = FindObjectOfType<Camera>();
        rigid.AddTorque(-1, ForceMode2D.Impulse);
    }

    // Update is called once per frame
    void Update()
    {
        objIsClicked();
    }
    void objIsClicked()
    {
        if (isMouseDown && !GameManager.Instance.Pause)
        {

            Vector3 mousepos = MainCamera.ScreenToWorldPoint(Input.mousePosition);
            Vector3 pos = mousepos - transform.position;
            Vector3.Normalize(pos);
            rigid.AddForce(pos * power * Time.deltaTime, ForceMode2D.Impulse);
            if (Input.GetMouseButtonUp(0)) isMouseDown = false;
        }
        else
        {
            transform.position = Vector2.MoveTowards(transform.position, Target, Time.deltaTime * Speed);
        }
    }
    private void OnBecameInvisible()
    {
        SoundManager.Instance.PlaySound("plastic");
        isMouseDown = false;
        PlasticBagManager.Instance.ReturnObj(GetComponent<PlasticBag>());
    }
    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.tag == "Turtle")
        {
            Debug.Log("이게 외 안된데?");
            GameEnd = true;
            isMouseDown = false;
            StartCoroutine(GameManager.Instance.ChangeScene(false, FindObjectOfType<SeaTurtleManager>().GameOver()));
        }
    }



}
