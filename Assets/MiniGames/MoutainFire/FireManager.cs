using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FireManager : ObjectPool<Fire>
{
    [SerializeField] int FireCount;
    [SerializeField] GameObject Kanngaroo;
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
                FireCount = 3;
                break;
            default:
                FireCount = 4;
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
            SoundManager.Instance.PlaySound("Fire");

            StartCoroutine(GameManager.Instance.ChangeScene(true, GameClear()));
            End = true;
        }
    }

    IEnumerator GameClear()
    {
        while(Kanngaroo.transform.position.x > 0)
        {
            Kanngaroo.transform.position += new Vector3(Time.deltaTime, 0, 0);
            yield return null;
        }
    }
}
