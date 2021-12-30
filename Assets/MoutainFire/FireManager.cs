using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FireManager : ObjectPool<Fire>
{
    [SerializeField] int FireCount;
    protected override void Start()
    {
        base.Start();
        for (int i = 0; i < FireCount; i++)
        {
            FireManager.Instance.GetObj(new Vector3(Random.Range(-8.0f, 8.0f), -3, 0), Quaternion.identity, transform, true);
        }
    }

}
