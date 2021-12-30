using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Fire : MonoBehaviour
{
    private int Hp;
    FireManager fire_MG;
    private void Start()
    {
        fire_MG = GetComponentInParent<FireManager>();
    }
    public int _Hp
    {
        get { return Hp; }
        set
        {
            if (value < 0)
            {
                FireManager.Instance.ReturnObj(gameObject.GetComponent<Fire>());
            }
            Hp = value;
        }
    }
}
