using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FireManager : ObjectPool<Fire>
{
    [SerializeField] int FireCount;
    public int Life;
    public bool End;
    void Start()
    {
        switch (GameManager.Instance.Level)
        {
            case 1:
                FireCount = 2;
                break;
            case 2:
                FireCount = 4;
                break;
            case 3:
                FireCount = 6;
                break;
        }
        for (int i = 0; i < FireCount; i++)
        {
            Instance.GetObj(new Vector3(Random.Range(-8.0f, 8.0f), -3, 0), Quaternion.identity, transform, true);
        }
        Life = FireCount;
    }

    public IEnumerator Gameoverr()
    {
        End = true;
        for (int i = 0; i < 6; i++)
        {
            Instance.GetObj(new Vector3(Random.Range(-8.0f, 8.0f), -3, 0), Quaternion.identity, transform, true);
            Instance.GetObj(new Vector3(Random.Range(-8.0f, 8.0f), -3, 0), Quaternion.identity, transform, true);
            yield return new WaitForSeconds(0.5f);
        }
    }
    private void Update()
    {
        if (Life <= 0 && End == false)
        {
            StartCoroutine(GameManager.Instance.ChangeScene(true, 0.1f));
            End = true;
        }
    }
}
