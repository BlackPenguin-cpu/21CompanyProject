using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FireManager : ObjectPool<Fire>
{
    [SerializeField] int FireCount;
    public int Life;
    protected override void Start()
    {
        base.Start();
        for (int i = 0; i < FireCount; i++)
        {
            Instance.GetObj(new Vector3(Random.Range(-8.0f, 8.0f), -3, 0), Quaternion.identity, transform, true);
        }
        Life = FireCount;
    }
    public void GameOver()
    {
        StartCoroutine(Gameoverr());
    }
    IEnumerator Gameoverr()
    {
        for (int i = 0; i < 20; i++)
        {
            Instance.GetObj(new Vector3(Random.Range(-8.0f, 8.0f), -3, 0), Quaternion.identity, transform, true);
            yield return new WaitForSeconds(0.5f);
        }
    }
    private void Update()
    {
        if (Life <= 0)
        {
            GameManager.Instance.ChangeScene(true, 0);
        }
    }
}
