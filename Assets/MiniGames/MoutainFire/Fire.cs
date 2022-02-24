using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Fire : MonoBehaviour
{
    [SerializeField] private int Hp;
    public FireManager fireManager;
    public float Scale;
    private void OnEnable()
    {
        Hp = 20;
        transform.localScale = new Vector3(0.02f * Hp, 0.02f * Hp, 1);
        transform.position = new Vector3(transform.position.x, -4f + Scale * Hp, 1);
    }
    private void Start()
    {
        fireManager = FindObjectOfType<FireManager>();
        transform.localScale = new Vector3(0.02f * Hp, 0.02f * Hp, 1);
        transform.position = new Vector3(transform.position.x, -4f + Scale * Hp, 1);
    }

    public int _Hp
    {
        get { return Hp; }
        set
        {
            if(value % 6 == 0)
            {
                SoundManager.Instance.PlaySound("Fire_fighting");
            }
            transform.localScale = new Vector3(0.02f * Hp, 0.02f * Hp, 1);
            transform.position = new Vector3(transform.position.x, -4f + Scale * Hp, 1);
            if (value == 0)
            {
                fireManager.Life--;
                fireManager.ReturnObj(gameObject.GetComponent<Fire>());
            }
            Hp = value;
        }
    }
}
