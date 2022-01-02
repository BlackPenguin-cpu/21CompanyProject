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

    // Start is called before the first frame update
    void Start()
    {
        
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
        }
        else if (Input.GetMouseButton(0))
        {
            transform.position += new Vector3(Time.deltaTime * spd, 0, 0);
        }

    }

    void OnTriggerEnter2D(Collider2D other)
    {

        Debug.Log("aaaaasssss");
        spd = 0;

        image.DOFade(1, 2f);

    }

}
