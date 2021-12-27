using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Ground : MonoBehaviour
{
    public float Speed;
    [SerializeField] CatControlable Cat;
    void Start()
    {
        Cat = FindObjectOfType<CatControlable>();
    }

    // Update is called once per frame
    void Update()
    {
        if(Cat.Die == false)
        transform.position += new Vector3(-Speed * Time.deltaTime, 0, 0);
        if (transform.position.x < -17.6f)
        {
            transform.position = new Vector3(17.7f, transform.position.y, 0);
        }
    }
}
