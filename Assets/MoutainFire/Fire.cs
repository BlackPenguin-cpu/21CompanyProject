using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Fire : MonoBehaviour
{
    [SerializeField] private int Hp;
    public FireManager fireManager;
    public float Scale;
    private void Start()
    {
        fireManager = FindObjectOfType<FireManager>();
        transform.localScale = new Vector3(0.1f * Hp, 0.2f * Hp, 1);
        transform.position = new Vector3(transform.position.x, -4.4f + Scale * Hp, 1);
    }
    public int _Hp
    {
        get { return Hp; }
        set
        {
            transform.localScale = new Vector3(0.1f * Hp, 0.2f * Hp, 1);
            transform.position = new Vector3(transform.position.x, -4.4f + Scale * Hp, 1);
            if (value < 0)
            {
                fireManager.WinCheck();
                FireManager.Instance.ReturnObj(gameObject.GetComponent<Fire>());
            }
            Hp = value;
        }
    }
}
