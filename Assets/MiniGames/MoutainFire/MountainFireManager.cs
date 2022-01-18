using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MountainFireManager : MinigameManager
{

    // Start is called before the first frame update
    private void Awake()
    {
        switch (GameManager.Instance.Level)
        {
            case 1:
                TimerTime = 8;
                break;
            case 2:
                TimerTime = 8;
                break;
            default:
                TimerTime = 8;
                break;
        }
    }

    void Start()
    {

    }

    //���� �Ʒ� �Ⱦ� �� ��ġ�� ����� �Ф�
    public override IEnumerator GameClear()
    {
        yield return new WaitForSeconds(1);
    }

    public override IEnumerator GameOver()
    {
        yield return new WaitForSeconds(1);
    }
}
