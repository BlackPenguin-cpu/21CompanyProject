using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class StartDash : MonoBehaviour
{

    public GameObject Light;
    public GameObject Hunter;
    void Start()
    {
        HunterSpawn();
        Light.SetActive(true);
    }

    void Update()
    {

    }

    void HunterSpawn()
    {
        float Random_x = Random.Range(-13, 13f);
        float Random_y = Random.Range(-7, 7f);
        Hunter.transform.position = new Vector3(Random_x, Random_y, 0f);
    }
}
